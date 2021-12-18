using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for ReportCustomerScreen.xaml
    /// </summary>
    public partial class ReportCustomerScreen : UserControl
    {
        string _connectionString;
        public ReportCustomerScreen(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;

            Thread reportCustomer = new Thread(delegate ()
            {

                var db = new MyShopEntities(_connectionString);

                Dispatcher.Invoke(() =>
                {
                    progressBar.IsIndeterminate = true;
                    statusLabel.Content = "Latest customer list in 7 days";

                    var endDate = DateTime.Now.Date;
                    var startDate = endDate.AddDays(-7).Date;

                    var query = db.Customers
                        .Where(c => DbFunctions.TruncateTime(startDate) <= DbFunctions.TruncateTime(c.CreateAt) &&
                                DbFunctions.TruncateTime(c.CreateAt) <= DbFunctions.TruncateTime(endDate))
                        .AsEnumerable()
                        .Select(item => new
                        {
                            item.Fullname,
                            item.Tel,
                            item.Address,
                            item.CreateAt
                        })
                        .OrderByDescending(c=>c.CreateAt)
                        .Take(10);


                    customerListView.ItemsSource = query.ToList();
                    progressBar.IsIndeterminate = false;
                });
            });
            reportCustomer.Start();
        }

        private async void UserControl_Initialized(object sender, EventArgs e)
        {
            //progressBar.IsIndeterminate = true;
            //statusLabel.Content = "Application is ready";

            //var db = new MyShopEntities(_connectionString);
            
            //await Task.Run(() =>
            //{
            //    Thread.Sleep(100);
            //});
            //progressBar.IsIndeterminate = false;

            //var endDate = DateTime.Now.Date;
            //var startDate = endDate.AddDays(-7).Date;

            ////var query = from customer in customers
            ////            where DbFunctions.TruncateTime(startDate.Date) <= DbFunctions.TruncateTime(customer.CreateAt)
            ////            && DbFunctions.TruncateTime(customer.CreateAt) <= DbFunctions.TruncateTime(endDate.Date)
            ////            select new
            ////            {
            ////                Name = customer.Fullname,
            ////                Tel = customer.Tel,
            ////                Address = customer.Address
            ////            };

            //var query = db.Customers
            //    .Where(c => DbFunctions.TruncateTime(startDate) <= DbFunctions.TruncateTime(c.CreateAt) &&
            //            DbFunctions.TruncateTime(c.CreateAt) <= DbFunctions.TruncateTime(endDate))
            //    .AsEnumerable()
            //    .Select(item => new
            //    {
            //        item.Fullname,
            //        item.Tel,
            //        item.Address
            //    })
            //    .Take(10);


            //customerListView.ItemsSource = query.ToList();
        }
    }
}
