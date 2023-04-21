using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
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
            string path = guy.GetType().ToString();
            Console.WriteLine("Название файла: "+ path);
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {

                string text = guy.MySerializer<Guy>();
                Console.WriteLine(text);
                byte[] buffer=Encoding.Default.GetBytes(text);
                 stream.Write(buffer, 0, buffer.Length);  
            }
            Guy serguy = new Guy();
            using (FileStream stream2 = File.OpenRead(path))
            {
                byte[] buffer = new byte[stream2.Length];
               stream2.Read(buffer, 0, buffer.Length);
                string textfrom= Encoding.Default.GetString(buffer);
                serguy= textfrom.MyDeserializer<Guy>();
                Console.WriteLine(serguy.Number + " " + serguy.Name);
                Console.ReadLine();
            }
        }
    }
}
