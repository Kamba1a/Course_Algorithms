using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ольга Назарова

namespace Lesson4
{
    class Program
    {
        /// <summary>
        /// Вывод на экран двумерного массива
        /// </summary>
        /// <param name="board"></param>
        /// <param name="startRow">стартовогое значение строки</param>
        /// <param name="startColumn">стартовое значение столбца</param>
        static void PrintArray(ref int[,] board, int startRow, int startColumn)
        {
            for (int row = startRow; row <= board.GetUpperBound(0); row++)
            {
                for (int col = startColumn; col <= board.GetUpperBound(1); col++)
                {
                    Console.Write($"{board[row, col],4}");
                }
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Случайно расставляет нули и единицы на "карте" доски
        /// </summary>
        /// <param name="board"></param>
        /// <param name="size1"></param>
        /// <param name="size2"></param>
        static void RandomBoardMap(ref int[,] board)
        {
            Random rand = new Random();
            for (int row = 1; row <= board.GetUpperBound(0); row++)
            {
                for (int col = 1; col <= board.GetUpperBound(1); col++)
                {
                    board[row, col] = rand.Next(7);
                    if (board[row, col] != 0) board[row, col] = 1;
                }
            }
            board[1, 1] = 1;
        }

        static void Main(string[] args)
        {
            #region Задание 1:
            //1. *Количество маршрутов с препятствиями. Реализовать чтение массива с препятствием и нахождение количество маршрутов.
            
            int size1 = 8;
            int size2 = 8;
            int[,] board1 = new int[size1 + 1, size2 + 1];

            RandomBoardMap(ref board1);

            int MovesAmount(int row, int col) //считает количество возможных ходов
            {
                if (row == 1 && col == 1) return 1;
                else return board1[row - 1, col] + board1[row, col - 1];
            }

            for (int row = 1; row<=size1; row++)
            {
                for (int col = 1; col<=size2; col++)
                {
                    if (board1[row, col] != 0)
                    {
                        board1[row, col] = MovesAmount(row, col);
                    }
                }
            }
            Console.WriteLine("Маршруты с препятствиями:");
            PrintArray(ref board1, 1,1);
            Console.WriteLine("");
            
            #endregion

            #region Задание 2:
            //Решить задачу о нахождении длины максимальной подпоследовательности с помощью матрицы.
            //int[] sequence1 = { 1, 2, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[] sequence2 = { 1, 2, 2, 3, 10, 7, 8, 11, 9 };

            int[] sequence1 = { 4, 5, 7, 4, 7, 6, 7 };
            int[] sequence2 = { 6, 7, 4, 6, 7, 4, 6, 7, 6, 7 };
            int[,] arr = new int[sequence2.Length + 1, sequence1.Length + 1];

            for (int col = 1; col <= sequence1.Length; col++)
            {
                arr[0, col] = sequence1[col - 1]; //заполняем первую строку массива первой последовательностью
            }

            for (int row = 1; row <= sequence2.Length; row++)
            {
                arr[row, 0] = sequence2[row - 1]; //заполняем первый столбец массива второй последовательностью
            }
            
            int seqLen1 = 0;
            int seqLen2 = 0;

            int rowValue = 1;
            for (int col = 1; col <= arr.GetUpperBound(1); col++)
            {
                for (int row = rowValue; row <= arr.GetUpperBound(0); row++)
                {
                    if (arr[0, col] == arr[row, 0]) //сравнение первой последовательности со второй
                    {
                        seqLen1++;
                        arr[row, col] = seqLen1;
                        col++;
                        rowValue = row + 1;
                        if (row > arr.GetUpperBound(0) || col > arr.GetUpperBound(1)) break;
                    }
                }
            }
            Console.WriteLine("Сравнение первой последовательности со второй:");
            PrintArray(ref arr, 0, 0);
            Console.WriteLine("");

            for (int row = 1; row <= arr.GetUpperBound(0); row++)
            {
                for (int col = 1; col <= arr.GetUpperBound(1); col++)
                {
                    arr[row, col] = 0; //обнуляем подсчет последовательностей в массиве для другого заполнения
                }
            }

            int colValue = 1;
            for (int row = 1; row <= arr.GetUpperBound(0); row++)
            {
                for (int col = colValue; col <= arr.GetUpperBound(1); col++)
                {
                    if (arr[0, col] == arr[row, 0]) //сравнение второй последовательности с первой
                    {
                        seqLen2++;
                        arr[row, col] = seqLen2;
                        row++;
                        colValue = col + 1;
                        if (row > arr.GetUpperBound(0) || col > arr.GetUpperBound(1)) break;
                    }
                }
            }
            Console.WriteLine("Сравнение второй последовательности с первой");
            PrintArray(ref arr, 0, 0);

            if (seqLen1 > seqLen2) Console.WriteLine($"Максимальная последовательность равна {seqLen1}");
            else Console.WriteLine($"Максимальная последовательность равна {seqLen2}");

            //int TotalSequenceCount(int a, int b) //рекурсивное решение из методички (выдает почему-то неверный ответ)
            //{
            //    if (a >= sequence1.Length || b >= sequence2.Length) return 0;
            //    else if (sequence1[a] == sequence2[b]) return 1 + TotalSequenceCount(a + 1, b + 1);
            //    else return Math.Max(TotalSequenceCount(a, b + 1), TotalSequenceCount(a + 1, b));
            //}
            //Console.WriteLine(TotalSequenceCount(sequence1[0], sequence2[0]));
            
            #endregion

            #region Задание 3: (не рабочее - ошибка StackOverflowException)
            //***Требуется обойти конём шахматную доску размером N × M, пройдя через все поля доски по одному разу.
            //Здесь алгоритм решения такой же, как и в задаче о 8 ферзях. Разница только в проверке положения коня.
            /*
            int size1 = 5;
            int size2 = 5;
            int[,] board2 = new int[size1+1, size2+1];

            board2[1, 1] = 1;

            int CheckBoardFill()
            {
                for (int row = 1; row <= size1; row++)
                {
                    for (int col = 1; col <= size2; col++)
                    {
                        if (board2[row, col] == 0) return 0;
                    }
                }
                return 1;
            }

            int TestMove(int x, int y, int lastRow, int lastCol)
            {
                if ((Math.Abs(x - lastRow) == 1) || (Math.Abs(x - lastRow) == 2) || (Math.Abs(y - lastRow) == 1) || (Math.Abs(y - lastRow) == 2))
                {
                    return 1;
                }
            return 0;
            }

            int CheckPossiblityMove(int lastRow, int lastCol)
            {
                for (int row = 1; row <= size1; row++)
                {
                    for (int col = 1; col <= size2; col++)
                    {
                        if (board2[row, col]==0)
                        {
                            if (TestMove(row,col, lastRow, lastCol) == 1) return 1;
                        }
                    }
                }
                return 0;
            }

            int SearchSolution(int n, int lastRow, int lastCol)
            {
                if (CheckBoardFill() == 1) return 1;
                if (CheckPossiblityMove(lastRow, lastCol) == 0) return 0;
                for (int row = 1; row <= size1; row++)
                {
                    for (int col = 1; col <= size2; col++)
                    {
                        if (TestMove(row, col, lastRow, lastCol) == 1)
                        {
                            board2[row, col] = n;
                            if (SearchSolution(n + 1, row, col) == 1) return 1;
                            board2[row, col] = 0;
                        }
                    }
                }
                return 0;
             }

            SearchSolution(1, 1, 1);
            PrintArray(ref board2,1,1);
            */
            #endregion

            Console.ReadKey();
        }
    }
}
