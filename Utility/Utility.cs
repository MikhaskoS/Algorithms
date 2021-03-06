﻿using System;
using System.Globalization;

namespace Utility
{
    public static class Input
    {
        #region Console

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

        #endregion
    }
}
