using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelGuide.Entiteis.Models
{
    public abstract class Booking
    {
        
        public DateTime BookingDate { set; get; }
        [ForeignKey(nameof(user))] 
        public int UserId { set; get; }
        public User? user { set; get; }
        public Double TotalPrice { set; get; }
        public bool BookingStatus { set; get; }
    }
}
