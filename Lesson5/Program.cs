using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ольга Назарова

namespace Lesson5
{
    class MyStack
    {
        int maxSize;
        int lastItemNumber;
        char[] myStack;

        public int Length { get { return maxSize; } }
        public int LastItemNumber { get { return lastItemNumber; } }
        public char LastItem { get { return myStack[lastItemNumber]; } }

        public MyStack()
        {
            maxSize = 100;
            lastItemNumber = -1;
            myStack = new char[maxSize];
        }

        public MyStack(int _size)
        {
            maxSize = _size;
            lastItemNumber = -1;
            myStack = new char[maxSize];
        }

        public void Push(char symbol)
        {
            lastItemNumber++;
            myStack[lastItemNumber] = symbol;
        }

        public char Pop()
        {
            if (lastItemNumber > -1)
            {
                char t = myStack[lastItemNumber];
                myStack[lastItemNumber] = '\0';
                lastItemNumber--;
                return t;
            }
            else return '\0';
        }

        public void Print()
        {
            for (int i = 0; i<myStack.Length; i++)
            {
                Console.Write($"{myStack[i]} ");
            }
            Console.WriteLine("");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Задание 3:
            //Написать программу, которая определяет, является ли введённая скобочная последовательность правильной.
            //Примеры правильных скобочных выражений – (), ([])(), {}(), ([{}]), неправильных – )(, ())({), (, ])}), ([(]), для скобок – [, (, {.
            //Например: (2 + (2 * 2)) или[2 /{ 5 * (4 + 7)}].

            string sequence = "[2 /{ 5 * (4 + 7)}]";

            MyStack ms = new MyStack();

            int count = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i].Equals('(') || sequence[i].Equals('[') || sequence[i].Equals('{'))
                {
                    count++;
                    ms.Push(sequence[i]);
                }
                else if (sequence[i].Equals(')'))
                {
                    count--;
                    if (ms.LastItemNumber != -1 && ms.LastItem.Equals('(')) ms.Pop();
                    else break;
                }
                else if (sequence[i].Equals(']'))
                {
                    count--;
                    if (ms.LastItemNumber != -1 && ms.LastItem.Equals('[')) ms.Pop();
                    else break;
                }
                else if (sequence[i].Equals('}'))
                {
                    count--;
                    if (ms.LastItemNumber != -1 && ms.LastItem.Equals('{')) ms.Pop();
                    else break;
                }
            }
            if (count==0) Console.WriteLine("Скобочная последовательность верная");
            else Console.WriteLine("Скобочная последовательность задана не верно");


            Console.ReadKey();
        }
    }
}
