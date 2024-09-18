
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelGuide.Entiteis.Models
{
    public class FlightBooking : Booking
    {
        [Key]
        public int BookingId { get; set; }
        [ForeignKey(nameof(Flight))]
        public int FlightId { get; set; }
        public Flight? Flight { get; set; }
        public int SeatNumber { get; set; }

        [MaxLength(20)]
        public string Class { get; set; }

    }
}
