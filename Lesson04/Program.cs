using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Lesson04
{
    //------------------------------------------------
    // Михасько С.В.
    //------------------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Input.Clear();

            Task3();
            Input.Clear();
        }

        /* Количество маршрутов с препятствиями. 
         * Реализовать чтение массива с препятствием и нахождение количество маршрутов.*/
        private static void Task1()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Количество маршрутов с препятствиями.");

            // 0 - нет прохода
            int[,] mask = {
                { 1,1,1,1,1},
                { 1,1,0,1,1},
                { 1,1,0,1,1},
                { 1,1,1,1,1},
                { 1,1,1,1,1} };
            Console.WriteLine("mask:");
            mask.Print();
            Console.WriteLine(new string('+', 35));
            Obstacles(mask);
        }

        // размер массива задается маской
        public static void Obstacles(int[,] mask)
        {
            int N = mask.GetLength(0);
            int M = mask.GetLength(1);
            int[,] A = new int[N, M];

            for (int j = 0; j < M; j++)
            {
                A[0, j] = (mask[0, j] == 1) ? 1 : 0;
            }

            for (int i = 1; i < N; i++)
            {
                A[i, 0] = (mask[i, 0] == 1) ? 1 : 0;
                for (int j = 1; j < M; j++)
                    A[i, j] = (mask[i, j] == 1) ? A[i, j - 1] + A[i - 1, j] : 0;
            }

            A.Print();
        }
        public static void NoObstacles()
        {
            int N = 5, M = 5;
            int[,] A = new int[N, M];

            for (int j = 0; j < M; j++)
                A[0, j] = 1;

            for (int i = 1; i < N; i++)
            {
                A[i, 0] = 1;
                for (int j = 1; j < M; j++)
                    A[i, j] = A[i, j - 1] + A[i - 1, j];
            }

            A.Print();
        }


        /* Требуется обойти конем шахматную доску размером NxM, пройдя через все поля доски по одному разу. 
         * Здесь алгоритм решения такой же, как в задаче о 8 ферзях. Разница только в проверке положения коня.*/
        private static void Task3()
        {
            Console.WriteLine("Ход конем!");
            Knight(5, 5);
        }

        static int[,] steps_moves = {
        {-1, -2}, {-2, -1}, {-2,  1}, { 1, -2},
        {-1,  2}, { 2, -1}, { 1,  2}, { 2,  1}};

        public static void Knight(int N, int M)
        {
            int[,] board = Utility.Input.GetZerro(N, M);

            int x_start = 0;
            int y_start = 0;

            SetKnight(x_start, y_start, ref board);

            board.Print();
        }

        // можно ли ходить
        static bool CanMove(int x, int y, int[,] board)
        {
            int N = board.GetLength(0);
            int M = board.GetLength(1);
            return x >= 0 && y >= 0 && x < N && y < M && board[x, y] == 0;
        }

        static void SetKnight(int x_pos, int y_pos, ref int[,] board)
        {
            board[x_pos, y_pos] = 1;
            FindPath(x_pos, y_pos, 1, ref board);
        }

        static bool FindPath(int cur_x, int cur_y, int step, ref int[,] board)
        {
            int next_y = 0;
            board[cur_x, cur_y] = step;
            if (step >= board.GetLength(0) * board.GetLength(1)) return true;

            for (int i = 0; i < 8; i++)
            {
                int next_x = cur_x + steps_moves[i, 0];
                next_y = cur_y + steps_moves[i, 1];
                if (CanMove(next_x, next_y, board) &&
                    FindPath(next_x, next_y, step + 1, ref board))
                    return true;
            }

            board[cur_x, cur_y] = 0;
            step++;

            return false;
        }
    }
}
