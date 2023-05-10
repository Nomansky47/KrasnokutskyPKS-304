using System;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person(1, "Никита", "Сенич");
            Person person1 = new Person(2, "Тимофей", "Антясов");
            // dbEntities db = new dbEntities(); создать экземпляр класса не выйдет так как конструктор приватный
            dbEntities.GetEntities().Person.Add(person);
            dbEntities.GetEntities().Person.Add(person1);
            var personList = dbEntities.GetEntities().Person;
            Console.WriteLine($"Id\t\t|\tSurname\t\t|\tName\t\t");
            Console.WriteLine("_______________________________________________________________"); 
            foreach (var p in personList)
            {
                Console.WriteLine($"{p.Id}\t\t|\t{p.Surname}\t\t|\t{p.Name}\t\t");
            }
        }
    }
}

