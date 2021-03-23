//Mason bearden
//Threading CW9

using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading
{
    public class FindPiThread
    {
        int darts;
        public int goodDarts;
        Random number;
        public FindPiThread(int darts)
        {
            this.darts = darts;
            number = new Random();
        }
        public void throwDarts()
        {
            for(int i = 0; i < darts; i++)
            {
                double a = number.NextDouble();
                double b = number.NextDouble();
                double c = Math.Pow(a, 2) + Math.Pow(b, 2);
                double d = Math.Sqrt(c);
                if (c <= 1)
                {
                    this.goodDarts++;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int darts, threads, accesor = 0;
            Console.WriteLine("How many throws would you like? ");
            darts = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many threads would you like?");
            threads = Convert.ToInt32(Console.ReadLine());
            List<Thread> thread = new List<Thread>();
            List<FindPiThread> piThreads = new List<FindPiThread>();
            for(int i = 0; i < threads; i++)
            {
                FindPiThread pi = new FindPiThread(darts);
                piThreads.Add(pi);
                Thread StartThread = (new Thread(new ThreadStart(pi.throwDarts)));
                thread.Add(StartThread);
                StartThread.Start();
                Thread.Sleep(16);
       
            }
            foreach(var j in thread) { j.Join(); }
            foreach(var j in piThreads) { accesor += j.goodDarts; }
            
            Console.WriteLine(accesor);
            decimal total = Convert.ToDecimal(darts * threads);
            decimal good = Convert.ToDecimal(accesor);
            decimal final = (4 * (good) / (total));
            Console.WriteLine(final);
            Console.ReadKey();
        }
    }
}
