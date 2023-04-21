using System.ComponentModel.DataAnnotations;
namespace ConsoleApp1
{

   
        public class Guy: IValidatable
        {
            [Required]
            [Range(1, 7)] 
            public int Number { get; set; }
            [MaxLength(7)]
            public string Name { get; set; }
        }
    
}
