using DAL.Models;

namespace DAL.Repositories
{
    public class HotelRepository(HotelBookingContext hotelBookingContext)
    {
        public IEnumerable<Hotel> GetByName(string hotelName)
        {
            return hotelBookingContext.Hotels.Where(h => h.Name.Equals(hotelName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
