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

        public ToursListPage()
        {
            InitializeComponent();

            Tours = DataAccess.GetTours();

            this.DataContext = this;
        }
    }
}
