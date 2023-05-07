using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Short
{
    internal class Program
    {
        public static void fortaskB()
        { 
            Console.WriteLine("TaskB is executed");
        }
        public static void fortaskC()
        {
            Console.WriteLine("TaskC is executed");
        }
        static void Main(string[] args)
        {
            Parallel.Invoke(()=> Console.WriteLine("TaskA is executed"), fortaskB, ()=>fortaskC());
            Console.ReadLine(); 
        }
    }
}
