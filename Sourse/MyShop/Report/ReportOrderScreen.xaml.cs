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
    /// Interaction logic for ReportOrderScreen.xaml
    /// </summary>
    public partial class ReportOrderScreen : UserControl
    {
        string _connectionString;
        public ReportOrderScreen(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;

            Thread reportOrder = new Thread(delegate () {

                var db = new MyShopEntities(_connectionString);

                Dispatcher.Invoke(() => {

                    progressBar.IsIndeterminate = true;
                    statusLabel.Content = "Latest order list";

                    var query = db.Purchases
                        .GroupJoin(
                            db.Customers,
                            p => p.CustomerTel,
                            c => c.Tel,
                            (x, y) => new
                            {
                                Purchase = x,
                                Customer = y
                            })
                        .SelectMany(
                            x => x.Customer.DefaultIfEmpty(),
                            (x, y) => new
                            {
                                Purchase = x.Purchase,
                                Customer = y
                            })
                        .Select(item => new
                        {
                            item.Purchase.Status,
                            item.Purchase.Purchase_Id,
                            item.Purchase.Total,
                            item.Purchase.CreatedAt,
                            item.Customer.Fullname,
                            item.Customer.Tel,
                            Count = item.Purchase.OrderDetails.Count()
                        }).
                          OrderByDescending(p => p.CreatedAt).Take(10);

                    ordersListView.ItemsSource = query.ToList();

                    progressBar.IsIndeterminate = false;
                });
            });
            reportOrder.Start();
        }

        private async void UserControl_Initialized(object sender, EventArgs e)
        {
            //progressBar.IsIndeterminate = true;
            //statusLabel.Content = "Application is ready";

            //await Task.Run(() =>
            //{
            //    Thread.Sleep(100);
            //});
            //progressBar.IsIndeterminate = false;

            //var query = db.Purchases
            //    .GroupJoin(
            //        db.Customers,
            //        p => p.CustomerTel,
            //        c => c.Tel,
            //        (x, y) => new
            //        {
            //            Purchase = x,
            //            Customer = y
            //        })
            //    .SelectMany(
            //        x => x.Customer.DefaultIfEmpty(),
            //        (x, y) => new
            //        {
            //            Purchase = x.Purchase,
            //            Customer = y
            //        })
            //    .Select(item => new
            //    {
            //        item.Purchase.Status,
            //        item.Purchase.Purchase_Id,
            //        item.Purchase.Total,
            //        item.Purchase.CreatedAt,
            //        item.Customer.Fullname,
            //        item.Customer.Tel,
            //        Count = item.Purchase.OrderDetails.Count()
            //    }).
            //      OrderByDescending(p => p.CreatedAt).Take(10);

            //ordersListView.ItemsSource = query.ToList();

        }
    }
}
