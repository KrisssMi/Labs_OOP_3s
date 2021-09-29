using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public partial class Abiturient
    {
        static void Main(string[] args)
        {
            try
            {
                Secondtask();
                ShowCount();
                ThirdTask();
                RefAndOut();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void Secondtask()
        {
            var abit1 = new Abiturient("Kate", "Voronova", "Maksimovna", "Belarus, Brest", 375292006545, new int[] { 8, 2, 8, 3, 7 }, 375292006545);
            var abit2 = new Abiturient("Leo", "Sokol", "Vladimirovich", "Belarus, Minsk", 375445050128, new int[] { 10, 8, 9, 9, 8 }, 375445050128);
            var abit3 = new Abiturient("Ilya", "Adamov", "Andreevich", "Russia, Moscow", 375333318749, new int[] { 8, 7, 7, 10, 6 }, 375333318749);

		    abit1.FindAverageMark();

            Console.WriteLine("\tИнформация о первом абитуриенте:");
            Console.WriteLine();
            Console.WriteLine(abit1.ToString() + "\n");
            Console.WriteLine("\tИнформация о втором абитуриенте:");
            Console.WriteLine(abit2.ToString() + "\n");
            Console.WriteLine("\tИнформация о третьем абитуриенте:");
            Console.WriteLine(abit3.ToString()+"\n");

            Console.WriteLine($"\t\t\tAre abit1 and abit3 EQUALS? \t\t{ abit1.Equals(abit3)}");
            Console.WriteLine($"Type of abit2 - {abit2.GetType()}");
            abit3.ShowClassInfo();
            Console.Write($"Name of abit2: ");
            Console.WriteLine(abit2.surname);
            Console.Write($"Abit1's address: ");
            Console.WriteLine(abit1.address);
        }

        private static void ThirdTask()
        {
            var Abitura = new Abiturient[5];
            Abitura[0] = new Abiturient("Kate", "Voronova", "Maksimovna", "Belarus, Brest", 375292006545, new int[] { 8, 6, 8, 9, 7 }, 375292006545);
            Abitura[1] = new Abiturient("Leo", "Sokol", "Vladimirovich", "Belarus, Minsk", 375445050128, new int[] { 10, 8, 9, 9, 8 }, 375445050128);
            Abitura[2] = new Abiturient("Ilya", "Adamov", "Andreevich", "Russia, Moscow", 375333318749, new int[] { 8, 7, 3, 10, 6 }, 375333318749);
            Abitura[3] = new Abiturient("Dana", "Shulyak", "Fadeevna", "Belarus, Baranovichi", 375292053673, new int[] { 9, 7, 8, 9, 10 }, 375292053673);
            Abitura[4] = new Abiturient("Kirill", "Gerasimovich", "Olegovich", "Belarus, Gomel", 375337653927, new int[] { 4, 2, 8, 6, 5 }, 375337653927);

            
            Console.WriteLine("\nСписок всех абитуриентов: \n");
   
            foreach (Abiturient abiturient in Abitura)
			{
                Console.WriteLine($"{abiturient}"); 
            }
            Console.WriteLine($"\t\t\t\t\t\t\t\t\t--------> Текущее количество абитуриентов: {Abiturient.count}\n");


            int number = 38;
            foreach(Abiturient abiturient in Abitura)
			{
                if (number < abiturient.CountSum())
				{
					Console.WriteLine(abiturient.ToString() );
				}
			}

            Console.ForegroundColor = ConsoleColor.Yellow;
            Abitura[0].FindMaxAndMinMark();
            Abitura[0].FindAverageMark();

            //Создайте и выведите анонимный тип(по образцу вашего класса)
            {
                var car = new { Model = "BMW", Color = "Red" };
                Console.WriteLine($"Model: {car.Model}\n" + $"Color: {car.Color}\n");
                Console.ReadKey();
            }
        }

        private static void RefAndOut()
		{
            Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Ref and Out parametres :");

            var abit1 = new Abiturient("Kate", "Voronova", "Maksimovna", "Belarus, Brest", 375292006545, new int[] { 8, 2, 8, 3, 7 }, 375292006545);

            string newName = "Petya";

            Abiturient.ChangeName(out string AbiturName,newName);
            abit1.name = AbiturName;

			Console.WriteLine(abit1.ToString());


            //Ref
            string surname = "Katya";
            Abiturient.ChangeSurname(ref surname, "BLABLABLA");
			Console.WriteLine(surname);
           //name , surname
		}
	}
}
