using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Definitions.Series;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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
    /// Interaction logic for ReportScreen.xaml
    /// </summary>
    public partial class ReportScreen : UserControl
    {
        public SeriesCollection Items { get; set; }
        public SeriesCollection SeriesCollectionRevenue12Month { get; set; }
        public SeriesCollection SeriesCollectionRevenue1MonthCurrent { get; set; }
        public string[] PointLabel { get; set; }
        public string[] Revenue12MonthLabels { get; set; }
        public string[] Revenue1MonthLabels { get; set; }

        string _connectionString;
        public class reportRevenue12Month
        {
            public reportRevenue12Month() { }
            public int month { get; set; }
            public int year { get; set; }
            public int revenue { get; set; }
        }

        public class reportRevenue1Month
        {
            public reportRevenue1Month() { }
            public DateTime date { get; set; }
            public int revenue { get; set; }
        }
        public class reportBestSeller
        {
            public reportBestSeller() { }
            public string product_Name { get; set; }
            public int revenue { get; set; }
        }
        public ReportScreen(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;

            Thread statistical = new Thread(delegate ()
            {
                DateTime today = DateTime.Today;

                var db = new MyShopEntities(_connectionString);
                var products = db.Products;
                var purchases = db.Purchases;
                var orderDetails = db.OrderDetails;


                Dispatcher.Invoke(() =>
                {
                    var query = from o in orderDetails
                                join p in purchases on o.OrderId equals p.Purchase_Id
                                where today.Month == ((DateTime)p.CreatedAt).Month && today.Year == ((DateTime)p.CreatedAt).Year && (p.Status == 2 || p.Status == 4)//da thanh toán
                                group o by o.ProductId into g
                                join p in products on g.FirstOrDefault().ProductId equals p.Product_Id
                                orderby g.Sum(x => x.Quantity) descending
                                select new reportBestSeller
                                {
                                    product_Name = p.Product_Name,
                                    revenue = (int)g.Sum(x => x.Quantity),
                                };

                    //ve bieu do banh the hien 5 san pham ban chạy nhat
                    var labels = new List<string>();

                    foreach (var x in query.Take(5))
                    {
                        PieSeries temp = new PieSeries()
                        {
                            DataLabels = true,
                            Title = x.product_Name,
                            Values = new ChartValues<int> { x.revenue },
                            LabelPoint = Point => string.Format("{0}", x.revenue),
                        };
                        pieChartProduct.Series.Add(temp);
                    }



                    //ve bieu do doanh thu 12 thang gan nhat

                    var queryRev12Month = from o in orderDetails
                                          group o by new { month = ((DateTime)o.CreatedAt).Month, year = ((DateTime)o.CreatedAt).Year } into g
                                          select new reportRevenue12Month
                                          {
                                              month = g.Key.month,
                                              year = g.Key.year,
                                              revenue = (int)g.Sum(x => x.Total)

                                          };

                    var labelsRev12Month = new List<string>();
                    List<ObservableValue> valuesRev12Month = new List<ObservableValue>();

                    if (queryRev12Month.Count() == 0)
                    {
                        MessageBox.Show("Không có dữ liệu từ database!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    var _list = queryRev12Month.ToList();
                    var n = queryRev12Month.Count();
                    for (var i = n - 13; i < n; ++i)
                    {
                        valuesRev12Month.Add(new ObservableValue(Convert.ToInt32(_list[i].revenue)));
                        var strLabel = string.Format("{0}/{1}", _list[i].month, _list[i].year);
                        labelsRev12Month.Add(strLabel);
                    }

                    SeriesCollectionRevenue12Month = new SeriesCollection
                    {
                        new LineSeries
                        {
                            Values=new ChartValues<ObservableValue>(valuesRev12Month),
                            DataLabels=true,
                            LabelPoint=point =>point.Y.ToString()
                        }

                    };

                    Revenue12MonthLabels = labelsRev12Month.ToArray();

                    //ve bieu do doanh thu trong thang
                    //them du lieu vao db
                    var queryRev1Month = from p in purchases
                                         where today.Month == ((DateTime)p.CreatedAt).Month && today.Year == ((DateTime)p.CreatedAt).Year && (p.Status == 2 || p.Status == 4)//da thanh toán
                                         group p by EntityFunctions.TruncateTime(p.CreatedAt) into g
                                         select new reportRevenue1Month
                                         {
                                             date = (DateTime)g.Key,
                                             revenue = (int)g.Sum(x => x.Total)
                                         };
                    var labelsRev1Month = new List<string>();
                    List<ObservableValue> valuesRev1Month = new List<ObservableValue>();

                    if (queryRev1Month.Count() == 0)
                    {
                        MessageBox.Show("Không có dữ liệu từ database!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    foreach (var x in queryRev1Month)
                    {
                        valuesRev1Month.Add(new ObservableValue(Convert.ToInt32(x.revenue)));
                        labelsRev1Month.Add(x.date.ToString("dd/MM/yyyy"));
                    }

                    SeriesCollectionRevenue1MonthCurrent = new SeriesCollection
                    {
                        new ColumnSeries
                        {
                            Values=new ChartValues<ObservableValue>(valuesRev1Month),
                            DataLabels=true,
                            LabelPoint=point =>point.Y.ToString()
                        }

                    };

                    Revenue1MonthLabels = labelsRev1Month.ToArray();

                    DataContext = this;

                    progressBar.IsIndeterminate = false;
                });
            });
            statistical.Start();
        }

        private async void UserControl_Initialized(object sender, EventArgs e)
        {
            //progressBar.IsIndeterminate = true;
            //DateTime today = DateTime.Today;

            //var db = new MyShopEntities(_connectionString);
            //var products = db.Products;
            //var purchases = db.Purchases;
            //var orderDetails = db.OrderDetails;

            //var query = from o in orderDetails
            //            join p in purchases on o.OrderId equals p.Purchase_Id
            //            where today.Month == ((DateTime)p.CreatedAt).Month && today.Year == ((DateTime)p.CreatedAt).Year && (p.Status == 2 || p.Status == 4)//da thanh toán
            //            group o by o.ProductId into g
            //            join p in products on g.FirstOrDefault().ProductId equals p.Product_Id
            //            orderby g.Sum(x => x.Quantity) descending
            //            select new reportBestSeller
            //            {
            //                product_Name = p.Product_Name,
            //                revenue = (int)g.Sum(x => x.Quantity),
            //            };



            
            //await Task.Run(() =>
            //{
            //    Thread.Sleep(2000);
            //});
            //progressBar.IsIndeterminate = false;

            ////ve bieu do banh the hien 5 san pham ban chạy nhat
            //var labels = new List<string>();

            //foreach (var x in query.Take(5))
            //{
            //    PieSeries temp = new PieSeries()
            //    {
            //        DataLabels = true,
            //        Title = x.product_Name,
            //        Values = new ChartValues<int> { x.revenue },
            //        LabelPoint = Point => string.Format("{0}", x.revenue),
            //    };
            //    pieChartProduct.Series.Add(temp);
            //}

           

            ////ve bieu do doanh thu 12 thang gan nhat

            //var queryRev12Month = from o in orderDetails
            //               group o by new { month = ((DateTime)o.CreatedAt).Month, year = ((DateTime)o.CreatedAt).Year } into g
            //               select new reportRevenue12Month
            //               {
            //                   month = g.Key.month,
            //                   year = g.Key.year,
            //                   revenue = (int)g.Sum(x => x.Total)
                               
            //               };
                           
            //var labelsRev12Month = new List<string>();
            //List<ObservableValue> valuesRev12Month = new List<ObservableValue>();

            //if (queryRev12Month.Count() == 0)
            //{
            //    MessageBox.Show("Không có dữ liệu từ database!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            //    return;
            //}

            //var _list = queryRev12Month.ToList();
            //var n = queryRev12Month.Count();
            //for (var i=n-13;i<n;++i)
            //{
            //    valuesRev12Month.Add(new ObservableValue(Convert.ToInt32(_list[i].revenue)));
            //    var strLabel = string.Format("{0}/{1}", _list[i].month, _list[i].year);
            //    labelsRev12Month.Add(strLabel);
            //}

            //SeriesCollectionRevenue12Month = new SeriesCollection
            //{
            //    new LineSeries
            //    {
            //        Values=new ChartValues<ObservableValue>(valuesRev12Month),
            //        DataLabels=true,
            //        LabelPoint=point =>point.Y.ToString()
            //    }

            //};

            //Revenue12MonthLabels = labelsRev12Month.ToArray();

            ////ve bieu do doanh thu trong thang
            ////them du lieu vao db
            //var queryRev1Month = from p in purchases
            //               where today.Month == ((DateTime)p.CreatedAt).Month && today.Year == ((DateTime)p.CreatedAt).Year &&  (p.Status==2 || p.Status==4)//da thanh toán
            //               group p by EntityFunctions.TruncateTime(p.CreatedAt) into g
            //               select new reportRevenue1Month
            //               {
            //                   date = (DateTime)g.Key,
            //                   revenue = (int)g.Sum(x => x.Total)
            //               };
            //var labelsRev1Month = new List<string>();
            //List<ObservableValue> valuesRev1Month = new List<ObservableValue>();

            //if (queryRev1Month.Count() == 0)
            //{
            //    MessageBox.Show("Không có dữ liệu từ database!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            //    return;
            //}

            //foreach (var x in queryRev1Month)
            //{
            //    valuesRev1Month.Add(new ObservableValue(Convert.ToInt32(x.revenue)));
            //    labelsRev1Month.Add(x.date.ToString("dd/MM/yyyy"));
            //}

            //SeriesCollectionRevenue1MonthCurrent = new SeriesCollection
            //{
            //    new ColumnSeries
            //    {
            //        Values=new ChartValues<ObservableValue>(valuesRev1Month),
            //        DataLabels=true,
            //        LabelPoint=point =>point.Y.ToString()
            //    }

            //};

            //Revenue1MonthLabels = labelsRev1Month.ToArray();

            //DataContext = this;
        }

        private void OutOfstockClick_Menu(object sender, RoutedEventArgs e)
        {
            homeReport.Children.Clear();
            homeReport.Children.Add(new ReportProductScreen(_connectionString, "out_of_stock"));
        }
        private void StockingClick_Menu(object sender, RoutedEventArgs e)
        {
            homeReport.Children.Clear();
            homeReport.Children.Add(new ReportProductScreen(_connectionString,"stocking"));
        }
        private void NewCustomer_Menu(object sender, RoutedEventArgs e)
        {
            homeReport.Children.Clear();
            homeReport.Children.Add(new ReportCustomerScreen(_connectionString));
        }
        private void NewOrder_Menu(object sender, RoutedEventArgs e)
        {
            homeReport.Children.Clear();
            homeReport.Children.Add(new ReportOrderScreen(_connectionString));
        }

        private void backWard_Click(object sender, RoutedEventArgs e)
        {
            reportScreen.Children.Clear();
            reportScreen.Children.Add(new HomeScreen(_connectionString));

        }

        private void ReportRevenue_Click(object sender, RoutedEventArgs e)
        {
            homeReport.Children.Clear();
            homeReport.Children.Add(new ReportRevenueScreen(_connectionString));
        }

    }
}
