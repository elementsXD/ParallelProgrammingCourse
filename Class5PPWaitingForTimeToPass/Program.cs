using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Class5PPWaitingForTimeToPass
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = new Task(() =>
            {
                Console.WriteLine("Press any key to disarm; you have 5 seconds!!!");
                bool canceled = token.WaitHandle.WaitOne(5000);
                Console.WriteLine(canceled ? "\nDisarmed" : "\nBoom!!!! ");

            }, token);
            t.Start();
            
            Console.ReadKey();
            cts.Cancel();


            Console.ReadKey();
            Console.WriteLine("\nMain program done.");
            Console.ReadKey();
        }
    }
}
