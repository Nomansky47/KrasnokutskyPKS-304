using System.Text.Json;

namespace Serial
{
    public static class Deserial
    {
        public static T MyDeserializer<T>(this string obj)
        {

            return JsonSerializer.Deserialize<T>(obj); 
        }
    }
}
