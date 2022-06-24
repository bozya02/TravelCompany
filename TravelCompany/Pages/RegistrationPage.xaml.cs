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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelCompany.DB;

namespace TravelCompany.Pages
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void btnRegist_Click(object sender, RoutedEventArgs e)
        {
            User user = new User
            {
                Login = tbLogin.Text,
                Password = pbPassword.Password,
                RoleId = 1
            };

            string secondPassword = pbSecondPassword.Password;

            if (user.Password != secondPassword)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка");
                return;
            }

            if (!DataAccess.CheckLogin(user.Login))
            {
                MessageBox.Show("Такой логи занят", "Ошибка");
                return;
            }

            DataAccess.SaveUser(user);

            NavigationService.GoBack();
        }
    }
}
