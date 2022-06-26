using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompany.DB
{
    public partial class Tour
    {
        public List<DateTime?> Dates => Enumerable.Range(0, PriceLists.Count - 1).Select(index =>
                    (PriceLists as List<PriceList>)[index].Date).ToList();
    }
}