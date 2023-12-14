using System;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace Lesson_12.Tumakov
{
    internal class Program
    {
        /// <summary>
        /// Метод для задачи 1. 
        /// </summary>
        static void CheckThread(object threadNameObj)
        {
            string threadName = (string)threadNameObj;

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{threadName}: {i}");
                Thread.Sleep(300); //чтобы видно было
            }
        }
        public class Refl
        {
            static async Task Main(string[] args)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Задача 1.");
                Console.ForegroundColor = ConsoleColor.White;

                Thread thread1 = new Thread(CheckThread);
                Thread thread2 = new Thread(CheckThread);
                Thread thread3 = new Thread(CheckThread);

                thread1.Start("Первый поток");
                thread2.Start("Второй поток");
                thread3.Start("Третий поток");

                thread1.Join();
                thread2.Join();
                thread3.Join();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nЗадача 2.");
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Введите число, факториал и квадрат которого хотите получить: ");
                int number = int.Parse(Console.ReadLine());

                Task<long> factorialTask = CalculateFactorialAsync(number); //асинхронный факториал

                long squareResult = CalculateSquare(number); // синхронный квадрат

                long factorialResult = await factorialTask;

                Console.WriteLine($"Факториал {number} (асинхронно): {factorialResult}");
                Console.WriteLine($"Квадрат {number} (синхронно): {squareResult}");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nЗадача 3.");
                Console.ForegroundColor = ConsoleColor.White;

                Refl reflInstance = new Refl();

                Type type = reflInstance.GetType();

                MethodInfo[] methods = type.GetMethods();

                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine(method.Name);
                }
            }
        }
        /// <summary>
        /// Методы для задачи 2
        /// </summary>
        static async Task<long> CalculateFactorialAsync(int n)
        {  
            await Task.Delay(8000);

            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
        static long CalculateSquare(int n)
        {
            return n * n;
        }
        /// <summary>
        /// Метод для задачи 3.
        /// </summary>
        public string Output()
        {
            return "Test-Output";
        }

        public int AddInts(int i1, int i2)
        {
            return i1 + i2;
        }
    }
}
