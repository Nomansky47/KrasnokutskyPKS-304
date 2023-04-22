
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverExample
{
   public interface IObserver
    {
      void Message(IObject obj);
    }
}
