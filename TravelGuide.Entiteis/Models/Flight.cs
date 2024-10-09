using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelGuide.Entiteis.Models
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }
        [MaxLength(70)]
        public string Airline { get; set; }
        [MaxLength(70)]
        public string ArivalAirport { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Double TotalPrice { set; get; }

        public string? FlightImage { get; set; }

        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }
        public Location? location { get; set; }

    }
}
