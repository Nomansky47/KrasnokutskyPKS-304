using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public struct Student
{
    public string Surname;
    public int N;
    public float Stat;


}



namespace Long
{
    class Program
    {
        public static void fortask1()
        { Console.WriteLine("Task1 is executed");
        }
        public static void fortask2()
        {
            Console.WriteLine("Task2 is executed");
        }
        public static void Main(string[] args)
        {
        //для конструктора task требуется делегат (лямбда выражение или ссылка на метод)
        Task task1 = new Task(() => fortask1()); 
        task1.Start();
        Task task2 = Task.Factory.StartNew(fortask2);
        Task task3 = Task.Run(() => Console.WriteLine("Task3 is executed"));
        task1.Wait();  
        task2.Wait();   
        lock (task3)
        {
            Console.WriteLine("YES");
        }
        Console.ReadLine();
        }
    }
}