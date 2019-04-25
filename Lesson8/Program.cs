using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ольга Назарова

namespace Lesson8
{
    class Program
    {
        /// <summary>
        /// Вывод массива в консоль
        /// </summary>
        /// <param name="array"></param>
        static void PrintArray(string msg, ref int[] array)
        {
            Console.WriteLine(msg);
            for (int i = 0; i < array.Length; i++) Console.Write($"{array[i]} ");
            Console.WriteLine("");
        }

        /// <summary>
        /// Заполнение массива случайными числами (максимальное возможное число равно размеру массива)
        /// </summary>
        /// <param name="array"></param>
        static void RandArray(ref int[] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++) array[i] = rand.Next(1, array.Length + 1);
        }

        /// <summary>
        /// Сортировка подсчетом
        /// </summary>
        /// <param name="randArr">Массив, требующий сортировки</param>
        /// <param name="maxArrayNumber">Максимальное число в массиве</param>
        static void sortCounter(ref int[] randArr, int maxArrayNumber)
        {
            int[] arrCounter = new int[maxArrayNumber + 1];
            for (int i = 0; i < randArr.Length; i++) arrCounter[randArr[i]]++;
            int k = 0;
            for (int i = 0; i < arrCounter.Length; i++)
            {
                for (int j = 0; j < arrCounter[i]; j++) randArr[k++] = i;
            }
        }

        /// <summary>
        /// Меняет значения местами
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

        /// <summary>
        /// Сортировка Хоара
        /// </summary>
        /// <param name="array"></param>
        /// <param name="tail"></param>
        /// <param name="head"></param>
        static int SortQuick(ref int[] array, int tail, int head)
        {
            int count = 0;
            int firstElem = tail;
            int lastElem = head;
            int supElem = array[tail];
            while (true)
            {
                while (tail < head && array[tail] < supElem)
                {
                    tail++;
                    count++;
                }
                while (head > tail && array[head] >= supElem)
                {
                    head--;
                    count++;
                }
                if (tail >= head) break;
                Swap(ref array[tail], ref array[head]);
                count++;
            }

            if (lastElem - firstElem == 1) return count;

            count++;
            if (array[tail] > supElem)
            {
                if (tail-1 > firstElem) count=count+SortQuick(ref array, firstElem, tail-1);
                if (tail < lastElem) count = count+SortQuick(ref array, tail, lastElem);
            }
            else
            {
                 if (tail > firstElem) count = count + SortQuick(ref array, firstElem, tail);
                if (tail + 1 < lastElem) count = count + SortQuick(ref array, tail + 1, lastElem);
            }
            return count;
        }

        /// <summary>
        /// Сортировка разделенного массива для сортировки слиянием
        /// </summary>
        /// <param name="array"></param>
        /// <param name="count"></param>
        static void SortInSortMerge(ref int[] array, ref int count)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    count++;
                    if (array[i] > array[j])
                    {
                        Swap(ref array[i], ref array[j]);
                        count++;
                    }
                }
            }
        }

        /// <summary>
        /// Сортировка слиянием
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static int SortMerge(ref int[] array)
        {
            int count = 0;

            int[] arrLeft = new int[array.Length / 2];
            int[] arrRight = new int[array.Length - arrLeft.Length];

            for (int i = 0; i < arrLeft.Length; i++)
            {
                arrLeft[i] = array[i];
            }

            for (int i = 0; i < arrRight.Length; i++)
            {
                arrRight[i] = array[i + arrLeft.Length];
            }

            if (arrLeft.Length > 2) count = count + SortMerge(ref arrLeft);
            if (arrRight.Length > 2) count = count + SortMerge(ref arrRight);

            SortInSortMerge(ref arrLeft, ref count);
            SortInSortMerge(ref arrRight, ref count);

            for (int i = 0; i < arrLeft.Length; i++)
            {
                array[i] = arrLeft[i];
            }
            for (int i = 0; i < arrRight.Length; i++)
            {
                array[i + arrLeft.Length] = arrRight[i];
            }

            for (int i = 0; i < arrRight.Length; i++)
            {
                for (int j = i + arrLeft.Length; j > 0; j--)
                {
                    count++;
                    if (array[j] < array[j - 1])
                    {
                        Swap(ref array[j], ref array[j - 1]);
                        count++;
                    }
                }
            }
            return count;
        }

        static int SortShell(ref int[] array, int step)
        {
            int count = 0;

            for (int i = 0; i < step; i++)
            {
                for (int j = i; j < array.Length - step; j = j + step)
                {
                    for (int k = j + step; k > i; k = k - step)
                    {
                        count++;
                        if (array[k] < array[k - step])
                        {
                            Swap(ref array[k], ref array[k - step]);
                            count++;
                        }
                    }
                }
            }
            if (step > 1) count = count + SortShell(ref array, step / 2);
            return count;
        }

        /// <summary>
        /// Сортировка пузырьком
        /// </summary>
        /// <param name="array"></param>
        /// <param name="count"></param>
        static int SortBubbles(ref int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length-1; j++)
                {
                    count++;
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        count++;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Улучшенная сортировка пузырьком
        /// </summary>
        /// <param name="array"></param>
        /// <param name="count"></param>
        static int SortBubblesImp(ref int[] array)
        {
            int count = 0;
            int N = array.Length;
            for (int i = 0; i < array.Length; i++)
            {
                N = N - 1;
                for (int j = 0; j < N; j++)
                {
                    count++;
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        count++;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Шейкерная сортировка
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static int SortShaker(ref int[] array)
        {
            int count = 0;

            int R = array.Length;
            int L = 0;
            int flag;

            while (true)
            {
                flag = 1;
                R = R - 1;
                for (int j = 0; j < R; j++)
                {
                    count++;
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        flag = 0;
                        count++;
                    }
                }
                for (int j = R; j > L; j--)
                {
                    count++;
                    if (array[j] < array[j - 1])
                    {
                        Swap(ref array[j], ref array[j - 1]);
                        flag = 0;
                        count++;
                    }
                }
                L = L + 1;
                if (flag == 1 || L >= R) break;
            }
            return count;
        }

        static void Main(string[] args)
        {
            int ARR_SIZE = 25;
            int[] MAIN_ARR = new int[ARR_SIZE];
            RandArray(ref MAIN_ARR);
            //PrintArray("Массив до сортировки", ref MAIN_ARR);
            DateTime dt1 = new DateTime();
            DateTime dt2 = new DateTime();

            #region Задание 1:
            //Реализовать сортировку подсчётом.
            
            int[] arr1 = new int[ARR_SIZE];
            MAIN_ARR.CopyTo(arr1, 0);

            sortCounter(ref arr1, ARR_SIZE);
            PrintArray("Сортировка подсчетом:", ref arr1);
            
            #endregion



            #region Задание 2:
            //Реализовать быструю сортировку.
            
            int[] arr2 = new int[ARR_SIZE];
            MAIN_ARR.CopyTo(arr2, 0);
            dt1 = DateTime.Now;
            Console.WriteLine($"\nСортировка Хоара.\nКоличество сравнений: {SortQuick(ref arr2, 0, arr2.Length - 1)}");
            dt2 = DateTime.Now;
            Console.WriteLine($"Затраченное время: {(dt2-dt1).TotalMilliseconds}");
            //PrintArray("Массив после сортировки:", ref arr2);

            #endregion

            #region Задание 3:
            //*Реализовать сортировку слиянием.

            int[] arr3 = new int[ARR_SIZE];
            MAIN_ARR.CopyTo(arr3, 0);
            dt1 = DateTime.Now;
            Console.WriteLine($"\nСортировка слиянием.\nКоличество сравнений: {SortMerge(ref arr3)}");
            dt2 = DateTime.Now;
            Console.WriteLine($"Затраченное время: {(dt2 - dt1).TotalMilliseconds}");
            //PrintArray("Массив после сортировки:", ref arr3);

            #endregion

            #region Задание 5:
            //Проанализировать время работы каждого из вида сортировок для 100, 10000, 1000000 элементов. Заполнить таблицу.

            int[] arr4 = new int[ARR_SIZE];
            MAIN_ARR.CopyTo(arr4, 0);
            dt1 = DateTime.Now;
            Console.WriteLine($"\nСортировка Шелла.\nКоличество сравнений: {SortShell(ref arr4, arr4.Length / 2)}");
            dt2 = DateTime.Now;
            Console.WriteLine($"Затраченное время: {(dt2 - dt1).TotalMilliseconds}");
            //PrintArray("Массив после сортировки:", ref arr4);


            int[] arr5 = new int[ARR_SIZE];
            MAIN_ARR.CopyTo(arr5, 0);
            dt1 = DateTime.Now;
            Console.WriteLine($"\nУлучшенная сортировка пузырьком.\nКоличество сравнений: {SortBubblesImp(ref arr5)}");
            dt2 = DateTime.Now;
            Console.WriteLine($"Затраченное время: {(dt2 - dt1).TotalMilliseconds}");
            //PrintArray("Массив после сортировки:", ref arr5);


            int[] arr6 = new int[ARR_SIZE];
            MAIN_ARR.CopyTo(arr6, 0);
            dt1 = DateTime.Now;
            Console.WriteLine($"\nШейкерная сортировка\nКоличество сравнений: {SortBubbles(ref arr6)}");
            dt2 = DateTime.Now;
            Console.WriteLine($"Затраченное время: {(dt2 - dt1).TotalMilliseconds}");
            //PrintArray("Массив после сортировки:", ref arr6);

            #endregion



            Console.ReadKey();
        }
    }
}
