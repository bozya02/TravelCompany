using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompany.DB
{
    public partial class TravelCompanyEntities
    {
        private static TravelCompanyEntities _context;

        public static TravelCompanyEntities GetContext()
        {
            if (_context == null)
                _context = new TravelCompanyEntities();
            return _context;
        }
    }
}
