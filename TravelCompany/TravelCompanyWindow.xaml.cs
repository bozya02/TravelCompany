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

namespace TravelCompany
{
    /// <summary>
    /// Interaction logic for TravelCompanyWindow.xaml
    /// </summary>
    public partial class TravelCompanyWindow : Window
    {
        public TravelCompanyWindow()
        {
            InitializeComponent();

            frame.NavigationService.Navigate(new Pages.AuthorizationPage());

            frame.Navigated += Frame_Navigated;
        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            tbTitle.Text = (frame.Content as Page).Title;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (frame.NavigationService.CanGoBack)
                frame.NavigationService.GoBack();
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (frame.NavigationService.CanGoForward)
                frame.NavigationService.GoForward();
        }
    }
}
