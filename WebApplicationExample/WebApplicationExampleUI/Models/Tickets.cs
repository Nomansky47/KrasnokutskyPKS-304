using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationExampleUI.Models
{
    public class Tickets
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketID { get; set; }
        public string Userlogin { get; set; }
        public int FlightID { get; set; }
        public int Row { get; set; }
        public int Seat { get; set; }
        public int Price { get; set; }
        public string Departure_Time { get; set; }

        public virtual Flights Flights { get; set; }
        public virtual Passengers Passengers { get; set; }

    }
}
