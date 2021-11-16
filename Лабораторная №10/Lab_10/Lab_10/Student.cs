using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab_10
{
    public class Student
    {
        public string name = "Unknown";
        int age = 0;
        protected int numOfStudents = 0;

        public Student(string Name, int Age)
        {
            name = Name;
            age = Age;
        }

        public Student()
        {
        }

        public int CompareTo(object obj)
        {
            return name.CompareTo(obj);
        }

        public string GetName() => name;

        public override string ToString()
        {
            Console.WriteLine($"Имя студента: {name}");
            Console.WriteLine($"Возраст: {age}");
            return "\n";
        }
    }
}