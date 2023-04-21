using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{

    internal partial class Program
    {
        static void Main()
        {
            Guy person = new Guy();
            person.Number = 6777;
            person.Name = "Август";
            person.Myvalidate();
            Console.ReadLine();
        }
    }
}
