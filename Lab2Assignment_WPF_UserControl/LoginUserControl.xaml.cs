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
using Lab2Assignment_WPF_UserControl.Classes;
/// <summary>
/// ** Student Name     : Harbin Ramo
/// ** Student Number   : 301046044
/// ** Lab Assignment   : #2 - WPF
/// ** Date (MM/dd/yyy) : 01/24/2020
/// </summary>
namespace Lab2Assignment_WPF_UserControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        // ** Declare variable(s)
        //public ObservableCollection<Login> _loginUserList;

        public LoginUserControl()
        {
            InitializeComponent();

            // ** Prepare ObservableCollection(s)
            //this.PrepareData();
        }

        // ** Initialize ObservableCollection(s)
        //public void PrepareData()
        //{
        //    this._loginUserList = new ObservableCollection<Login>();
        //}

        // ** Getters and Setters for Username
        public string Username 
        {
            get { return (string)GetValue(Login.UsernameProperty); }
            set { SetValue(Login.UsernameProperty, value); }
        }

        // ** Getters and Setters for Username
        public string Password
        {
            get { return (string)GetValue(Login.PasswordProperty); }
            set 
            {
                //SetValue(Login.PasswordProperty, value); 
                SetValue(Login.PasswordProperty, Encrypt.EncryptMe(value)); 
            }
        }

        // ** Check user credentials validity
        //private void LoginButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (this._loginUserList.Where(l => l.Username == this.UsernameTextBox.Text &&
        //        l.Password == Encrypt.EncryptMe(this.PasswordTextBox.Text)).ToArray().Length == 0)
        //    {
        //        MessageBox.Show("Invalid Username/Password.");
        //        return;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Successfully logged in.");
        //        return;
        //    }
        //}

        // ** Register user credentials
        //private void RegisterButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (this._loginUserList.Where(l => l.Username == this.UsernameTextBox.Text && 
        //        l.Password == Encrypt.EncryptMe(this.PasswordTextBox.Text)).ToArray().Length == 0)
        //    {
        //        this._loginUserList.Add(
        //            new Login()
        //            {
        //                Username = this.UsernameTextBox.Text,
        //                Password = Encrypt.EncryptMe(this.PasswordTextBox.Text)
        //            }
        //        );

        //        MessageBox.Show($"{this.UsernameTextBox.Text} " +
        //            $"has been registered.");
        //        return;
        //    }
        //    else
        //    {
        //        MessageBox.Show($"{this.UsernameTextBox.Text} " +
        //            $"is already registered.");
        //        return;
        //    }
        //}
    }
}
