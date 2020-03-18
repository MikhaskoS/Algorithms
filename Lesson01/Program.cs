using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utility;

namespace Lesson01
{
    class Program
    {
        static void Main()
        {
            Task1();
            Input.Clear();

            Task2(1.54, 8, 4.57, 1.89);
            Input.Clear();

            Task3();
            Input.Clear();

            Task14();
        }

        /* Ввести вес и рост человека. Рассчитать и вывести индекс массы тела по формуле I=m/(h*h); 
         * где m-масса тела в килограммах, h - рост в метрах.*/
        public static void Task1()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ИМТ ");
            double weight = Input.InputCorrectData("Вес / кг", 0, 300);
            double height = Input.InputCorrectData("Рост / м", 0, 3);

            double bmi = weight / (height * height);
            double correct = 0;
            if (bmi < 18.51)
            {
                double w_norm = 18.55 * (height * height);
                correct = w_norm - weight;
            }
            else if (bmi > 24.99)
            {
                double w_norm = 24.99 * (height * height);
                correct = w_norm - weight;
            }

            string verdict = "Очень резкое ожирение";
            if (bmi < 16) verdict = "Выраженный дефицит массы тела";
            else if (bmi < 18.5) verdict = "Недостаточная (дефицит) масса тела";
            else if (bmi < 24.99) verdict = "Норма";
            else if (bmi < 30) verdict = "Избыточная масса тела (предожирение)";
            else if (bmi < 35) verdict = "Ожирение";
            else if (bmi < 40) verdict = "Ожирение резкое";

            Console.WriteLine("ИМТ: {0}", bmi.ToString("F02"));
            Console.WriteLine(verdict);
            Console.WriteLine("Необходимая корректировка веса: {0} кг",
                correct.ToString("F01"));
        }

        /*Найти максимальное из четырех чисел. Массивы не использовать.*/
        public static double Task2(double d1, double d2, double d3, double d4)
        {
            double d_max = d1;
            if (d2 > d_max) d_max = d2;
            if (d3 > d_max) d_max = d3;
            if (d4 > d_max) d_max = d4;

            Console.WriteLine($"Максимум из [{d1} {d2} {d3} {d3}] = {d_max}");

            return d_max;
        }

        /*  Написать программу обмена значениями двух целочисленных переменных:
            a. с использованием третьей переменной;
            b. *без использования третьей переменной.*/
        public static void Task3()
        {
            //------------------------------------------
            //  с использованием 3 переменной 
            //------------------------------------------
            float a = 12.5f;
            float b = 50.0f;
            Console.WriteLine("Исходные: a = {0} b = {1}", a, b);   // 12.5    50.0

            float t = a;
            a = b;
            b = t;
            Console.WriteLine("Перестановка: a = {0} b = {1}", a, b);   // 50.0    12.5
            //------------------------------------------
            //  только 2 переменные       
            //------------------------------------------
            Console.WriteLine("Исходные: a = {0} b = {1}", a, b);
            a = b + a;
            b = a - b;
            a -= b;
            Console.WriteLine("Перестановка: a = {0} b = {1}", a, b);   // 50.0    12.5

            //------------------------------------------
            //  частный случай для int переменных
            //------------------------------------------
            int iA = 50;
            int iB = 100;
            Console.WriteLine("Исходные: a = {0} b = {1}", iA, iB);   // 50   100

            iA ^= iB;
            iB ^= iA;
            iA ^= iB;
            Console.WriteLine("Перестановка: a = {0} b = {1}", iA, iB);   // 100   50
        }

        /* *Автоморфные числа. Натуральное число называется автоморфным, если оно равно 
         * последним цифрам своего квадрата. Например, 25*25 = 625. Напишите программу, 
         * которая вводит натуральное число N и выводит на экран все автоморфные числа, 
         * не превосходящие N.*/
        public static void Task14()
        {
            int N = 1_000_000;
            for (int i = 1; i < N; i++)
            {
                if (AutomorphicNumbersTest(i, i * i))
                    Console.WriteLine($"{i}*{i}={i * i}");
            }

            for (int i = 1; i < N; i++)
            {
                if (AutomorphicNumbersTestFast(i, i * i))
                    Console.WriteLine($"{i}*{i}={i * i}");
            }
        }
        #region способ 1 (с массивами _ долго)
        public static bool AutomorphicNumbersTest(int s1, int s2)
        {
            if (s2 < s1) return false;

            // заполняем цифрами
            int[] ar1 = GetArray(s1);
            int[] ar2 = GetArray(s2);

            for (int i = 0; i < ar1.Length; i++)
                if (ar1[i] != ar2[i]) return false;

            return true;
        }
        // подсчет количества цифр для целого числа
        public static int CountNum(int number)
        {
            double d = Math.Log10(number);
            return (int)d + 1;
        }
        // преобразование целого числа в массив из цифр (в обратном порядке)
        public static int[] GetArray(int n)
        {
            int r = CountNum(n);
            int[] ar = new int[r];
            for (int i = 0; i < ar.Length; i++)
            {
                ar[i] = n % 10;
                n = n / 10;
            }

            return ar;
        }
        #endregion

        #region способ 2 (без массивов побыстрее)
        public static bool AutomorphicNumbersTestFast(int s1, int s2)
        {
            if (s2 < s1) return false;
            // разряды чисел
            int r1 = CountNum(s1);   //  25   r1 = 2
            int r2 = CountNum(s2);   //  625  r2 = 3

            int d = 10;
            int n = 1;
            while (n < r1)
            {
                d *= 10;
                n++;
            }

            // 625%(100) = 25 == 25
            if (s2 % d == s1) return true;
            else
                return false;
        }
        #endregion
    }
}
