using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Class4PPCancellingTasksMultipleToken
{
    class Program
    {
        static void Main(string[] args)
        {
            var planned = new CancellationTokenSource();
            var preventive = new CancellationTokenSource();
            var emergency = new CancellationTokenSource();

            var paranoid = CancellationTokenSource.CreateLinkedTokenSource(planned.Token, preventive.Token, emergency.Token);
            Task.Factory.StartNew(() =>
            {
                int i = 0;

                while (true)
                {
                    paranoid.Token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++}\t");
                    Thread.Sleep(1000);
                }
                
            }, paranoid.Token);

            Console.ReadKey();
            emergency.Cancel();

            Console.ReadKey();
            Console.WriteLine("The program done.");
        }
    }
}
