using System;
using Utility;

//------------------------------------------------
// Михасько С.В.
//------------------------------------------------
namespace Lesson05
{
    class Program
    {
        static void Main()
        {
            Task1();
            Input.Clear();

            Task2();
            Input.Clear();

            Task3();
            Input.Clear();

            Task4();
            Input.Clear();

            Task6();
            Input.Clear();
        }

        /* Реализовать перевод из десятичной в двоичную систему счисления 
         * с использованием стека.*/
        private static void Task1()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int dec = 50;
            int bin = 2;

            MKStack<int> myStack = new MKStack<int>();
            DtoB(dec, myStack, bin);

            Console.WriteLine($"{dec} по основанию {bin}:");
            foreach (var item in myStack)
            {
                Console.Write(item);
            }
        }

        #region

        // Перевод числа из десятичной в b-чную систему счисления 
        private static void DtoB(int Dec, MKStack<int> stack, int b)
        {
            if (Dec > 1)
            {
                int a = Dec / b;
                int r = Dec % b;

                stack.Push(r);

                DtoB(a, stack, b);
            }
            else
            {
                stack.Push(Dec);
            }
        }

        #endregion

        /* Добавить в программу «реализация стека на основе односвязного 
         * списка» проверку на выделение памяти. Если память не выделяется, 
         * то выводится соответствующее сообщение. Постарайтесь создать ситуацию, 
         * когда память не будет выделяться (добавлением большого количества данных).*/
        private static void Task2()
        {
            MKStack<int> _stack = new MKStack<int>();

            while (true)
            {
                try
                {
                    _stack.Push(1);
                    _stack.DisplaySizeOf();
                }
                catch (OutOfMemoryException ex)
                {
                    Console.WriteLine($"Переполнение !!! {ex}");
                    break;
                }
            }
        }

        /* Написать программу, которая определяет, является ли введенная скобочная 
         * последовательность правильной. 
         * Примеры правильных скобочных выражений: (), ([])(), {}(), ([{}]), 
         * неправильных — )(, ())({), (, ])}), ([(]) для скобок [,(,{. */
        private static void Task3()
        {
            // важно соответствие по индексам!
            char[] bracket_in = new char[] { '(', '[', '{' };
            char[] bracket_out = new char[] { ')', ']', '}' };

            string _s = "([{}])";
            Console.WriteLine($"Проверка строки: {_s}");
            Console.WriteLine(CheckBracket(_s, bracket_in, bracket_out));

            _s = "([])()";
            Console.WriteLine($"Проверка строки: {_s}");
            Console.WriteLine(CheckBracket(_s, bracket_in, bracket_out));

            _s = "())({)";
            Console.WriteLine($"Проверка строки: {_s}");
            Console.WriteLine(CheckBracket(_s, bracket_in, bracket_out));

            _s = "[2/{5*(4+7)}]";
            Console.WriteLine($"Проверка строки: {_s}");
            Console.WriteLine(CheckBracket(_s, bracket_in, bracket_out));

        }

        #region

        public static bool CheckBracket(string str, char[] b_in, char[] b_out)
        {
            MKStack<char> _stack = new MKStack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                // открывающую скобку просто добавим в стек
                if (BracketIn(str[i], b_in))
                    _stack.Push(str[i]);
                else
                {
                    int index = BracketOut(str[i], b_out);
                    if (index == -1) continue;

                    // для закрывающей скобки проверим последнюю
                    // если совпадают - удалим из стека
                    if (_stack.Count == 0) return false;
                    if (_stack.Head() == b_in[index])
                        _stack.Pop();
                    else return false;
                }
            }

            foreach (var item in _stack)
            {
                Console.Write(item);
            }

            if (_stack.Count == 0) return true;
            else  return false;
        }

        private static bool BracketIn(char ch, char[] b_in)
        {
            foreach (char _c in b_in)
                if (ch == _c) return true;
            return false;
        }
        private static int BracketOut(char ch, char[] b_out)
        {
            for (int i = 0; i < b_out.Length; i++)
                if (ch == b_out[i]) return i;
            return -1;
        }

        #endregion

        /* Создать функцию, копирующую односвязный список (то есть создает в 
         * памяти копию односвязного списка, не удаляя первый список).*/
        private static void Task4()
        {
            // клонирование односвязного списка на примере стека

            MKStack<int> original = new MKStack<int>();
            original.Push(0);
            original.Push(1);
            original.Push(2);
            original.Push(3);

            Console.WriteLine("Оригинал: ");
            foreach (int item in original)
                Console.Write($"{item} ");

            MKStack<int> stackNew = original.Clone();

            Console.WriteLine("\nКопия: ");
            foreach (int item in stackNew)
                Console.Write($"{item} ");

            Console.WriteLine("\nНекоторые манипуляции... ");
            original.Pop();
            original.Push(4);
            stackNew.Push(5);

            Console.WriteLine("Оригинал: ");
            foreach (int item in original)
                Console.Write($"{item} ");
            Console.WriteLine("\nКопия: ");

            foreach (int item in stackNew)
                Console.Write($"{item} ");
        }


        /* Реализовать очередь. */
        private static void Task6()
        {
            Console.WriteLine("Демонстрация очереди.");
            MKQueue<string> que = new MKQueue<string>();
            que.Enqueue("one");
            que.Enqueue("two");
            que.Enqueue("three");

            foreach (var item in que)
            {
                Console.Write($"{item} ");
            }

            string _s = que.Dequeue();
            Console.WriteLine($"\nИзвлекли: {_s}");

            foreach (var item in que)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
