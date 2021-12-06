using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Laba_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Reflector.GetName("Laba_12.Test");
			Console.WriteLine("\t________________________________КОНСТРУКТОРЫ: ");
            Reflector.GetConstructors("Laba_12.Test");
            Console.WriteLine("\t________________________________МЕТОДЫ: ");
            Reflector.GetMethod("Laba_12.Test");
            Reflector.GetMethod("Laba_12.Program");
            Console.WriteLine("\t________________________________CВОЙСТВА И ПОЛЯ: ");
            Reflector.GetField("Laba_12.Test");
            Console.WriteLine("\t________________________________ИНТЕРФЕЙСЫ: ");
            Reflector.GetInterfece("Laba_12.Test");
			Console.WriteLine();
            Console.WriteLine("\t________________________________МЕТОДЫ ПО ПАРАМЕТРУ: ");
            Reflector.MethodForType("Laba_12.Test", "String");
            Console.WriteLine();
            Console.WriteLine("\t________________________________СЧИТЫВАНИЕ ИНФОРМАЦИИ  ИЗ ФАЙЛА: ");
            Reflector.Invoke("Laba_12.Test", "Toconsole");
            Console.WriteLine();
            Console.WriteLine("\t________________________________СОЗДАНИЕ ОБЪЕКТА ПЕРЕДАННОГО ТИПА: ");
            Reflector.Create("Laba_12.Test", "Kristina");
            Console.ReadKey();
        }
    }
}
