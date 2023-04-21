using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace Serial
{

    public static class Serial
    {
        public static string MySerializer<T>(this T obj)
        {

            return JsonSerializer.Serialize(obj);
        }
    }
}
