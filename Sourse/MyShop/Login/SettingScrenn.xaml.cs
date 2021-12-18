using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
using MyShop.Custom;

namespace MyShop.Login
{
    /// <summary>
    /// Interaction logic for SettingScrenn.xaml
    /// </summary>
    public partial class SettingScrenn : Window
    {
        public SettingScrenn()
        {
            InitializeComponent();
        }
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnOK.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        public void btnCommands_Click(object sender, RoutedEventArgs e)
        {
            Button curButton = sender as Button;
            if (curButton.Tag.Equals("btnClose"))
            {
                this.Close();
            }
        }
        private void ColorZone_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void btnTestConnect_Click(object sender, RoutedEventArgs e)
        {
            var server = nameServerTextBox.Text;
            var database = nameDatabaseTextBox.Text;
            var username = userNameTextBox.Text;
            var password = passwordTextBox.Password;

            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = server;
            builder.InitialCatalog = database;
            builder.UserID = username;
            builder.Password = password;

            var connectionString = builder.ConnectionString;

            // Thử kết nối tới db
            var db = new MyShopEntities(connectionString);
            var (ok, message) = db.TestConnection();

            if (ok)
            {
                var dialog = new Messenge() { Message = message };
                dialog.Sounds();
                dialog.time = 1500;
                dialog.Owner = Window.GetWindow(this);
                dialog.ShowDialog();
                return;
            }
            else
            {
                var dialog = new Messenge() { Message = message };
                dialog.Sounds();
                dialog.time = 1500;
                dialog.Owner = Window.GetWindow(this);
                dialog.ShowDialog();
                return;
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            var server = nameServerTextBox.Text;
            var database = nameDatabaseTextBox.Text;
            var username = userNameTextBox.Text;
            var password = passwordTextBox.Password;

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //Lưu vào app.config 
            config.AppSettings.Settings["server"].Value = server;
            config.AppSettings.Settings["database"].Value = database;
            config.AppSettings.Settings["username"].Value = username;

            //Mã hóa mật khẩu
            var passwordInBytes = Encoding.UTF8.GetBytes(password);
            var entropy = new byte[20];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(entropy);
            }

            var cypherText = ProtectedData.Protect(passwordInBytes, entropy, DataProtectionScope.CurrentUser);

            // Lưu mật khẩu vào config
            config.AppSettings.Settings["password"].Value = Convert.ToBase64String(cypherText);
            // Lưu entropy vào config
            config.AppSettings.Settings["entropy"].Value = Convert.ToBase64String(entropy);

            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
