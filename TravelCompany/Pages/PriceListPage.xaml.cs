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
    /// Interaction logic for PriceListPage.xaml
    /// </summary>
    public partial class PriceListPage : Page
    {
        public List<Tour> Tours { get; set; }
        public PriceListPage()
        {
            InitializeComponent();

            Tours = DataAccess.GetTours();

            this.DataContext = this;

            DataAccess.NewItemAddedEvent += DataAccess_NewItemAddedEvent;
        }

        private void DataAccess_NewItemAddedEvent()
        {
            Tours = DataAccess.GetTours();

            lvPriceList.Items.Refresh();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            PriceList priceList = new PriceList
            {
                TourId = (cbTour.SelectedItem as Tour).Id,
                Date = dpDate.SelectedDate,
                Price = int.Parse(tbPrice.Text)
            };

            DataAccess.SavePriceList(priceList);
        }
    }
}
