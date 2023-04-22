using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverExample
{
    public class FirstGuy:IObserver
    {
     public void Message(IObject obj)
        {
            Console.WriteLine("Получатель 1");
        }
    }
}
