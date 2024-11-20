using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class AvailabilityRequest : IValidatableObject
    {
        [Required]
        public int? HotelId { get; set; }

        [Required]
        public int? NumberOfGuests { get; set; }

        [Required]
        public DateOnly? ArrivalDate { get; set; }

        [Required]
        public DateOnly? DepartureDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DepartureDate <= ArrivalDate)
            {
                yield return new ValidationResult("Departure date must be after arrival date.");
            }

            if (NumberOfGuests <= 0)
            {
                yield return new ValidationResult("Number of guests must be at least 1");
            }
        }
    }
}
