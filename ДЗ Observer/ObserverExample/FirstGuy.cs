using System;

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
