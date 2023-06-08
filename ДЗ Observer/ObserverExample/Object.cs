using System.Collections.Generic;


namespace ObserverExample
{
    public class Object :IObject 
    {
        List<IObserver> guys = new List<IObserver>();
        public void Add(IObserver observer)
        {
            guys.Add(observer);
        }

        public void Remove(IObserver observer)
        {
            guys.Remove(observer);
        }

        public void Notify()
        {
            foreach (var guy in guys)
            {
                guy.Message(this);
            }
        }
    }
}
