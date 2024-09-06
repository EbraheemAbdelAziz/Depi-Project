using System.ComponentModel.DataAnnotations;

namespace TravelGuide.Entiteis.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        [MaxLength(50)]
        public string HotelName { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public int Rating { get; set; }     // Rate from 1 to 5
        
    }
}
