using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationExampleUI.Models
{
    public class Aircrafts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AircraftID { get; set; }
        public string PlaneType { get; set; }
        public int NumberOfSeats { get; set; }
        public virtual ICollection<Flights> Flights { get; set; }
    }
}
