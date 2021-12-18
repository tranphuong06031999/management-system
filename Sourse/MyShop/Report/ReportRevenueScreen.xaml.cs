using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
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
    /// Interaction logic for ReportRevenueScreen.xaml
    /// </summary>
    public partial class ReportRevenueScreen : UserControl
    {
        public SeriesCollection SeriesCollectionSKU { get; set; }
        public string[] SKULabels { get; set; }
        public SeriesCollection SeriesCollectionRevenue { get; set; }
        public string[] RevenueLabels { get; set; }
        
        public class reportBestSeller
        {
            public reportBestSeller() { }
            public string SKU { get; set; }
            public int revenue { get; set; }
        }

        public class reportRevenue
        {
            public reportRevenue() { }
            public DateTime date { get; set; }
            public int revenue { get; set; }
        }
        string _connectionString;
        public ReportRevenueScreen(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        
        private void ReportRevenueFromTo_Click(object sender, RoutedEventArgs e)
        {
            //lay ngay chon tu datepicker
            DateTime? selectedStartDate = startDate.SelectedDate;
            DateTime? selectedEndDate = endDate.SelectedDate;

            if (selectedStartDate.HasValue==false)
            {
                MessageBox.Show("Chưa chọn ngày bắt đầu!");
            }

            if (selectedEndDate.HasValue==false)
            {
                MessageBox.Show("Chưa chọn ngày kết thúc!");
            }
            
            if (selectedStartDate.HasValue && selectedEndDate.HasValue)
            {
                var db = new MyShopEntities();

                var orderDetails = db.OrderDetails;
                var purchases = db.Purchases;
                var products = db.Products;

                //ve bieu do doanh thu
                var queryRev = from p in purchases
                               where EntityFunctions.TruncateTime(selectedStartDate) <= EntityFunctions.TruncateTime(p.CreatedAt) && EntityFunctions.TruncateTime(selectedEndDate) >= EntityFunctions.TruncateTime(p.CreatedAt) && (p.Status == 2 || p.Status == 4)
                               group p by EntityFunctions.TruncateTime(p.CreatedAt) into g
                               select new reportRevenue
                               {
                                   date = (DateTime)g.Key,
                                   revenue = (int)g.Sum(x => x.Total)
                               };
                var labelsRev = new List<string>();
                List<ObservableValue> valuesRev = new List<ObservableValue>();

                if (queryRev.Count() == 0)
                {
                    MessageBox.Show("Không có dữ liệu từ database!", "Thông báo",MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                foreach (var x in queryRev)
                {
                    valuesRev.Add(new ObservableValue(Convert.ToInt32(x.revenue)));
                    labelsRev.Add(x.date.ToString("dd/MM/yyyy"));
                }

                SeriesCollectionRevenue = new SeriesCollection
                {
                    new LineSeries
                    {
                        Values=new ChartValues<ObservableValue>(valuesRev),
                        DataLabels=true,
                        LabelPoint=point =>point.Y.ToString()
                    }

                };

                RevenueLabels = labelsRev.ToArray();

                //ve bieu do mat hang 
                var query = from o in orderDetails join p in purchases on o.OrderId equals p.Purchase_Id
                            where EntityFunctions.TruncateTime(selectedStartDate) <= EntityFunctions.TruncateTime(o.CreatedAt) && EntityFunctions.TruncateTime(selectedEndDate) >= EntityFunctions.TruncateTime(o.CreatedAt) && (p.Status == 2 || p.Status == 4)
                            group o by o.ProductId into g
                            join p in products on g.FirstOrDefault().ProductId equals p.Product_Id
                            orderby g.Sum(x => x.Quantity) descending
                            select new reportBestSeller
                            {
                                SKU = p.SKU,
                                revenue = (int)g.Sum(x => x.Quantity),
                            };


                

                var labels = new List<string>();
                List<ObservableValue> values = new List<ObservableValue>();

                foreach (var x in query)
                {
                    values.Add(new ObservableValue(Convert.ToInt32(x.revenue)));
                    labels.Add(x.SKU);
                }

                SeriesCollectionSKU = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Values=new ChartValues<ObservableValue>(values),
                        DataLabels=true,
                        LabelPoint=point =>point.Y.ToString()
                    }

                };

                SKULabels = labels.ToArray();
              
                DataContext = this;
            }
           
            
        }
    }
}
