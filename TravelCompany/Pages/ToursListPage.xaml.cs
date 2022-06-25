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
    /// Interaction logic for ToursListPage.xaml
    /// </summary>
    public partial class ToursListPage : Page
    {
        public List<Tour> Tours { get; set; }
        public List<Settlement> Settlements { get; set; }
        public List<DB.Type> Types { get; set; }
        public List<Transport> Transports { get; set; }

        public ToursListPage()
        {
            InitializeComponent();

            Tours = DataAccess.GetTours();
            Settlements = DataAccess.GetSettlements();
            Types = DataAccess.GetTypes();
            Transports = DataAccess.GetTransports();

            this.DataContext = this;
        }

        private void btnCreateTour_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TourPage(new Tour()));
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tour = lvTours.SelectedItem as Tour;
            NavigationService.Navigate(new TourPage(tour));
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            if (App.user.RoleId == 1)
            {
                btnCreatePticeList.Visibility = Visibility.Hidden;
                btnCreateTour.Visibility = Visibility.Hidden;
            }
        }
    }
}
