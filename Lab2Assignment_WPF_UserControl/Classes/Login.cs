using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Cryptography;
/// <summary>
/// ** Student Name     : Harbin Ramo
/// ** Student Number   : 301046044
/// ** Lab Assignment   : #2 - WPF
/// ** Date (MM/dd/yyy) : 01/24/2020
/// </summary>
namespace Lab2Assignment_WPF_UserControl.Classes
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public static DependencyProperty UsernameProperty =
            DependencyProperty.Register(
                nameof(Username),
                typeof(string),
                typeof(LoginUserControl),
                new PropertyMetadata("Username"));

        public static DependencyProperty PasswordProperty =
            DependencyProperty.Register(
                nameof(Password),
                typeof(string),
                typeof(LoginUserControl),
                new PropertyMetadata("Password"));


    }
}
