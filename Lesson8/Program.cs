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
        static void PrintArray(ref int[] array)
        {
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

        static void Main(string[] args)
        {
            int ARR_SIZE = 25;
            int[] MAIN_ARR = new int[ARR_SIZE];
            RandArray(ref MAIN_ARR);
            Console.WriteLine("Массив до сортировки:");
            PrintArray(ref MAIN_ARR);

            #region Задание 1:
            //Реализовать сортировку подсчётом.

            int[] arr1 = new int[ARR_SIZE];
            MAIN_ARR.CopyTo(arr1, 0);

            sortCounter(ref arr1, ARR_SIZE);

            Console.WriteLine("\nМассив после сортировки подсчетом:");
            PrintArray(ref arr1);

            #endregion



            Console.ReadKey();
        }
    }
}
