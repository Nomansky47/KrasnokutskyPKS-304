using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverExample
{
    public class SecondGuy : IObserver
    {
        public void Message(IObject obj)
        {
            Console.WriteLine("Получатель 2");
        }
    }
}
