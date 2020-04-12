using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Sorting
{
    public class Testing
    {
        public delegate void testetMethod<T>(T[] d);

        public static void TestedSort<T>(string msg, T[] d, testetMethod<T> tested)
        {
            long t0 = DateTime.Now.Ticks;
            
            tested(d);

            long t1 = DateTime.Now.Ticks;
            Console.WriteLine($"{msg} время: {(t1 - t0) * 0.0000001f} сек.");
        }
    }
}
