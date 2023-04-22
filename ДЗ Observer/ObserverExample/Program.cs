using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ObserverExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Object obj = new Object();
            FirstGuy first=new FirstGuy();
            SecondGuy second=new SecondGuy();
            obj.Add(first);
            obj.Add(second);
            obj.Notify();
            obj.Remove(second);
            Console.WriteLine("второй был убит");
            obj.Notify(); 
            Console.ReadLine();
        }
    }
}
