using System;
using System.IO;
using System.Text.Json;
using Serial;

namespace ConsoleApp2
{

    internal class Program
    {
       
        static void Main()
        {
            Guy guy = new Guy();
            guy.Name = "Andrey";
            guy.Number = 10;
            //string des = guy.MySerializer<Guy>();
            string des = JsonSerializer.Serialize(guy); 
            Console.WriteLine(des);
           // Guy serguy = new Guy();
            //serguy = des.MyDeserializer<Guy>();
            //Console.WriteLine(serguy.Number+" "+ serguy.Name);
            Console.ReadLine(); 
        }
    }
}
