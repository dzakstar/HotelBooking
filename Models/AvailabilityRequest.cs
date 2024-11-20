using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class AvailabilityRequest
    {
        [Required]
        public int? HotelId { get; set; }

        [Required]
        public int? NumberOfGuests { get; set; }

        [Required]
        public DateOnly? ArrivalDate { get; set; }

        [Required]
        public DateOnly? DepartureDate { get; set; }
    }
}
