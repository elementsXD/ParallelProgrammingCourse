using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class3ParallelProgrammingCourse
{
    internal static class Program
    {
        public static void Write(char c)
        {
            int i = 1000;
            while(i-- > 0)
            {
                Console.Write(c);
            }
        }

        public static void Write(object c)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.Write(c);
            }
        }

        public static int TextLenght(object o)
        {
            Console.WriteLine($"\nTask with id {Task.CurrentId} processing object {o}...");
            return o.ToString().Length;
        }
        
        static void Main(string[] args)
        {
            //Task.Factory.StartNew(() => Write("São Paulo"));

            //var t =  new Task(() => Write("Amazonas"));
            //t.Start();

            //Task.Factory.StartNew(Write,"Santa Catarina");

            string text1 = "Tamanho do texto", text2 = "Comprimento do texto";
            var task1 = new Task<int>(TextLenght, text1);
            task1.Start();

            var task2 = Task.Factory.StartNew(TextLenght, text2);

            Console.WriteLine($"Length of '{text1}' is {task1.Result}");
            Console.WriteLine($"Length of '{text2}' is {task2.Result}");


            Console.WriteLine("Main program done!");
            Console.ReadLine();
        }
    }
}
