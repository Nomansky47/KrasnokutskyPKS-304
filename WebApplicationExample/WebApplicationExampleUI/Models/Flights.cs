using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationExampleUI.Models
{
    public class Flights
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightID { get; set; }
        public string Date { get; set; }
        public int AirportID { get; set; }
        public int AircraftID { get; set; }
        public string Destination { get; set; }
        public string Departure_Time { get; set; }
        public string Arrival_Time { get; set; }

        public virtual Aircrafts Aircrafts { get; set; }
        public virtual Airports Airports { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
