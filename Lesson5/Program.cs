using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ольга Назарова

namespace Lesson5
{
    class MyStack <T>
    {
        int maxSize;
        int lastItemNumber;
        T [] myStack;

        public int MaxSize { get { return maxSize; } }
        public int LastItemNumber { get { return lastItemNumber; } }
        public T LastItem { get
            {
                if (lastItemNumber!=-1) return myStack[lastItemNumber];
                else return default(T);
            }
        }
        public int Length { get { return lastItemNumber + 1; } }

        public MyStack()
        {
            maxSize = 100;
            lastItemNumber = -1;
            myStack = new T[maxSize];
        }

        public MyStack(int _size)
        {
            maxSize = _size;
            lastItemNumber = -1;
            myStack = new T[maxSize];
        }

        public void Push(T symbol)
        {
            lastItemNumber++;
            myStack[lastItemNumber] = symbol;
        }

        public T Pop()
        {
            if (lastItemNumber > -1)
            {
                T t = myStack[lastItemNumber];
                myStack[lastItemNumber] = default(T);
                lastItemNumber--;
                return t;
            }
            else return default(T);
        }

        public void Print()
        {
            for (int i = 0; i<Length; i++)
            {
                Console.Write($"{myStack[i]} ");
            }
            Console.WriteLine("");
        }
    }

    class MyDeq <T> //Задание 6а: Реализовать очередь с использованием массива. Задание 7: Реализовать двустороннюю очередь.
    {
        int maxSize;
        int head;
        int tail;
        T[] myDeq;

        public int MaxSize { get { return maxSize-2; } }
        public T LastItem { get
            {
                if (head != 0) return myDeq[head - 1];
                else return myDeq[maxSize - 1];
            }
        }
        public T FirstItem { get
            {
                if (tail != maxSize - 1) return myDeq[tail + 1];
                else return myDeq[0];
            }
        }
        public int Length { get
            {
                if (head > tail) return head - tail - 1;
                else if (head < tail) return tail - head + maxSize - 1;
                else return 0;
            }
        }

        public MyDeq()
        {
            maxSize = 102;
            myDeq = new T[maxSize];
            head = 0;
            tail = maxSize-1;
        }

        public MyDeq(int _size)
        {
            maxSize = _size+2;
            myDeq = new T[maxSize];
            head = 0;
            tail = maxSize - 1;
        }

        void CheckDeqOverflow()
        {
            if (head == tail) throw new Exception("Deq overflow");
        }

        int CheckDeqEmpty()
        {
            if (head - 1 == tail || (head == 0 && tail == maxSize - 1)) return 1;
            else return 0;
            
        }

        public void PushFront(T symbol)
        {
            myDeq[head] = symbol;
            if (head==maxSize-1) head = 0;
            else head++;
            CheckDeqOverflow();
        }

        public T PopFront()
        {
            if (CheckDeqEmpty()==0)
            {
                if (head == 0) head = maxSize - 1;
                else head--;
                T t = myDeq[head];
                myDeq[head] = default(T);
                return t;
            }
            else return default(T);
        }

        public void PushBack(T symbol)
        {
            myDeq[tail] = symbol;
            if (tail == 0) tail = maxSize - 1;
            else tail--;
            CheckDeqOverflow();
        }

        public T PopBack()
        {
            if (CheckDeqEmpty() == 0)
            {
                if (tail == maxSize-1) tail = 0;
                else tail++;
                T t = myDeq[tail];
                myDeq[tail] = default(T);
                return t;
            }
            else return default(T);
        }

        public void Print()
        {
            if (head > tail)
            {
                for (int i = tail + 1; i < head; i++)
                {
                    Console.Write($"{myDeq[i]} ");
                }
            }
            else
            {
                if (tail != maxSize - 1)
                {
                    int i = tail + 1;
                    while (i < maxSize)
                    {
                        Console.Write($"{myDeq[i]} ");
                        i++;
                    }
                    for (i = 0; i < head; i++)
                    {
                        Console.Write($"{myDeq[i]} ");
                    }
                }
                else
                {
                    for (int i=0; i<head; i++)
                    {
                        Console.Write($"{myDeq[i]} ");
                    }
                }
            }
            Console.WriteLine("");
        }
    }

    class Program
    {
        static int CheckNumber(int number)
        {
            if (number > 47 && number < 58) return 1;
            else return 0;
        }

        static void Main(string[] args)
        {
            #region Задание 3:
            //Написать программу, которая определяет, является ли введённая скобочная последовательность правильной.
            //Примеры правильных скобочных выражений – (), ([])(), {}(), ([{}]), неправильных – )(, ())({), (, ])}), ([(]), для скобок – [, (, {.
            //Например: (2 + (2 * 2)) или[2 /{ 5 * (4 + 7)}].
            
            string sequence = "[2 /{ 5 * (4 + 7)}]";

            MyStack<char> ms = new MyStack<char>();

            int flag = 1;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i].Equals('(') || sequence[i].Equals('[') || sequence[i].Equals('{'))
                {
                    ms.Push(sequence[i]);
                }
                else if (sequence[i].Equals(')'))
                {
                    if (ms.Length == 0)
                    {
                        flag = 0;
                        break;
                    }
                    else if (ms.LastItem.Equals('('))
                    {
                        ms.Pop();
                    }
                    else
                    {
                        flag = 0;
                        break;
                    }
                }
                else if (sequence[i].Equals(']'))
                {
                    if (ms.Length == 0)
                    {
                        flag = 0;
                        break;
                    }
                    else if (ms.LastItem.Equals('['))
                    {
                        ms.Pop();
                    }
                    else
                    {
                        flag = 0;
                        break;
                    }
                }
                else if (sequence[i].Equals('}'))
                {
                    if (ms.Length == 0)
                    {
                        flag = 0;
                        break;
                    }
                    else if (ms.LastItem.Equals('{'))
                    {
                        ms.Pop();
                    }
                    else
                    {
                        flag = 0;
                        break;
                    }
                }
            }
            if (flag==1 && ms.Length == 0) Console.WriteLine($"В записи {sequence} скобочная последовательность верная");
            else Console.WriteLine($"В записи {sequence} скобочная последовательность задана не верно");
            Console.WriteLine("");

            #endregion



            #region Задание 5:
            // *Реализовать алгоритм перевода из инфиксной записи арифметического выражения в постфиксную.
            //Например, "3 * (1 + 22 - 3) + 44 / 2  в  3 1 22 + 3 - * 44 2 / +

            string inflixNote = "3 * (1 + 22 - 3) + 44 / 2";
            string postfixNote = "";

            MyStack<string> stack = new MyStack<string>();

            string tmp;

            for (int i = 0; i < inflixNote.Length; i++)
            {
                if (CheckNumber((int)inflixNote[i]) == 1)
                {
                    tmp = inflixNote[i].ToString();
                    while (i != inflixNote.Length - 1 && CheckNumber((int)inflixNote[i + 1]) == 1)
                    {
                        tmp = tmp + inflixNote[++i];
                    }
                    postfixNote = postfixNote + tmp+ " ";
                }
                else if (inflixNote[i].Equals('('))
                {
                    stack.Push(inflixNote[i].ToString());
                }
                else if (inflixNote[i].Equals('*') || inflixNote[i].Equals('/'))
                {
                    while (stack.Length != 0 && (stack.LastItem.Equals('*') || stack.LastItem.Equals('/'))) postfixNote = postfixNote + stack.Pop() + " ";
                    stack.Push(inflixNote[i].ToString());
                }
                else if(inflixNote[i].Equals('-') || inflixNote[i].Equals('+'))
                {
                    while (stack.Length != 0 && !stack.LastItem.Equals("(")) postfixNote = postfixNote + stack.Pop() + " ";
                    stack.Push(inflixNote[i].ToString());
                }
                else if (inflixNote[i].Equals(')'))
                {
                    while (stack.Length != 0 && !stack.LastItem.Equals("(")) postfixNote = postfixNote + stack.Pop() + " ";
                    stack.Pop();
                }
            }
            while (stack.Length!=0) postfixNote = postfixNote + stack.Pop();

            Console.WriteLine($"Инфиксная запись: {inflixNote}\nПостфиксная запись: {postfixNote}");

            #endregion




            Console.ReadKey();
        }
    }
}
