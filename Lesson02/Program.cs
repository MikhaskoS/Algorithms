using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utility;

//------------------------------------------------
// Михасько С.В.
//------------------------------------------------
namespace Lesson02
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Input.Clear();

            Task2();
            Input.Clear();

            Task3();
            Input.Clear();
        }
        /* Реализовать функцию перевода чисел из десятичной системы в двоичную, 
         * используя рекурсию. */
        public static void Task1()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int dec = 99999;
            int b = 2;
            int[] res = Convert(dec, b);
            Console.WriteLine($"{dec} по основанию {b}:");
            res.Print();
        }
        #region
        /// <summary> Преобразование десятичного числа dec в другую систему по основанию b </summary>
        public static int[] Convert(int dec, int b)
        {
            int flag = -1;
            int[] res = new int[4]; // начальный размер массива
            res[0] = flag;
            DtoB(dec, ref res, b); // например [0011011-10]

            // сдвигаем элементы массива вправо [0011011-10] -> [000011011]
            // выясним положение флага (лучше с конца)
            int index = 0;
            for (int i = res.Length - 1; i > 0; i--)
                if (res[i] == flag) { index = i; break; }
            // производим сдвиг вправо, освободившиеся места заполняем нулями
            int k = 0;
            for (int i = res.Length - 1; i >= 0; i--)
            {
                res[i] = (i > res.Length - index - 1 )? res[index - 1 - k] : 0;
                k++;
            }

            return res;
        }
        private static void DtoB(int Dec, ref int[] bin, int b)
        {
            if (Dec > 1)
            {
                int a = Dec / b;
                int r = Dec % b;
                Push(r, ref bin);

                DtoB(a, ref bin, b);
            }
            else
            {
                Push(Dec, ref bin);
            }
        }
        /// <summary>
        ///  пропихивание элементов в начало массива со сдигом элементов вправо
        /// </summary>
        public static void Push(int a, ref int[] ar)
        {
            if (ar[ar.Length - 1] == -1) // недостаточный размер - добавим 4 позиции
                ar = AddLenght(4, ar);

            for (int i = ar.Length - 1; i > 0; i--)
            {
                ar[i] = ar[i - 1];
            }
            ar[0] = a;
        }
        /// <summary>
        /// Увеличение длины массива с копированием
        /// </summary>
        public static int[] AddLenght(int n, int[] ar)
        {
            int[] res = new int[ar.Length + n];
            for (int i = 0; i < ar.Length; i++)
                res[i] = ar[i];

            return res;
        }
        #endregion
        /* Реализовать функцию возведения числа a в степень b: 
         * a. Без рекурсии. 
         * b. Рекурсивно. 
         * c. *Рекурсивно, используя свойство чётности степени. */
        public static void Task2()
        {
            int a = 3, b = 16;
            Console.WriteLine($"{a} в степени {b}:");
            Console.WriteLine(Pow1(a, b));
            Console.WriteLine(Pow2(a, b));
            Console.WriteLine(Pow3(a, b));
        }
        #region
        // цикл
        public static int Pow1(int a, int b)
        {
            if (b == 0) return 1;
            int res = 1;

            while (b > 0)
            {
                res *= a;
                b--;
            }
            return res;
        }
        // рекурсия
        public static int Pow2(int a, int b)
        {
            if (b == 0) return 1;
            b--;
            return a * Pow2(a, b);
        }
        // рекурсия + четность степени
        public static int Pow3(int a, int b)
        {
            if (b == 0) return 1;
            if (b % 2 == 0)
            {
                b /= 2;
                return Pow3(a, b) * Pow3(a, b);
            }
            else
            {
                b--;
                return a * Pow3(a, b);
            }
        }
        #endregion
        /* Исполнитель «Калькулятор» преобразует целое число, 
         * записанное на экране. У исполнителя две команды, 
         * каждой присвоен номер:  1. Прибавь 1.  2. Умножь на 2. 
         * Первая команда увеличивает число на экране на 1, вторая 
         * увеличивает его в 2 раза. Сколько существует программ, 
         * которые число 3 преобразуют в число 20:       
         * а. С использованием массива.       
         * b. *С использованием рекурсии. */
        public static void Task3()
        {
            int count = 0;
            string s = "";  // для визуализации результата
            int num = 3;
            int target = 20;
            Method(num, target, ref count, s);

            Console.WriteLine($"Количество программ для преобразования {num} к {target}: {count}");
        }
        #region
        /// <summary>
        /// Варианты преобразования числа n в число N операциями +1 и *2
        /// </summary>
        public static void Method(int n, int N, ref int count, string s)
        {
            if (n >= N) return; 

            if (n + 1 <= N)
            {
                AddOne(n, N, ref count, s);
            }
            if (n * 2 <= N)
            {
                MultTwo(n, N, ref count, s);
            }
        }
        private static void AddOne(int n, int N, ref int count, string s)
        {
            string sA = s + "+";
            n++;
            if (n == N) { count++; Console.WriteLine(sA); return; }
            else Method(n, N, ref count, sA);
        }
        private static void MultTwo(int n, int N, ref int count, string s)
        {
            string sM = s + "*";
            n *= 2;
            if (n == N) { count++; Console.WriteLine(sM); return; }
            else Method(n, N, ref count, sM);
        }
        #endregion
    }
}
