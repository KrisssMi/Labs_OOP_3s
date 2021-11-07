using System;
using System.IO;
using System.Xml.Schema;
using static Lab_8.MyClass;

namespace Lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /* 3. Проверьте использование обобщения для стандартных типов данных (в качестве стандартных типов использовать целые, вещественные и т.д.).*/
                Set<int> set1 = new Set<int>(6);
                Set<char> set2 = new Set<char>(7);
                Set<bool> set3 = new Set<bool>(5);
                Set<byte> set4 = new Set<byte>(0);


                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\t > Первое множество: ");
                set1.Add(1);
                set1.Add(2);
                set1.Add(3);
                set1.Add(4);
                set1.Add(5);
                set1.Add(6);
                //set1.Add(23); // show Exception(Массив заполнен)

                Console.Write("Первоначальное множество: ");
                set1.Show();
                Console.Write("\n");
                set1.Delete(6);
                Console.Write("Множество после удаления элементов: ");
                set1.Show();
                Console.WriteLine("\n");


                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t > Второе множество: ");
                set2.Add('a');
                set2.Add('b');
                set2.Add('c');
                set2.Add('d');
                set2.Add('e');
                set2.Add('f');
                set2.Add('g');

                Console.Write("Первоначальное множество: ");
                set2.Show();
                Console.Write("\n");
                set2.Delete('b');
                set2.Delete('c');
                Console.Write("Множество после удаления элементов: ");
                set2.Show();
                Console.WriteLine("\n");


                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\t > Третье множество: ");
                set3.Add(true);
                set3.Add(false);
                set3.Add(false);
                set3.Add(true);
                set3.Add(true);
                set3.Show();
                Console.WriteLine("\n");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t > Четвёртое множество: ");
                //set4.Add();                 // show Exception (метод не реализован)

                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.White;



                CollectionType<Equipment> collectiontype = new CollectionType<Equipment>(6);
                Computer tech1 = new Computer();
                Tablet tech2 = new Tablet();
                collectiontype.Add(new Computer());
                collectiontype.Add(new Tablet());
                

                WriteFunction<int>.WriteToFile(set1.setArr);
				WriteFunction<char>.WriteToFile(set2.setArr);
				WriteFunction<bool>.WriteToFile(set3.setArr);
				Console.WriteLine("Запись элементов множеств в файл...\n");


                Console.WriteLine("Вывод элементов множеств из файла:");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                WriteFunction<int>.LoadFromFile();
               
            }

            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }

            finally
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Программа завершена.");
                Console.ReadKey();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

		private class Set
		{
		}
	}
}