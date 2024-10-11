using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelGuide.Entiteis.Models
{
    public class PackageBooking : Booking
    {
        [Key]
        public int BookingId {  get; set; }
        [Required]
        public int? PackageId { get; set; }

        [Required]
        public int NumberOfGuests { get; set; }

        // Foreign key relationships
        [ForeignKey("PackageId")]
        [Required]
        public virtual TravelPackage? TravelPackage { get; set; }

    }
}
