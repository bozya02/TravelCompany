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
    /// Interaction logic for TourPage.xaml
    /// </summary>
    public partial class TourPage : Page
    {
        public Tour Tour { get; set; }
        public List<Settlement> Settlements { get; set; }
        public List<DB.Type> Types { get; set; }
        public List<Transport> Transports { get; set; }

        public TourPage(Tour tour)
        {
            InitializeComponent();

            Tour = tour;

            cbSettlements.ItemsSource = DataAccess.GetSettlements();
            cbTypes.ItemsSource = DataAccess.GetTypes();
            cbTransports.ItemsSource = DataAccess.GetTransports();

            this.DataContext = this;

            cbSettlements.SelectedItem = tour.Settlement;
            cbTransports.SelectedItem = tour.Transport;
            cbTypes.SelectedItem = tour.Type;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            if (App.user.RoleId == 1)
            {
                btnSave.Visibility = Visibility.Hidden;
                btnDelete.Visibility = Visibility.Hidden;
                
                grid.IsEnabled = false;
                btnBuy.IsEnabled = true;

                tbPrice.Text = Tour.PriceLists.LastOrDefault().Price.ToString();
            }
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            Tour.TravelPackageCount -= 1;
            DataAccess.SaveTour(Tour);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Tour.IsDeleted = true;
            DataAccess.SaveTour(Tour);
            NavigationService.GoBack();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Tour.OutgoingPoint = (cbSettlements.SelectedItem as Settlement).Id;
            Tour.TransportId = (cbTransports.SelectedItem as Transport).Id;
            Tour.TypeId = (cbTypes.SelectedItem as DB.Type).Id;

            DataAccess.SaveTour(Tour);
            NavigationService.GoBack();
        }
    }
}
