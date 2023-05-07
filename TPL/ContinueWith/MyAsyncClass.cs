using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Await
{
    public  class MyAsyncClass
    {
        public static async void AsyncDay()
        {
            Task<DayOfWeek> task = Task.Run(() => DateTime.Today.DayOfWeek);
            await task.ContinueWith(t => Console.WriteLine("Сегодня: "+t.Result));
            //по сути мы могли бы использовать task.Result
        }
    }
}
