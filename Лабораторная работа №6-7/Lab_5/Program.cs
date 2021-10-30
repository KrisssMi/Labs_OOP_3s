using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Lab_6.Exceptions;

//Вариант №5
/*Товар, Техника, Печатающее устройство, Сканер, Компьютер, Планшет*/

namespace Lab_6
{
	class Program
	{
		static void Main(string[] args)
		{
            // >>> Для лабораторной работы №5
            
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


            //______________________________________________________________________________
            // >>> Для лабораторной работы №6:

            /// Создание объектов для класса-контейнера Laboratory

            var firstItem = new Computer(2800, 3.4, "ASUS", "Игровой ноутбук", "Windows", "AMD");
            var secondItem = new PrintingDevice(80.60, 10.75, "Canon", "цветной", 4);
            var thirdItem = new Scanner(68.54, 7.5, "Samsung", "встроенный", 8);
            var fourthItem = new Tablet(2100.68, 2, "IPad", "Белый", 64);
            var fifthItem = new Computer(2000, 2.0, "Lenovo", "Ноутбук для учёбы", "Linux", "Intel");

            Laboratory lab = new Laboratory(firstItem, secondItem, thirdItem, fourthItem, fifthItem);

            Console.WriteLine("\n\n\n\t >>> Проверка методов класса-контейнера: <<< \n");
            lab.Add(firstItem);
            lab.Add(secondItem);
            lab.Add(thirdItem);
            lab.Add(fourthItem);
            lab.Add(fifthItem);
            Console.WriteLine("\n\tВывод всех первоначальных объектов:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            lab.Printing();

            Console.ForegroundColor = ConsoleColor.White;
            lab.Delete(firstItem);
            lab.Delete(fifthItem);
            Console.WriteLine("\n\tВывод объектов после удаления:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            lab.Printing();


            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n\t >>> Проверка методов класса-контроллера: <<< \n");


            /// Реализация методов класса-контроллера

            Сontroller controller = new Сontroller();
            controller.NumberOfEachType(); // Подсчёт количества каждого вида техники

            Tablet t = new Tablet(4);
            PrintingDevice p = new PrintingDevice(10);
            Computer k = new Computer(8);
            Scanner s = new Scanner(7);

            Console.WriteLine("\n\tПоиск техники старше заданного срока службы: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            controller.SearchByServiceLife(11,t);                            // Поиск техники старше заданного срока службы 
            controller.SearchByServiceLife(11,p);
            controller.SearchByServiceLife(11,k);
            controller.SearchByServiceLife(11,s);
            Console.ForegroundColor = ConsoleColor.White;


            Console.WriteLine("\n\tСортировка по цене (в порядке убывания): ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            controller.SortByCost(lab);                                     // Cписок техники в порядке убывания цены
            lab.Printing();
            Console.ForegroundColor = ConsoleColor.White;





            //______________________________________________________________________________
            // >>> Для лабораторной работы №7:

            Console.WriteLine("\n\n\n ________________Для лабораторной работы №7_________________\n");

            /// Объект класса принимает значение NULL
            try
            {
                object obj = "String";
                //Computer Comp = new Computer();
                Computer Comp = obj as Computer;
                if (Comp == null)
                {
					throw new NullObject();     /// Исключение может быть сгенерировано вручную
                }
            }
            catch (NullObject e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                e.PrintInfo();
            }


            /// Несуществующая дата
            try
            {
                Dates check = new Dates(40112021);
                if (check.Date > 31129999)
                {
                    throw new WrongDate("Несуществующая дата!");
                }
            }
            catch (WrongDate e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                e.PrintInfo();
            }


            /// Член класса не инициализирован
            try
            {
                Tablet my_tablet = new Tablet();
                if (my_tablet.service_life == 0)
                {
                    throw new EmptyStruct();
                }
            }

            catch (EmptyStruct e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                e.PrintInfo();
            }


            /// Деление на 0
            try
            {
                int x = 5, y = 0;
                int c = x / y;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message + "\n");
            }


            /// Выход за границы массива
            try
            {
                int[] arr = new int[8];
                arr[10] = 10;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message + "\n");
            }


            finally     /// Необязательный элемент. Finally-Блок всегда выполняется,
                        /// когда выполнение покидает любую часть Try...Catch инструкции
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\tFINALLY > Обязательное выполнение данного кода \n");
            }



			/// Тестирование макроса Assert.

			/* Проверяет условие.
            // Если условие имеет значение false,
            // выдается сообщение и отображается окно сообщения со стеком вызовов */
			// Программа продолжается без каких-либо перерывов, если условие истинно.

			//int index = -40;
			//Debug.Assert(index > -1);

			//Laboratory my_scanner = null;
			//Computer ASUS = new Computer();
			//my_scanner.Add(ASUS);
			//Debug.Assert(my_scanner != null, "Ссылка на объект не указывает на экземпляр объекта");

			Console.ReadKey();
        }
	}
}
