using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TravelGuide.Entiteis.Models
{
    public class TravelPackage
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
        public byte[]? TravelImage { get; set; }

        public virtual ICollection<PackageBooking> PackageBookings { get; set; }
    }
}
