using System.Collections.Generic; 
 
namespace Singleton
{
    public class dbEntities
    {
        private static dbEntities entities;
        public List<Person> Person { get; set; }

        private dbEntities()
        {
            Person = new List<Person>();
        }

        public static dbEntities GetEntities()
        {
            if (entities == null)
                entities = new dbEntities();

            return entities;
        }
    }
}

