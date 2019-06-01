using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Ольга Назарова

namespace Lesson3
{
    class Program
    {
        /// <summary>
        /// Обменивает значения
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
        /// Выводит на экран элементы массива
        /// </summary>
        /// <param name="array"></param>
        static void PrintArray(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++) Console.Write($"{array[i]} ");
            Console.WriteLine($"\n");
        }

        /// <summary>
        /// Заполняет массив случайными числами
        /// </summary>
        /// <param name="array">ссылка на массив</param>
        /// <param name="arrSize">количество элементов массива</param>
        /// <param name="min">минимально возможное число в массиве</param>
        /// <param name="max">максимально возможное число в массиве</param>
        static void FillArrayRandom(ref int[] array, int arrSize, int min, int max)
        {
            Random rand = new Random();
            for (int i = 0; i < arrSize; i++) array[i] = rand.Next(min, max + 1);
        }

        /// <summary>
        /// Сортирует массив "пузырьковым" методом
        /// </summary>
        /// <param name="array">ссылка на массив</param>
        /// <param name="arrSize">количество элементов в массиве</param>
        /// <param name="countOp">счетчик произведенных операций</param>
        static int ArraySortBubbles(ref int[] array, int arraySize)
        {
            int countOp = 0;
            int N = arraySize;
            for (int i = 0; i < arraySize; i++)
            {
                N = N - 1;
                countOp = countOp+4;
                for (int j = 0; j < N; j++)
                {
                    countOp = countOp+5;
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        countOp=countOp+5;
                    }
                }
            }
            return countOp;
        }

        /// <summary>
        /// Неоптимизированная сортировка массива "пузырьковым" методом
        /// </summary>
        /// <param name="array">ссылка на массив</param>
        /// <param name="arrSize">количество элементов в массиве</param>
        /// <param name="countOp">счетчик произведенных операций</param>
        static int ManualsArraySortBubbles(ref int[] array, int arraySize)
        {
            int countOp = 0;
            for (int i = 0; i < arraySize; i++)
            {
                countOp=countOp+3;
                for (int j = 0; j < arraySize - 1; j++)
                {
                    countOp=countOp+6;
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        countOp=countOp+5;
                    }
                }
            }
            return countOp;
        }

        /// <summary>
        /// Сортирует массив шейкерным методом
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrSize"></param>
        /// <returns></returns>
        static int ArraySortShaker(ref int[] array, int arraySize)
        {
            int countOp = 0;
            int R = arraySize;
            int L = 0;
            int flag;

            while (true)
            {
                flag = 1;
                R = R - 1;
                countOp = countOp + 2;
                for (int j = 0; j < R; j++)
                {
                    countOp = countOp + 5;
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        flag = 0;
                        countOp = countOp + 6;
                    }
                }
                for (int j = R; j > L; j--)
                {
                    countOp = countOp + 5;
                    if (array[j] < array[j - 1])
                    {
                        Swap(ref array[j], ref array[j - 1]);
                        flag = 0;
                        countOp = countOp + 6;
                    }
                }
                L = L + 1;
                countOp = countOp + 4;
                if (flag == 1 || L >= R) break;
            }
            return countOp;
        }

        /// <summary>
        /// Бинарный поиск элемента в массиве
        /// </summary>
        /// <param name="array">ссылка на массив</param>
        /// <param name="arraySize">количество элементов в массиве</param>
        /// <param name="searchValue">искомое значение</param>
        /// <returns>Возвращает индекс найденного элемента, либо -1</returns>
        static int ArraySearchBin(ref int[] array, int arraySize, int searchValue)
        {
            int L = 0;
            int R = arraySize - 1;
            int searchPoint;

            while (L <= R)
            {
                searchPoint = (R - L) / 2 + L;
                if (array[searchPoint] == searchValue) return searchPoint;
                else if (array[searchPoint] < searchValue) L = searchPoint + 1;
                else R = searchPoint - 1;
            }
            return -1;
        }

        /// <summary>
        /// Сортирует массив методом вставок
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arraySize"></param>
        /// <returns></returns>
        static int ArraySortInserts(ref int[] array, int arraySize)
        {
            int countOp = 0;
            for (int i = 1; i < arraySize; i++)
            {
                countOp = countOp + 3;
                for (int j = i; j > 0; j--)
                {
                    countOp = countOp + 5;
                    if (array[j] < array[j - 1])
                    {
                        Swap(ref array[j], ref array[j - 1]);
                        countOp = countOp + 5;
                    }
                }
            }
            return countOp;
        }

        /// <summary>
        /// Сортирует массив методом выбора
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arraySize"></param>
        /// <returns></returns>
        static int ArraySortSelection(ref int[] array, int arraySize)
        {
            int countOp = 0;
            int min;
            int flag;

            for (int i = 0; i < arraySize; i++)
            {
                flag = 0;
                min = i;
                countOp = countOp + 5;
                for (int j = i; j < arraySize; j++)
                {
                    countOp = countOp + 4;
                    if (array[j] < array[min])
                    {
                        min = j;
                        flag = 1;
                        countOp = countOp + 2;
                    }
                }
                countOp++;
                if (flag == 1)
                {
                    Swap(ref array[i], ref array[min]);
                    countOp = countOp + 4;
                }
            }

            return countOp;
        }

        static void Main(string[] args)
        {
            int arrSize = 10000;
            int[] mainArray = new int[arrSize];
            FillArrayRandom(ref mainArray, arrSize, 1, 100);
            //Console.WriteLine("Неотсортированный массив:");
            //PrintArray(ref mainArray);


            //Задание 1:
            //Попробовать оптимизировать пузырьковую сортировку.
            //Сравнить количество операций сравнения оптимизированной и неоптимизированной программы.
            //Написать функции сортировки, которые возвращают количество операций.

            int[] arr1 = new int[arrSize];
            mainArray.CopyTo(arr1,0);
            int[] arr2 = new int[arrSize];
            mainArray.CopyTo(arr2, 0);

            Console.WriteLine($"\nПузырьковая сортировка:\nвыполнено примерно {ArraySortBubbles(ref arr1, arrSize)} операций");
            //PrintArray(ref arr1);

            Console.WriteLine($"\nНеоптимизированная пузырьковая сортировка:\nвыполнено примерно {ManualsArraySortBubbles(ref arr2, arrSize)} операций");



            //Задание 2:
            // * Реализовать шейкерную сортировку.

            int[] arr3 = new int[arrSize];
            mainArray.CopyTo(arr3, 0);

            Console.WriteLine($"\nШейкерная сортировка:\nвыполнено примерно {ArraySortShaker(ref arr3, arrSize)} операций");
            //PrintArray(ref arr3);



            //Задание 3:
            //Реализовать бинарный алгоритм поиска в виде функции, которой передаётся отсортированный массив.
            //Функция возвращает индекс найденного элемента или –1, если элемент не найден.


            Console.WriteLine("\nВведите значение для бинарного поиска в массиве:");
            int searchValue = int.Parse(Console.ReadLine());

            int searchResult = ArraySearchBin(ref arr1, arrSize, searchValue);

            if (searchResult==-1) Console.WriteLine("Элемент не найден");
            else Console.WriteLine($"Индекс искомого элемента: {searchResult}");



            //Задание 4:
            //*Подсчитать количество операций для каждой из сортировок и сравнить его с асимптотической сложностью алгоритма.

            int[] arr4 = new int[arrSize];
            mainArray.CopyTo(arr4, 0);
            int[] arr5 = new int[arrSize];
            mainArray.CopyTo(arr5, 0);

            Console.WriteLine($"\nCортировка методом вставок:\nвыполнено примерно {ArraySortInserts(ref arr4, arrSize)} операций");
            //PrintArray(ref arr4);

            Console.WriteLine($"\nСортировка методом выбора:\nвыполнено примерно {ArraySortSelection(ref arr5, arrSize)} операций");
            //PrintArray(ref arr5);

            Console.WriteLine("\nАсимптотическая сложность алгоритмов сортировок равна: n^2 \nФактическая сложность:");
            Console.WriteLine("Для пузырьковой сортировки: \t\t около 6*n^2");
            Console.WriteLine("Для улучш. пузырьковой сортировки: \t около 4*n^2");
            Console.WriteLine("Для шейкерной пузырьковой сортировки: \t около 4*n^2");
            Console.WriteLine("Для сортировки методом вставок: \t около 4*n^2");
            Console.WriteLine("Для сортировки методом выбора: \t\t около 2*n^2");

            Console.WriteLine("Подробнее см. таблицу к ДЗ");


            Console.ReadKey();
        }
    }
}
