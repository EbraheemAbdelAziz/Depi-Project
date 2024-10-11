using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelGuide.Entiteis.Models
{
    public abstract class Booking
    {
        [Display(Name = "Booking Date")]
        public DateTime BookingDate { set; get; }

        [Display(Name = "Booking Status")]
        public bool BookingStatus { set; get; }
        [ForeignKey("User")]
        public string UserId { get; set; } 
        public AppUser User { get; set; }
    }
}
