using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ольга Назарова

namespace Lesson2
{
    class Program
    {
        /// <summary>
        /// Вывод сообщения в консоль и возврат введенной строки
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <returns></returns>
        static string MsgIn(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        /// <summary>
        /// Переводит десятичное число в двоичное
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static int TransToBin(int number)
        {
            if (number > 1) return TransToBin(number / 2) * 10 + number % 2;
            else return 1;
        }

        /// <summary>
        /// Возвращает модуль числа
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static int MyABS(int number)
        {
            if (number < 0) return -number;
            else return number;
        }

        /// <summary>
        /// Возведение числа в степень
        /// </summary>
        /// <param name="number">число</param>
        /// <param name="extent">степень</param>
        /// <returns></returns>
        static double MyPow(double number, int extent)
        {
            if (number == 0)
            {
                if (extent == 0) return 1;
                else return 0;
            }
            else if (extent == 0) return 1;
            else
            {
                double rez = number;
                for (int i = 1; i < MyABS(extent); i++)
                {
                    rez = rez * number;
                }
                if (extent < 0) return (double) 1 / rez;
                else return rez;
            }
        }

        /// <summary>
        /// Возведение числа в степень с помощью рекурсии
        /// </summary>
        /// <param name="number"></param>
        /// <param name="extent"></param>
        /// <returns></returns>
        static double MyPowRec(double number, int extent)
        {
            if (number == 0)
            {
                if (extent == 0) return 1;
                else return 0;
            }
            else if (extent == 0) return 1;
            else if (extent < 0)
            {
                if (extent == -1) return (double) (1 / number);
                else return MyPowRec (number, extent + 1) * 1/number;
            }
            else
            {
                if (extent == 1) return number;
                else return MyPowRec(number, extent - 1) * number;
            }
        }

        /// <summary>
        /// Подсчет количества возможных программ в исполнителе "Калькулятор"
        /// </summary>
        /// <param name="startValue">начальное значение</param>
        /// <param name="endValue">целевое значение</param>
        /// <param name="calcPlus">операция плюс "значение"</param>
        /// <param name="calcMult">операция умножить на "значение"</param>
        /// <returns></returns>
        static int CountAmountSolutions(int startValue, int endValue, int calcPlus, int calcMult)
        {
            if (endValue == startValue)
                return 1;
            else if (endValue % calcMult == 0 && endValue / calcMult >= startValue)
                return CountAmountSolutions(startValue, endValue / calcMult, calcPlus, calcMult) + CountAmountSolutions(startValue, endValue - calcPlus, calcPlus, calcMult);
            else if (endValue - calcPlus >= startValue)
                return CountAmountSolutions(startValue, endValue - calcPlus, calcPlus, calcMult);
            else
                return 0;
        }
        
        static void Main(string[] args)
        {
             //1. Реализовать функцию перевода чисел из десятичной системы в двоичную, используя рекурсию.
             Console.WriteLine(TransToBin(int.Parse(MsgIn("Программа переводит десятичное число в двоичное.\nВведите положительное целое число:"))));
            


             //2. Реализовать функцию возведения числа a в степень b:
             Console.WriteLine("\nПрограмма возводит число в степень");
             double N = double.Parse(MsgIn("Введите число:"));
             int e = int.Parse(MsgIn("Введите степень:"));


             //a. Без рекурсии.
             Console.WriteLine($"Используя обычную функцию: {MyPow(N, e)}");


             //b. Рекурсивно.
             Console.WriteLine($"Используя рекурсивную функцию: {MyPowRec(N, e)}");


            //c. *Рекурсивно, используя свойство чётности степени.
            //Не понятно, что это за свойство - даже в поисковике по запросу "свойство четности степени" не выдает такого свойства среди прочих.



            //3. **Исполнитель «Калькулятор» преобразует целое число, записанное на экране. У исполнителя две команды, каждой присвоен номер:1.Прибавь 1; 2.Умножь на 2.
            //Первая команда увеличивает число на экране на 1, вторая увеличивает его в 2 раза. Определить, сколько существует программ, которые преобразуют число 3 в число 20:
            Console.WriteLine("\nПрограмма выводит количество возможных программ в исполнителе \"Калькулятор\"");
            int startValue = 3;
            int endValue = 20;
            int calcPlus = 1;
            int calcMult = 2;
            

            //а. Решить с использованием массива.
            int[] arr = new int[endValue + 1];
            arr[startValue] = 1;

            for (int i = startValue + calcPlus; i <= endValue; i = i + calcPlus)
            {
                if (i > endValue - calcPlus) i = endValue;

                if (i % calcMult == 0 && i / calcMult >= startValue)
                {
                    arr[i] = arr[i - calcPlus] + arr[i / calcMult];
                }
                else
                {
                    arr[i] = arr[i - calcPlus];
                }
            }
            Console.WriteLine($"Решение с помощью массива:\nКоличество программ для преобразования {startValue} в {endValue} равно {arr[endValue]}");
            //for (int i = 0; i < end+1; i++) Console.Write($"{arr[i]} "); //вывод на экран массива
            

            //b. *С использованием рекурсии.
            Console.WriteLine($"Решение с помощью рекурсивной функции:\nКоличество программ для преобразования {startValue} в {endValue} равно {CountAmountSolutions(startValue, endValue, calcPlus, calcMult)}");



            Console.ReadKey();
        }
    }
}
