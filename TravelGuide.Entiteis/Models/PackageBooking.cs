using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Entiteis.Models
{
    public class PackageBooking : Booking
    {
        [Key]
        public int BookingId {  get; set; }
        [Required]
        public int PackageId { get; set; }

        [Required]
        public int NumberOfGuests { get; set; }

        [Required]

        // Foreign key relationships
        [ForeignKey("PackageId")]
        public virtual TravelPackage TravelPackage { get; set; }

    }
}
