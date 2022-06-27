using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompany.DB;

namespace TravelCompany
{
    internal class DataAccess
    {
        public delegate void NewItemAddedDeledate();
        public static event NewItemAddedDeledate NewItemAddedEvent;

        public static List<Tour> GetTours()
        {
            return TravelCompanyEntities.GetContext().Tours.ToList().FindAll(p => !p.IsDeleted);
        }

        public static void SaveTour(Tour tour)
        {
            if (GetTours().FirstOrDefault(t => t.Id == tour.Id) == null)
                TravelCompanyEntities.GetContext().Tours.Add(tour);

            TravelCompanyEntities.GetContext().SaveChanges();

            NewItemAddedEvent?.Invoke();
        }

        public static List<User> GetUsers()
        {
            return TravelCompanyEntities.GetContext().Users.ToList();
        }

        public static User GetUser(string login, string password)
        {
            return GetUsers().FirstOrDefault(u => u.Login == login && u.Password == password);
        }

        public static bool CheckLogin(string login)
        {
            return GetUsers().Count(u => u.Login == login) == 0;
        }

        internal static void SavePriceList(PriceList priceList)
        {
            if (GetPriceLists().Where(t => t.Id == priceList.Id).Count() == 0)
                TravelCompanyEntities.GetContext().PriceLists.Add(priceList);

            TravelCompanyEntities.GetContext().SaveChanges();

            NewItemAddedEvent?.Invoke();
        }

        public static void SaveUser(User user)
        {
            TravelCompanyEntities.GetContext().Users.Add(user);

            TravelCompanyEntities.GetContext().SaveChanges();
        }

        public static List<DB.Type> GetTypes()
        {
            return TravelCompanyEntities.GetContext().Types.ToList();
        }

        public static List<Country> GetCountries()
        {
            return TravelCompanyEntities.GetContext().Countries.ToList();
        }

        public static List<Settlement> GetSettlements()
        {
            return TravelCompanyEntities.GetContext().Settlements.ToList();
        }

        public static List<Hotel> GetHotels()
        {
            return TravelCompanyEntities.GetContext().Hotels.ToList();
        }

        public static List<Transport> GetTransports()
        {
            return TravelCompanyEntities.GetContext().Transports.ToList();
        }

        public static List<PriceList> GetPriceLists()
        {
            return TravelCompanyEntities.GetContext().PriceLists.ToList();
        }
    }
}
