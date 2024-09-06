using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Entiteis.Models
{
    public class TravelPackages
    {
        [Key]
        public int PackageId { get; set; }

        [Required]
        [MaxLength(100)]
        public string PackageName { get; set; }

        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Destination { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Duration { get; set; }  // Duration in days

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int MaxGuests { get; set; }

        public decimal? Rating { get; set; }

        [MaxLength(255)]
        public string ImageURL { get; set; }

        // Navigation property
        public virtual ICollection<PackageBooking> PackageBookings { get; set; }
    }
}
