using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ольга Назарова

namespace Lesson6
{
    class Student
    {
        string name;
        int age;
        int id;

        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
        public int ID { get { return id; } set { id = value; } }

        public Student(string name, int age, int id)
        {
            this.name = name;
            this.age = age;
            this.id = id;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 2:
            //Переписать программу, реализующее двоичное дерево поиска:
            //a.Добавить в него обход дерева различными способами.
            //b.Реализовать поиск в нём.
            //c. * Добавить в программу обработку командной строки с помощью которой можно указывать, из какого файла считывать данные, каким образом обходить дерево.

            //Задание 3:
            //Разработать базу данных студентов, состоящую из полей «Имя», «Возраст», «Табельный номер», в которой использовать все знания, полученные на уроках.
            //Данные следует считать в двоичное дерево поиска.Реализовать поиск по какому-нибудь полю базы данных.

            

            Console.ReadKey();
        }
    }
}
