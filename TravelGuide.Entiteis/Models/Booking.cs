using System.ComponentModel.DataAnnotations.Schema;

namespace TravelGuide.Entiteis.Models
{
    public abstract class Booking
    {
        
        public DateTime BookingDate { set; get; }
        //[ForeignKey(nameof(user))]
        //public int UserId { set; get; }
        //public User? user { set; get; }
        //public Double TotalPrice { set; get; }
        public bool BookingStatus { set; get; }
        [ForeignKey("User")]
        public string UserId { get; set; } 
        public AppUser User { get; set; }
    }
}
