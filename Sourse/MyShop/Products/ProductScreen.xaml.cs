using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyShop.Products
{
    /// <summary>
    /// Interaction logic for ProductScreen.xaml
    /// </summary>
    public partial class ProductScreen : UserControl
    {
        class FilterEntity
        {
            public int Value { get; set; }
        }

        PagingInfo _pagingInfo;
        FilterEntity _filterInfo;

        int rowsPerPage = 12;

        //delegate cho screen hóa đơn
        public delegate void PickProduct(Product Data);
        public PickProduct PickProductId;

        string _connectionString;

        public ProductScreen(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            // Get và hiển thị danh sách sản phẩm
            Thread getProducts = new Thread(delegate ()
            {
                //progressBar.IsIndeterminate = true;
                _filterInfo = new FilterEntity() { Value = 8000000 };

                var db = new MyShopEntities(_connectionString);

                Dispatcher.Invoke(() =>
                {
                    statusLabel.Content = "Application is ready";
                    //Danh sách loại sản phẩm
                    categoriesComboBox.ItemsSource = db.Categories.ToList();
                    categoriesComboBox.SelectedIndex = 0;

                    filterPanel.DataContext = _filterInfo;
                    progressBar.IsEnabled = false;
                });
            });
            getProducts.Start();

        }
        private async void UserControl_Initialized(object sender, EventArgs e)
        {
            //progressBar.IsIndeterminate = true;
            //statusLabel.Content = "Application is ready";

            //_filterInfo = new FilterEntity() { Value = 8000000 };

            //var db = new MyShopEntities(_connectionString);


            //await Task.Run(() =>
            //{
            //    Thread.Sleep(2000);
            //});
            //progressBar.IsIndeterminate = false;

            //categoriesComboBox.ItemsSource = db.Categories.ToList();
            //categoriesComboBox.SelectedIndex = 0;
            //filterPanel.DataContext = _filterInfo;
        }


        /// <summary>
        /// Quay lại màn hình home
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backWard_Click(object sender, RoutedEventArgs e)
        {
            // nếu Pick sản phẩm để tạo hóa đơn
            if (PickProductId != null)
            {
                homeProduct.Children.Clear();
            }
            else
            {
                homeProduct.Children.Clear();
                homeProduct.Children.Add(new HomeScreen(_connectionString));
            }

        }
        /// <summary>
        /// Giá trị của comboBox thay đổi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void categoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalculatePagingInfo();
            UpdateProductView();
        }

        #region Xử lý hiệu ứng Comboxbox
        /// <summary>
        /// Hiệu ứng khi chọn
        /// </summary>
        private void ComboProductTypes_DropDownOpened(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            comboBox.Background = Brushes.LightGray;
        }

        /// <summary>
        /// Hiệu ứng khi bỏ chọn
        /// </summary>
        private void ComboProductTypes_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            comboBox.Background = Brushes.Transparent;
        }
        #endregion


        /// <summary>
        /// Button hamburger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filterToggle_Click(object sender, RoutedEventArgs e)
        {
            if (filterPanel.IsCollapsed())
            {
                filterPanel.Show();
            }
            else
            {
                filterPanel.Collapse();
            }
        }

        private void priceRangeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
        private void Slider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            CalculatePagingInfo();
            UpdateProductView();
        }

        /// <summary>
        /// Nhân giá trị text trong khung Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            CalculatePagingInfo();
            UpdateProductView();

            statusLabel.Content = "Search";
        }

        private void productsListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            statusLabel.Content = "Detail product";
            var db = new MyShopEntities(_connectionString);
            dynamic itemProduct = (sender as ListView).SelectedItem;

            if (itemProduct != null)
            {
                // lấy sản phẩm trong database
                var product = db.Products.Find(itemProduct.Product_Id);

                // nếu Pick sản phẩm để tạo hóa đơn
                if (PickProductId != null)
                {
                    PickProductId.Invoke(product);
                    homeProduct.Children.Clear();
                }
                else
                {
                    var screen = new DetailProductScreen(_connectionString, product);
                    screen.RefreshProductList = refresh;
                    homeProduct.Children.Add(screen);
                }
            }

        }
        /// <summary>
        /// Giá trị trong comboBox thay đổi, Update lại ProductsView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboPageIndex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int nextPage = comboBoxPaging.SelectedIndex + 1;
            _pagingInfo.CurrentPage = nextPage;

            UpdateProductView();
        }
        /// <summary>
        /// Trang trước trang hiện tại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousPaging_Click(object sender, RoutedEventArgs e)
        {
            var currentIndex = comboBoxPaging.SelectedIndex;
            if (currentIndex > 0)
            {
                comboBoxPaging.SelectedIndex--;
            }
        }
        /// <summary>
        /// Trang kế tiếp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextPaging_Click(object sender, RoutedEventArgs e)
        {
            var currentIndex = comboBoxPaging.SelectedIndex;
            if (currentIndex <= _pagingInfo.Pages.Count)
            {
                comboBoxPaging.SelectedIndex++;
            }
        }
        /// <summary>
        /// Tính toán số trang của một category
        /// </summary>
        void CalculatePagingInfo()
        {
            var db = new MyShopEntities(_connectionString);

            var _selectedCategoryIndex = categoriesComboBox.SelectedItem as Category;
            var products = db.Categories.Find(_selectedCategoryIndex.Category_Id).Products;
            var keyword = searchTextBox.Text;

            var query = from product in products
                        where product.Product_Name.ToLower()
                                .Contains(keyword.ToLower()) && product.Price <= _filterInfo.Value
                        select product.Product_Id;

            // Tinh toan thong tin phan trang
            var count = query.Count();
            _pagingInfo = new PagingInfo()
            {
                RowsPerPage = rowsPerPage,
                TotalItems = count,
                TotalPages = count / rowsPerPage +
                    (((count % rowsPerPage) == 0) ? 0 : 1),
                CurrentPage = 1
            };

            comboBoxPaging.ItemsSource = _pagingInfo.Pages;
            comboBoxPaging.SelectedIndex = 0;

            statusLabel.Content = $"Tổng sản phẩm: {count} ";

        }
        /// <summary>
        /// Cập nhật lại danh sách sản phẩm
        /// </summary>
        void UpdateProductView()
        {
            var db = new MyShopEntities(_connectionString);

            var _selectedCategoryIndex = categoriesComboBox.SelectedItem as Category;
            var products = db.Categories.Find(_selectedCategoryIndex.Category_Id).Products;
            var keyword = searchTextBox.Text;

            var query = from product in products
                        where product.Product_Name.ToLower()
                                          .Contains(keyword.ToLower()) && product.Price <= _filterInfo.Value
                        //&& product.Price <= _filterInfo.Value
                        select new
                        {
                            product.Product_Id,
                            ProductName = product.Product_Name,
                            Thumbnail = product.Photos.First().Data,
                            product.Price,
                            ShouldBeRed = product.Quantity <= 10
                        };

            
            // Gan du lieu cho list view de o cuoi cung
            // Dua theo trang hien tai
            var skip = (_pagingInfo.CurrentPage - 1) * _pagingInfo.RowsPerPage;
            var take = _pagingInfo.RowsPerPage;
            productsListView.ItemsSource = query.Skip(skip).Take(take);
        }

        private void AddProductItem_Click(object sender, RoutedEventArgs e)
        {
            var screen = new NewProductScreen(_connectionString);
            screen.RefreshProductList = refresh;
            homeProduct.Children.Add(screen);
        }
        /// <summary>
        /// Làm mới danh sách sản phẩm (list view)
        /// </summary>
        public void refresh(bool Data)
        {
            if (!Data) return;

            CalculatePagingInfo();
            UpdateProductView();
        }

    }

}
