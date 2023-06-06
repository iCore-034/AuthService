using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace AuthService
{
    /// <summary>
    /// Interaction logic for AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        public AutorizationWindow()
        {
            InitializeComponent();
            Data.AuthSuccess = true;
        }
        private void autorizeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Data.roles.Contains(Data.roles.Where(x =>
                x.Login == loginbox.Text.ToString() &&
                x.Password == pbox.Password.ToString()).ElementAt(0)))
                {
                    Roles rl = Data.roles.Where(x =>
                        x.Login == loginbox.Text.ToString() &&
                        x.Password == pbox.Password.ToString()).ElementAt(0);
                    if (rl.Login == "admin" && rl.Password == "admin")
                    {
                        Data.adminRights = true;
                    }
                    Data.AuthSuccess = false;
                    this.Close();
                }
            }
            catch (Exception) { }
        }
        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(loginbox.Text.ToString() == "" || pbox.Password.ToString() == ""))
            {
                JsonAdd jsonAdd = new JsonAdd(loginbox.Text.ToString(), pbox.Password.ToString());
                loginbox.Text = null;
                pbox.Password = null;
            }
        }
    }
}
