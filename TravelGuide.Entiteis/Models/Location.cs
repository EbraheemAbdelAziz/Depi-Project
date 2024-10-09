using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TravelGuide.Entiteis.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [MaxLength(70)]
        public string LocationName { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Please upload an image for the flight.")]
        public IFormFile? ImageFile { get; set; }
    }
}
