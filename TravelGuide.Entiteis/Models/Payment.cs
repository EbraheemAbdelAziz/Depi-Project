using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelGuide.Entiteis.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int? RoomBookingId { get; set; }
        public int? FlightBookingId { get; set; }
        public int? PackageBookingId { get; set; }
        [Display(Name = "Room Booking")]
        public RoomBooking? RoomBooking { get; set; }
        [Display(Name = "Flight Booking")]
        public FlightBooking? FlightBooking { get; set; }
        [Display(Name = "Package Booking")]
        public PackageBooking? PackageBooking { get; set; }
        public double Amount { get; set; }
        [MaxLength(50)]
        public string Currency { get; set; }
        [NotMapped]
        public List<string> CurrencyList { get; set; } 

        [MaxLength(50)]
        public string Method { get; set; }
        [NotMapped]
        public List<string> MethodsList { get; set; } 

        [MaxLength(50)]
        [Display(Name = "Payment Date")]
        public DateTime? PaymentDate { get; set; } 
    }
}
