using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Entiteis.Models
{
    public class PackageBooking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public int PackageId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public int NumberOfGuests { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        // Foreign key relationships
        [ForeignKey("PackageId")]
        public virtual TravelPackages TravelPackage { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
