using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Ольга Назарова

namespace Lesson7
{
    class MyStack<T>
    {
        int maxSize;
        int lastItemNumber;
        T[] myStack;

        public int MaxSize { get { return maxSize; } }
        public int LastItemNumber { get { return lastItemNumber; } }
        public T LastItem
        {
            get
            {
                if (lastItemNumber != -1) return myStack[lastItemNumber];
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
            for (int i = 0; i < Length; i++)
            {
                Console.Write($"{myStack[i]} ");
            }
            Console.WriteLine("");
        }
    }

    class MyDeq<T>
    {
        int maxSize;
        int head;
        int tail;
        T[] myDeq;

        public int MaxSize { get { return maxSize - 2; } }
        public T LastItem
        {
            get
            {
                if (head != 0) return myDeq[head - 1];
                else return myDeq[maxSize - 1];
            }
        }
        public T FirstItem
        {
            get
            {
                if (tail != maxSize - 1) return myDeq[tail + 1];
                else return myDeq[0];
            }
        }
        public int Length
        {
            get
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
            tail = maxSize - 1;
        }

        public MyDeq(int _size)
        {
            maxSize = _size + 2;
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
            if (head == maxSize - 1) head = 0;
            else head++;
            CheckDeqOverflow();
        }

        public T PopFront()
        {
            if (CheckDeqEmpty() == 0)
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
                if (tail == maxSize - 1) tail = 0;
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
                    for (int i = 0; i < head; i++)
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
        static void PrintArray(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine("");
        }

        //Задание 1:
        //Написать функции, которые считывают матрицу смежности из файла и выводят её на экран.

        /// <summary>
        /// Считывает матрицу смежности из файла
        /// </summary>
        /// <param name="filename">путь к файлу</param>
        /// <param name="array">массив для заполнения</param>
        static void GraphMatrixFromFile(string filename, out int[,] array)
        {
            StreamReader sr = new StreamReader(filename);
            int matrixSize = int.Parse(sr.ReadLine());
            array = new int[matrixSize, matrixSize];
            string[] row = new string[matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                row = sr.ReadLine().Split(' ');
                for (int j = 0; j < matrixSize; j++)
                {
                    array[i, j] = int.Parse(row[j]);
                }
            }
            sr.Close();
        }

        /// <summary>
        /// Выводит матрицу на экран
        /// </summary>
        /// <param name="matrix"></param>
        static void PrintGraphMatrix(ref int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++) Console.Write($"{matrix[i,j]} ");
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            //int[,] graphMatrix; ;
            //GraphMatrixFromFile("graph_matrix.txt", out graphMatrix);
            //PrintGraphMatrix(ref graphMatrix);


            int GRAPH_SIZE = 6;
            int[,] GRAPH = {
            {0,1,0,0,1,0},
            {1,0,1,0,0,1},
            {0,1,0,1,0,1},
            {0,0,1,0,1,0},
            {1,0,0,1,0,1},
            {0,1,1,0,1,0}};



            #region Задание 2:
            //Написать рекурсивную функцию обхода графа в глубину.

            Console.WriteLine("Обход графа в глубину:\n");

            MyStack<int> stack = new MyStack<int>();
            int[] graphTopsActive_1 = new int[GRAPH_SIZE];
            int step = 0;

            void GraphDepthTraverse(int topNumber)
            {
                graphTopsActive_1[topNumber] = 1;
                for (int relationTopNumber = 0; relationTopNumber < GRAPH_SIZE; relationTopNumber++)
                {
                    if (graphTopsActive_1[relationTopNumber] == 0 && GRAPH[topNumber, relationTopNumber] != 0) stack.Push(relationTopNumber);
                }

                Console.WriteLine($"Шаг {++step}:");
                Console.Write("Вершины: ");
                PrintArray(ref graphTopsActive_1);

                Console.Write($"Стэк: ");
                stack.Print();
                Console.WriteLine("");

                if (stack.Length != 0) GraphDepthTraverse(stack.Pop());
            }

            GraphDepthTraverse(0);

            #endregion



            #region Задание 3:
            //Написать функцию обхода графа в ширину.

            Console.WriteLine("Обход графа в ширину:\n");

            int[] graphTopsActive_2 = new int[GRAPH_SIZE];
            MyDeq<int> deq = new MyDeq<int>();
            step = 0;

            void GraphWideTraverse(int top)
            {
                graphTopsActive_2[top] = 1;
                for (int relationTopNumber = 0; relationTopNumber < GRAPH_SIZE; relationTopNumber++)
                {
                    if (graphTopsActive_2[relationTopNumber] == 0 && GRAPH[top, relationTopNumber] != 0) deq.PushFront(relationTopNumber);
                }

                Console.WriteLine($"Шаг {++step}:");
                Console.Write("Вершины: ");
                PrintArray(ref graphTopsActive_2);

                Console.Write($"Очередь: ");
                deq.Print();
                Console.WriteLine("");

                if (deq.Length != 0) GraphWideTraverse(deq.PopBack());
            }
            GraphWideTraverse(0);

            #endregion
            


            Console.ReadKey();
        }
    }
}
