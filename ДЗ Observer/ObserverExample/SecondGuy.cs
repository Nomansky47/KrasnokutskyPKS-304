using System;

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
