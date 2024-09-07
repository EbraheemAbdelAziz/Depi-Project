using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Entiteis.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string Passsword { get; set; }
        [MaxLength(50)]
        public string Nationality { get; set; }
        [MaxLength(50)]
        public string HotelName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        [MaxLength(20)]
        public string UserType { get; set; }

        [MaxLength(255)]
        public string Token { get; set; }


        public ICollection<WatchlistItem> WatchlistItems { get; set; }


    }
}
