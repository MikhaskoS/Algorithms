using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Input
    {
        // обработка ввода данных
        public static double InputCorrectData(string message, double min = Double.MinValue, double max = Double.MaxValue)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(message + " :");
                try
                {
                    // для устранения неоднозначности десятичного разделителя
                    CultureInfo myCIintl = new CultureInfo("en-US", false);
                    string s = Console.ReadLine();
                    s = s.Replace(',', '.');

                    double k = Convert.ToDouble(s, myCIintl);

                    if (k < min || k > max)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите реальные данные!");
                        continue;
                    }
                    return k;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные введены некорректно!");
                }
            }
        }

        public static void Clear()
        {
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static void Print(this int[] ar)
        {
            foreach (int i in ar)
                Console.Write(i + " ");

            Console.WriteLine();
        }


        public static int[] GetRandomArray(int num, int min, int max)
        {
            int[] ar = new int[num];
            Random rnd = new Random();
            for (int i = 0; i < ar.Length; i++)
                ar[i] = rnd.Next(min, max);

            return ar;
        }

        public static int[] CopyArrray(this int[] ar)
        {
            int[] res = new int[ar.Length];
            for (int i = 0; i < ar.Length; i++)
            {
                res[i] = ar[i];
            }
            return res;
        }
    }
}
