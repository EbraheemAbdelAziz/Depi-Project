using System.ComponentModel.DataAnnotations;

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
        [MaxLength(50)]
        public string DestinationCity { get; set; }
        [MaxLength(50)]
        public string DestinationCountry { get; set; }


    }
}
