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

        /// <summary>
        /// Вывод "доски"
        /// </summary>
        /// <param name="board"></param>
        static void PrintBoard(ref int[,] board)
        {
            for (int i = 1; i < board.GetLength(1); i++)
            {
                for (int j = 1; j < board.GetLength(0); j++)
                {
                    Console.Write($"{board[i, j],4}");
                }
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Проверка возможности хода коня
        /// </summary>
        /// <param name="board"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="horseMoveNumber"></param>
        /// <returns></returns>
        static bool CheckHorseMove(ref int[,] board, int a, int b, int horseMoveNumber)
        {
            for (int i = 1; i < board.GetLength(0); i++)
            {
                for (int j = 1; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == horseMoveNumber - 1)
                    {
                        if (Math.Abs(a - i) == 1 && Math.Abs(b - j) == 2 || Math.Abs(a - i) == 2 && Math.Abs(b - j) == 1) return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Проверка доски на обход конем всех клеток
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        static bool CheckBoardFull(ref int[,] board)
        {
            for (int i = 1; i < board.GetLength(0); i++)
            {
                for (int j = 1; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 0) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Обход конем шахматной доски v1
        /// </summary>
        /// <param name="board"></param>
        /// <param name="horseMoveNumber"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        static bool HorseMovementNonOptimiz(ref int[,] board, int horseMoveNumber, ref int count)
        {
            for (int i = 1; i < board.GetLength(1); i++)
            {
                for (int j = 1; j < board.GetLength(0); j++)
                {
                    count++;
                    if (board[i, j] == 0 && CheckHorseMove(ref board, i, j, horseMoveNumber)) board[i, j] = horseMoveNumber;
                    else continue;
                    if (HorseMovementNonOptimiz(ref board, horseMoveNumber + 1, ref count)) return true;
                    board[i, j] = 0;
                }
            }
            if (CheckBoardFull(ref board)) return true;
            return false;
        }

        /// <summary>
        /// Обход конем шахматной доски v2
        /// </summary>
        /// <param name="board"></param>
        /// <param name="horseMoveNumber"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        static bool HorseMovementOptimiz(ref int[,] board, int horseMoveNumber, int a, int b, ref int count)
        {
            if (a < 1) a = 1;
            for (int i = a; i < board.GetLength(1); i++)
            {
                if (b < 1) b = 1;
                for (int j = b; j < board.GetLength(0); j++)
                {
                    count++;
                    if (board[i, j] == 0 && CheckHorseMove(ref board, i, j, horseMoveNumber)) board[i, j] = horseMoveNumber;
                    else continue;
                    if (HorseMovementOptimiz(ref board, horseMoveNumber + 1, i - 2, j - 2, ref count)) return true;
                    board[i, j] = 0;
                }
            }
            if (CheckBoardFull(ref board)) return true;
            return false;
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

            #region Задание 3:
            //***Требуется обойти конём шахматную доску размером N × M, пройдя через все поля доски по одному разу.
            //Здесь алгоритм решения такой же, как и в задаче о 8 ферзях. Разница только в проверке положения коня.

            int[,] board = new int[6, 6];           //шахматная доска (для быстроты используем 5х5)
            int count = 0;                          //счетчик циклов
            DateTime dt1 = new DateTime();
            DateTime dt2 = new DateTime();

            dt1 = DateTime.Now;

            board[1, 1] = 1;
            HorseMovementOptimiz(ref board, 2, 1, 1, ref count);       //90 280 циклов (443 млн циклов при полной доске 8х8 за 2м1с)
            //HorseMovementNonOptimiz(ref board, 2, ref count);       //124 974 циклов (1 135 млн циклов при полной доске 8х8 за 3м37с)

            dt2 = DateTime.Now;

            Console.WriteLine($"Результат хода коня:");
            PrintBoard(ref board);
            Console.WriteLine($"Количество циклов: {count}");
            Console.WriteLine($"Затраченное время: {dt2 - dt1}");

            #endregion

            Console.ReadKey();
        }
    }
}
