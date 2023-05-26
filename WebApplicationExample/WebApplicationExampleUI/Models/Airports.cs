using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationExampleUI.Models
{
    public class Airports
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AirportID { get; set; }
        public string AirportName { get; set; }
        public virtual ICollection<Flights> Flights { get; set; }
    }
}
