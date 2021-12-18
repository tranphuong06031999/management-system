using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MyShop
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        string _role;
        string _connectionString;
        string _user;
        public Dashboard(string connectionString,string role,string user)
        {
            InitializeComponent();
            _role = role;
            _connectionString = connectionString;
            _user = user;

            var db = new MyShopEntities(_connectionString);
            var account = db.Accounts.Find(_user);
            infoAccount.DataContext = account;
        }
        private void ColorZone_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        public void btnCommands_Click(object sender, RoutedEventArgs e)
        {
            Button curButton = sender as Button;
            if (curButton.Tag.Equals("btnClose"))
            {
                this.Close();
            }
            else if (curButton.Tag.Equals("btnMinim"))
            {
                this.WindowState = WindowState.Minimized;
            }
            else if (curButton.Tag.Equals("btnMaxim"))
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }
            }
        }

        private void Dashboard_Loaded(object sender, RoutedEventArgs e)
        {
            if (_role.Equals("Admin"))
            {
                _main.Navigate(new HomeScreen(_connectionString));
            }
            else
            {
                _main.Navigate(new SaleScreen(_connectionString));
            }
        }
        private void LogOutMenu_Click(object sender, RoutedEventArgs e)
        {
            var screen = new LoginScreen();
            screen.Show();

            this.Close();

        }
    }
}
