using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Entiteis.Models
{
    public class RoomBooking : Booking
    {
        [Key]
        public int BookingId { get; set; }

        public int RoomId { get; set; }

        public Room? Room { get; set; }

        public Hotel? Hotel { get; set; }

        public int HotelId { get; set; }
        [Display(Name = "Chick In Date")]
        public DateTime ChickInDate { get; set; }
        [Display(Name = "Chick Out Date")]
        public DateTime ChickOutDate { get; set; }

    }
}
