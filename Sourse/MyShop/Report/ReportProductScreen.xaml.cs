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

namespace MyShop.Report
{
    /// <summary>
    /// Interaction logic for ReportProductScreen.xaml
    /// </summary>
    public partial class ReportProductScreen : UserControl
    {
        public string _report;
        string _connectionString;
        public ReportProductScreen(string connectionString, string report)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _report = report;

            //Lấy số liệu thống kê
            Thread reportProduct = new Thread(delegate ()
            {
                var db = new MyShopEntities(_connectionString);

                Dispatcher.Invoke(() =>
                {
                    //Mở trạng thái progressBar
                    progressBar.IsIndeterminate = true;
                    statusLabel.Content = "Application is ready";

                    //Gán danh dữ liệu category vào combobox
                    categoriesComboBox.ItemsSource = db.Categories.ToList();
                    categoriesComboBox.SelectedIndex = 0;

                    //Lấy index của comboBox
                    var _selectedCategoryIndex = categoriesComboBox.SelectedItem as Category;
                    var products = db.Categories.Find(_selectedCategoryIndex.Category_Id).Products;//Lấy category trong database

                    if (_report == "stocking")
                    {
                        statusLabel.Content = "Stocking";
                        var query = from product in products
                                    where product.Quantity > 0
                                    orderby product.Quantity ascending
                                    select new
                                    {
                                        product.Product_Id,
                                        ProductName = product.Product_Name,

                                        product.Price,
                                        product.Quantity,
                                        Thumbnail = product.Photos.FirstOrDefault().Data,
                                    };

                        stockingListView.ItemsSource = query.ToList();
                    }

                    else
                    {
                        statusLabel.Content = "Out of stocking";
                        var query = from product in products
                                    where product.Quantity <= 10
                                    orderby product.Quantity ascending
                                    select new
                                    {
                                        product.Product_Id,
                                        ProductName = product.Product_Name,

                                        product.Price,
                                        product.Quantity,
                                        Thumbnail = product.Photos.FirstOrDefault().Data,
                                    };

                        stockingListView.ItemsSource = query.ToList();
                    }

                    progressBar.IsIndeterminate = false;
                });

            });
            reportProduct.Start();
        }
        private async  void UserControl_Initialized(object sender, EventArgs e)
        {
            //progressBar.IsIndeterminate = true;
            //statusLabel.Content = "Application is ready";

            //var db = new MyShopEntities(_connectionString);

            //await Task.Run(() =>
            //{
            //    Thread.Sleep(100);
            //});
            //progressBar.IsIndeterminate = false;
            //categoriesComboBox.ItemsSource = db.Categories.ToList();
            //categoriesComboBox.SelectedIndex = 0;

            //var _selectedCategoryIndex = categoriesComboBox.SelectedItem as Category;
            //var products = db.Categories.Find(_selectedCategoryIndex.Category_Id).Products;

            //if (_report=="stocking")
            //{
            //    var query = from product in products
            //                where product.Quantity > 0
            //                orderby product.Quantity ascending
            //                select new
            //                {
            //                    product.Product_Id,
            //                    ProductName = product.Product_Name,

            //                    product.Price,
            //                    product.Quantity,
            //                    Thumbnail = product.Photos.FirstOrDefault().Data,
            //                };
  
            //    stockingListView.ItemsSource = query.ToList();
            //}

            //else
            //{
            //    var query = from product in products
            //                where product.Quantity <= 10
            //                orderby product.Quantity ascending
            //                select new
            //                {
            //                    product.Product_Id,
            //                    ProductName = product.Product_Name,

            //                    product.Price,
            //                    product.Quantity,
            //                    Thumbnail = product.Photos.FirstOrDefault().Data,
            //                };
                
            //    stockingListView.ItemsSource = query.ToList();
            //}
           

           
        }

        void UpdateProductView()
        {
            var db = new MyShopEntities(_connectionString);

            var _selectedCategoryIndex = categoriesComboBox.SelectedItem as Category;
            var products = db.Categories.Find(_selectedCategoryIndex.Category_Id).Products;

            if (_report == "stocking")
            {
                var query = from product in products
                            where product.Quantity > 0
                            orderby product.Quantity ascending
                            select new
                            {
                                product.Product_Id,
                                ProductName = product.Product_Name,

                                product.Price,
                                product.Quantity,
                                Thumbnail = product.Photos.FirstOrDefault().Data,
                            };

                stockingListView.ItemsSource = query.ToList();
            }

            else
            {
                var query = from product in products
                            where product.Quantity <= 10
                            orderby product.Quantity ascending
                            select new
                            {
                                product.Product_Id,
                                ProductName = product.Product_Name,

                                product.Price,
                                product.Quantity,
                                Thumbnail = product.Photos.FirstOrDefault().Data,
                            };

                stockingListView.ItemsSource = query.ToList();
            }

        }

        private void categoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProductView();
        }

       
       
    }
}
