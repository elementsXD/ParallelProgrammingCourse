using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Class4CancellingTasksFirstExampleSingleToken
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            token.Register(() =>
            {
                Console.WriteLine($"{DateTime.Now} : Cancellation has been requested.");
            });
            
            var t = new Task(() =>
            {
                int i = 0;

                while (true)
                {
                    
                    if (token.IsCancellationRequested == true)
                    {
                        break;
                    }
                    Console.WriteLine($"{i++}\t");
                }
            }, token);
            t.Start();

            Task.Factory.StartNew(() =>
            {
                token.WaitHandle.WaitOne();
                Console.WriteLine("Wait handle realeased, cancellation was requested.");
            });

            Console.ReadKey();
            cts.Cancel();

            
            Console.WriteLine("The program done!!!");
            Console.ReadKey();
        }
    }
}
