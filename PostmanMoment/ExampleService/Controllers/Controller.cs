using ExampleService.Model;
using Microsoft.AspNetCore.Mvc;

namespace ExampleService.Controllers
{
    public class Controller : ControllerBase
    {
        [HttpGet, Route("swords")]
        public IEnumerable<Sword> Examples()
        {
           Sword FireSword = new()
            {
                Name = "FireSword",
                Id = 1,
                Type="Fire"
            };

            Sword WaterSword = new()
            {
                Name = "WaterSword",
                Id = 2,
                Type = "Water"
            };
            Sword WindSword = new()
            {
                Name = "WindSword",
                Id = 3,
                Type = "Wind"
            };

            List<Sword> SwordList = new()
            {
               WaterSword,
                FireSword,
                WindSword
            };
            SwordsList.Swords= SwordList;
            return SwordList;
        }
        [HttpGet, Route("swords/{id}")] 
        public Sword Example(int id)
        {
            var swords= SwordsList.Swords.Where(p => p.Id == id).FirstOrDefault();
            if (swords != null)
                return swords;
            Sword sword = new()
            {
                Name = "ExampleSword",
                Id = -1,
                Type = "Secret"
            };
            return sword;
        }

    }
}