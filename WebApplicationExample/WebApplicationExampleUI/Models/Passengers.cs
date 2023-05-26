using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationExampleUI.Models
{
    public class Passengers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Userlogin { get; set; }
        public string password { get; set; }
        public string UserType { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
