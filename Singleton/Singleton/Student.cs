namespace Singleton
{
    public class Person
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public string Surname { get; set; }

        public Person(int id, string name, string surname)
        {
            Id = id;
            Name = name; 
            Surname = surname;
        }
    }
}

