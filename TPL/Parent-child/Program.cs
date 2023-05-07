using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parent_child
{
    internal class Program
    {
        public static void Child2method()
        {
            Console.WriteLine("Child of child");
        }
        static void Main(string[] args)
        {
            var parent = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Parent");
                var child = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Child");
                    var child2 = Task.Factory.StartNew(Child2method, TaskCreationOptions.AttachedToParent);
                },TaskCreationOptions.AttachedToParent);
            });
            parent.Wait();
            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}
