using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelGuide.Entiteis.Models
{
    public abstract class Booking
    {
        [Key]
        public int BookingId;
        public DateTime BookingDate;
        [ForeignKey(nameof(user))]
        public int UserId;
        public User? user;
        public Double TotalPrice;
        public bool BookingStatus;
        public Booking(int bookingId, DateTime bookingDate, int userId,
        double totalPrice, bool bookingStatus)
        {
            BookingId = bookingId;
            BookingDate = bookingDate;
            UserId = userId;
            TotalPrice = totalPrice;
            BookingStatus = bookingStatus;
        }
    }
}
