using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace multithreading_accesing_the_same_datatype
{
    class Program
    {

        static void Main(string[] args)
        {
            int value = 0;
            object _lock = new object();
            Task t = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    lock (_lock)
                    {
                        value++;
                    }

                }
            });

            for (int i = 0; i < 1000000; i++)
            {
                lock (_lock)
                {
                    value--;
                }

            }

            t.Wait();
            Console.WriteLine(value);
        }
    }
}
