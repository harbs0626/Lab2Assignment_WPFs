using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Lab2Assignment_WPF_Client.Classes;

namespace Lab2Assignment_WPF_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Login> _loginUserList;

        public MainWindow()
        {
            InitializeComponent();

            // ** Prepare ObservableCollection(s)
            this.PrepareData();
        }

        // ** Initialize ObservableCollection(s)
        public void PrepareData()
        {
            this._loginUserList = new ObservableCollection<Login>();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (this._loginUserList.Where(l => l.Username == MyLogin.Username &&
                l.Password == MyLogin.Password).ToArray().Length == 0)
            {
                MessageBox.Show("Invalid Username/Password.");
                return;
            }
            else
            {
                MessageBox.Show("Successfully logged in.");
                return;
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (this._loginUserList.Where(l => l.Username == MyLogin.Username &&
                l.Password == MyLogin.Password).ToArray().Length == 0)
            {

                this._loginUserList.Add(
                    new Login()
                    {
                        Username = MyLogin.Username,
                        Password = MyLogin.Password
                    }
                );

                MessageBox.Show($"{MyLogin.Username} " +
                    $"has been registered.");
                return;
            }
            else
            {
                MessageBox.Show($"{MyLogin.Username} " +
                    $"is already registered.");
                return;
            }
        }
    }
}
