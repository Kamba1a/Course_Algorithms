using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ольга Назарова

namespace Lesson1
{
    class Program
    {
        /// <summary>
        /// Вывод сообщения в консоль
        /// </summary>
        /// <param name="message">сообщение</param>
        static void Msg(string message)
        {
            Console.WriteLine("\n"+message);
        }

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
        /// Возведение числа в степень
        /// </summary>
        /// <param name="number">число</param>
        /// <param name="extent">степень</param>
        /// <returns></returns>
        static int MyPow(int number, int extent)
        {
            int rez = number;
            for (int i = 1; i < extent; i++)
            {
                rez = rez * number;
            }
            return rez;
        }

        /// <summary>
        /// Проверка числа на четность
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static bool IsEven(int number)
        {
            return (number % 2 == 0);
        }

        /// <summary>
        /// Нахождение частного от деления двух чисел
        /// </summary>
        /// <param name="numerator">Числитель</param>
        /// <param name="denominator">Знаменатель</param>
        /// <returns></returns>
        static int DivisionInteger(int numerator, int denominator)
        {
            int count = 0;
            while (numerator >= denominator)
            {
                numerator = numerator - denominator;
                count++;
            }
            return count;
        }

        /// <summary>
        /// Нахождение остатка от деления двух чисел
        /// </summary>
        /// <param name="numerator">числитель</param>
        /// <param name="denominator">знаменатель</param>
        /// <returns></returns>
        static int DivisionRemainder(int numerator, int denominator)
        {
            while (numerator >= denominator)
            {
                numerator = numerator - denominator;
            }
            return numerator;
        }

        /// <summary>
        /// Подсчет количества десятков в числе
        /// </summary>
        static int CountNumbers(int _number)
        {
            int count = 0;
            while (_number > 0)
            {
                _number = _number / 10;
                count++;
            }
            return count;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                int taskNumber=0;
                bool flag = false;
                while (!flag)
                {
                    flag=int.TryParse(MsgIn("\nДля запуска программы введите номер задания:"), out taskNumber);
                }


                switch (taskNumber)
                {

                    case 1:
                        //Задание 1:
                        //Ввести вес и рост человека. Рассчитать и вывести индекс массы тела по формуле I = m / (h * h),
                        //где m – масса тела в килограммах, h – рост в метрах.

                        Msg("Программа рассчитывает индекс массы тела человека");

                        double m = double.Parse(MsgIn("Введите вес (кг):"));
                        double h = double.Parse(MsgIn("Введите рост (см):"));

                        h = h / 100;
                        double I = m / (h * h);
                        Msg($"Индекс массы тела равен {I:.##}");
                        break;

                    case 2:
                        //Задание 2:
                        //Найти максимальное из четырёх чисел. Массивы не использовать.
                        Msg("Программа находит максимальное из четырех чисел");

                        double n1 = int.Parse(MsgIn("Введите первое число:"));
                        double n2 = int.Parse(MsgIn("Введите второе число:"));
                        double n3 = int.Parse(MsgIn("Введите третье число:"));
                        double n4 = int.Parse(MsgIn("Введите четвертое число:"));

                        if (n1 > n2 && n1 > n3 && n1 > n4)
                        {
                            Msg($"Максимальное число: {n1}");
                        }
                        else if (n2 > n3 && n2 > n4)
                        {
                            Msg($"Максимальное число: {n2}");
                        }
                        else if (n3 > n4)
                        {
                            Msg($"Максимальное число: {n3}");
                        }
                        else
                        {
                            Msg($"Максимальное число: {n4}");
                        }                                         
                        break;

                    case 3:
                        //Задание 3:
                        //Написать программу обмена значениями двух целочисленных переменных:
                        Msg("Программа обмена значениями двух переменных");

                        int num1 = int.Parse(MsgIn("Введите число 1:"));
                        int num2 = int.Parse(MsgIn("Введите число 2:"));

                        // a.С использованием третьей переменной.
                        //int t = num1;
                        //num1 = num2;
                        //num2 = t;

                        // b. * Без использования третьей переменной.
                        num1 = num1 - num2;
                        num2 = num2 + num1;
                        num1 = num2 - num1;

                        Msg($"Теперь число 1 = {num1}, а число 2 = {num2}");
                        break;

                    case 4:
                        //Задание 4:
                        //Написать программу нахождения корней заданного квадратного уравнения.
                        Msg("Программа находит корни квадратного уравнения");
                        int a = int.Parse(MsgIn("Введите число a:"));
                        int b = int.Parse(MsgIn("Введите число b:"));
                        int c = int.Parse(MsgIn("Введите число c:"));
                        double x;
                        double xTwo;

                        if (a == 0)
                        {
                            x = -c / b;
                            Msg($"Уравнение имеет один корень х = {x:f2}");
                        }
                        else
                        {
                            double D = Math.Pow(b, 2) - 4 * a * c;
                            if (D < 0)
                            {
                                Msg("Уравнение не имеет корней");
                            }
                            else
                            {
                                x = (-b + Math.Sqrt(D)) / (2 * a);
                                if (D == 0)
                                {
                                    Msg($"Уравнение имеет один корень x = {x:f2}");
                                }
                                else
                                {
                                    xTwo = (-b - Math.Sqrt(D)) / (2 * a);
                                    Msg($"Корни уравнения x1 = {x:f2}, x2 = {xTwo:f2}");
                                }
                            }
                        }
                        break;

                    case 5:
                        //Задание 5:
                        //С клавиатуры вводится номер месяца. Требуется определить, к какому времени года он относится.
                        Msg("Программа определяет, к какому времени года относится введенный месяц");
                        int month = int.Parse(MsgIn("Введите номер месяца:"));
                        switch (month)
                        {
                            case 12:
                            case 1:
                            case 2: Msg("Зима"); break;
                            case 3:
                            case 4:
                            case 5: Msg("Весна"); break;
                            case 6:
                            case 7:
                            case 8: Msg("Лето"); break;
                            case 9:
                            case 10:
                            case 11: Msg("Осень"); break;
                            default: Msg("Неверный номер месяца"); break;
                        }
                        break;

                    case 6:
                        //Задание 6:
                        //Ввести возраст человека(от 1 до 150 лет) и вывести его вместе со словом «год», «года» или «лет».
                        Msg("Программа определяет, какое слово вывести после возраста (год/года/лет)");
                        int age = int.Parse(MsgIn("Введите возраст:"));

                        if (age == 11 || age == 12 || age == 13 || age == 14)
                        {
                            Msg($"Вам {age} лет"); break;
                        }
                        else
                        {
                            int t = age % 10;
                            switch (t)
                            {
                                case 1: Msg($"Вам {age} год"); break;
                                case 2:
                                case 3:
                                case 4: Msg($"Вам {age} года"); break;
                                case 5:
                                case 6:
                                case 7:
                                case 8:
                                case 9:
                                case 0: Msg($"Вам {age} лет"); break;
                                default: Msg("Неизвестная ошибка"); break;

                            }
                        }
                        break;

                    case 7:
                        //Задание 7:
                        //С клавиатуры вводятся числовые координаты двух полей шахматной доски(x1, y1, x2, y2).
                        //Требуется определить, относятся ли к поля к одному цвету или нет.
                        Msg("Программа определяет, относятся ли поля шахматной доски к одному цвету");

                        int x1 = int.Parse(MsgIn("Введите координату х первого поля"));
                        int y1 = int.Parse(MsgIn("Введите координату у первого поля"));
                        int x2 = int.Parse(MsgIn("Введите координату х второго поля"));
                        int y2 = int.Parse(MsgIn("Введите координату у второго поля"));

                        bool s1 = IsEven(x1);
                        bool c1 = IsEven(y1);
                        bool s2 = IsEven(x2);
                        bool c2 = IsEven(y2);

                        bool sameColor = ((s1 && c1) || (!s1 && !c1)) && ((s2 && c2) || (!s2 && !c2)) || ((s1 && !c1) || (!s1 && c1)) && ((s2 && !c2) || (!s2 && c2));

                        if (sameColor) Msg("Цвет полей одинаковый");
                        else Msg("Цвет полей различается");
                        break;
             
                    case 8:
                        //Задача 8:
                        //Ввести a и b и вывести квадраты и кубы чисел от a до b.
                        Msg("Программа возводит в квадрат и куб числа от A до B");

                        int A = int.Parse(MsgIn("Введите число А (A < B):"));
                        int B = int.Parse(MsgIn("Введите число B (B > A):"));

                        Msg($"Число:\tВ квадрате:\tВ кубе:");
                        for (int i = A; i <= B; i++)
                        {
                            Console.WriteLine($"{i,3}{MyPow(i, 2),12}{MyPow(i, 3),12}");
                        }
                        break;

                    case 9:
                        //Задача 9:
                        //Даны целые положительные числа N и K.
                        //Используя только операции сложения и вычитания, найти частное от деления нацело N на K, а также остаток от этого деления.
                        Msg("Программа находит частное от деления нацело N на K, а также остаток от этого деления.");

                        int N = int.Parse(MsgIn("Введите числитель N:"));
                        int K = int.Parse(MsgIn("Введите знаменатель K:"));

                        Msg($"Частное равно {DivisionInteger(N, K)}\nОстаток равен {DivisionRemainder(N, K)}");
                        break;

                    case 10:
                        //Задача 10:
                        //Дано целое число N > 0. С помощью операций деления нацело и взятия остатка от деления определить,
                        //имеются ли в записи числа N нечётные цифры. Если имеются, то вывести True, если нет – вывести False.
                        Msg("Программа определяет, имеются ли в записи числа N нечетные цифры");

                        N = int.Parse(MsgIn("Введите число N:"));
                        int reminder;
                        flag = false;

                        while (N != 0)
                        {
                            reminder = DivisionRemainder(N, 10);
                            if (!IsEven(reminder))
                            {
                                flag = true;
                                break;
                            }
                            N = DivisionInteger(N, 10);
                        }
                        if (flag) Console.WriteLine(flag);
                        else Console.WriteLine(flag);
                        break;

                    case 11:
                        //С клавиатуры вводятся числа, пока не будет введён 0. Подсчитать среднее арифметическое всех положительных чётных чисел, оканчивающихся на 8.
                        Msg("Программа подсчитывает среднее арифметическое всех положительных чётных чисел, оканчивающихся на 8");

                        int sum = 0;
                        int number;
                        int counter = 0;

                        while (true)
                        {
                            number = int.Parse(MsgIn("Введите число (или введите 0 для подсчета всех введенных чисел):"));
                            if (number == 0) break;
                            if (number > 0 && IsEven(number) && number%10 == 8)
                            {
                                sum = sum + number;
                                counter++;
                            }
                        }
                        double average = (double)sum / counter;

                        Msg($"Среднее арифметическое равно {average:.##}");
                        break;

                    case 12:
                        //Написать функцию нахождения максимального из трёх чисел.
                        Msg("Программа находит максимальное из трех чисел");

                        double MaxOfThreeNumbers(double number1, double number2, double number3)
                        {
                            double max = number1;
                            if (number2 > max) max = number2;
                            if (number3 > max) max = number3;
                            return max;
                        }
                        n1 = double.Parse(MsgIn("Введите первое число:"));
                        n2 = double.Parse(MsgIn("Введите второе число:"));
                        n3 = double.Parse(MsgIn("Введите третье число:"));

                        Msg($"Максимальное число {MaxOfThreeNumbers(n1,n2,n3)}");
                        break;

                    case 13:
                        //Задание 13:
                        //*Написать функцию, генерирующую случайное число от 1 до 100:
                        Msg("Программа генерирует случайное число от 1 до 100.");

                        //a.С использованием стандартной функции rand():
                        //Random rand = new Random();
                        //int numberR = rand.Next(1, 101);

                        //b.Без использования стандартной функции rand():
                        int MyRandom(int min, int max)
                        {
                            max = max+1;
                            int diapason = max-min;
                            DateTime dt = new DateTime();
                            dt = DateTime.Now;
                            return (dt.Millisecond%diapason)+min;
                        }
                        int numberR = MyRandom(1,100);

                        Msg($"Случайное число: {numberR}");
                        break;

                    case 14:
                        //Задание 14:
                        //*Автоморфные числа. Натуральное число называется автоморфным, если оно равно последним цифрам своего квадрата. Например, 25^2 = 625.
                        //Напишите программу, которая получает на вход натуральное число N и выводит на экран все автоморфные числа, не превосходящие N.
                        Msg("Программа выводит автоморфные числа, не превосходящие N");

                        N = int.Parse(MsgIn("Введите натуральное число N"));

                        int Decades(int _number)
                        {
                            return MyPow(10, CountNumbers(_number));
                        }

                        for (int i = 1; i<=N; i++)
                        {
                            if ((i*i)%Decades(i)==i)
                            {
                                Console.Write($"{i} ");
                            }
                        }
                        break;

                    default:
                        Msg("Неверный номер задания");
                        break;
                }
            }
        }
    }
}
