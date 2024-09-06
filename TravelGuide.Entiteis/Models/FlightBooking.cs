
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelGuide.Entiteis.Models
{
    public class FlightBooking : Booking
    {
        public FlightBooking(int flightId, Flight? flight, int seatNumber, string flightClass,
                             int bookingId, DateTime bookingDate, int userId,
                             double totalPrice, bool bookingStatus)
                             : base(bookingId, bookingDate, userId, totalPrice, bookingStatus)
        {
            FlightId = flightId;
            this.flight = flight;
            SeatNumber = seatNumber;
            Class = flightClass;
        }

        [ForeignKey(nameof(flight))]
        public int FlightId { get; set; }
        public Flight? flight { get; set; }
        public int SeatNumber { get; set; }

        [MaxLength(20)]
        public String Class { get; set; }
    }
}
