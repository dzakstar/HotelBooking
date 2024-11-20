using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class BookingRequest: IValidatableObject
    {
        [Required, MinLength(5)]
        public string? Name  { get; set; }

        [Required]
        public DateOnly? ArrivalDate { get; set; }

        [Required]
        public DateOnly? DepartureDate { get; set; }

        [Required]
        public int? NumberOfGuests { get; set; }

        [Required]
        public int? RoomId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DepartureDate <= ArrivalDate)
            {
                yield return new ValidationResult("Departure date must be after arrival date.");
            }

            if (NumberOfGuests <= 0)
            {
                yield return new ValidationResult("A booking must be for at least 1 guest.");
            }

            if (RoomId <= 0)
            {
                yield return new ValidationResult("The Room ID must be a positive integer.");
            }
        }
    }
}
