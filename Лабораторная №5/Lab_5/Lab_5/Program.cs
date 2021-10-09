using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Вариант №5
/*Товар, Техника, Печатающее устройство, Сканер, Компьютер, Планшет*/

namespace Lab_5
{
	class Program
	{
		static void Main(string[] args)
		{
            PrintingDevice myPrinter = new PrintingDevice(80.60, 10.75, "Canon", "цветной", 4);
            Scanner myScaner = new Scanner(68.54, 7.5, "Samsung", "встроенный", 8);
            Computer myComputer = new Computer(2800, 3.4, "ASUS", "Игровой ноутбук", "Windows", "AMD");
            Computer nextComputer = new Computer(2000, 2.0, "Lenovo", "Ноутбук для учёбы", "Linux", "Intel");
            Tablet myTablet = new Tablet(2100.68, 2, "IPad", "Белый", 64);



            /*  оператор is – проверяет, совпадает ли тип выражения с заданным типом данных;
                оператор as – предназначен для избежания возникновения исключительной ситуации в случае неудачного приведения типов */

            Equipment tech = myPrinter as Equipment;
            if (tech is Equipment)          // Если выражение и тип имеют одинаковый тип данных, то результат операции будет true,
                                            // в противном случае, результат операции is будет false.
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("Error");
            }

            Scanner objA = new Scanner();
            Equipment objB = new Computer();
            Tablet objC = new Tablet();

            // в objB заносится результат приведения объекта objA
            objB = objA as Equipment;

            if (objB == null)
                Console.WriteLine("Невозможно привести objA к типу Equipment");
            else
                Console.WriteLine("Можно приводить objA к типу Equipment");


            // еще одна попытка привести objC к типу Tablet, результат в objB
            objB = objC as Tablet;

            // вывод результата
            if (objB == null)
                Console.WriteLine("Невозможно привести objC к типу Tablet");
            else
                Console.WriteLine("Можно приводить objC к типу Tablet");



            myPrinter.GetInfo();
            myPrinter.Move();
            myPrinter.Print();      // метод, унаследованный с интерфейса без переопределение

            myScaner.GetInfo();
            myScaner.Move();
            myScaner.Print();

            myComputer.GetInfo();
            myComputer.Print();
            myComputer.Move();

            nextComputer.GetInfo();
            
            myTablet.GetInfo();
            myTablet.Move();
            myTablet.Print();



            Computer comp1 = new Computer { Number = "12" };
            Computer comp2 = new Computer { Number = "15" };
            Computer comp3 = new Computer { Number = "12" };
            bool c1Ec2 = comp1.Equals(comp2);   // false
            bool с1Ec3 = comp1.Equals(comp3);   // true

            Console.WriteLine("\n\t\t---> ПЕРЕОПРЕДЕЛЕНИЕ МЕТОДА Equals() <--- \n");
            Console.Write("1. Cравнение comp1 и comp2: ");
            Console.Write(c1Ec2 + "\n");
            Console.Write("2. Cравнение comp1 и comp3: ");
            Console.Write(с1Ec3+ "\n");

            Console.WriteLine("______________________________________________________________");
            Console.WriteLine("\n\t\t---> ПЕРЕОПРЕДЕЛЕНИЕ МЕТОДА ToString() <--- \n");
            Console.Write(myComputer.ToString() + "\n");
            Console.Write(nextComputer.ToString() + "\n");

            Console.WriteLine("______________________________________________________________");
            Console.WriteLine("\n\t\t---> ПЕРЕОПРЕДЕЛЕНИЕ МЕТОДА GetHashCode() <--- \n");
            Console.Write("Хэш-код comp1: ");
            Console.Write(comp1.GetHashCode() + "\n");
            Console.Write("Хэш-код comp2: ");
            Console.Write(comp2.GetHashCode() + "\n");
            Console.Write("Хэш-код comp3: ");
            Console.Write(comp3.GetHashCode() + "\n");
            Console.WriteLine("______________________________________________________________");


            Console.WriteLine("\n----------------------------------------------------------");
            Equipment[] tech1 = { myPrinter, myScaner, myTablet };  // массив, содержащий ссылки на разнотипные объекты классов
            Printer printer = new Printer();                        // создание объекта класса Printer
            foreach (var item in tech1)
            {
                Console.Write("Тип объекта: ");
                printer.IAmPrinting(item);
            }



            Console.ReadKey();
        }
	}
}
