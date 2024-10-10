using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelGuide.Entiteis.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        [ForeignKey(nameof(hotel))]
        public int hotelId { get; set; }
        public Hotel? hotel { get; set; } 
        
        public int RoomNumber { get; set; }

        [MaxLength(50)]
        public string RoomType { get; set; } 
        
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        
        public bool Availability { get; set; }
        [NotMapped]
        public List<Hotel> HotelList { get; set; }

    }
}
