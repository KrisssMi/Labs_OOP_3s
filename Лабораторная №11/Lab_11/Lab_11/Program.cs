using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_11
{
	class Program
	{
		static void Main(string[] args)
		{
			/* 1. Задайте массив типа string, содержащий 12 месяцев (June, July, May, December, January ….). Используя LINQ to Object. 
			 * Напишите запрос, выбирающий последовательность месяцев с длиной строки равной n, 
			 * запрос возвращающий только летние и зимние месяцы, 
			 * запрос вывода месяцев в алфавитном порядке,
			 * запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х.. */

			Task_1();


			/* 2. Создайте коллекцию List<T> и параметризируйте ее типом (классом) из лабораторной №3 (при необходимости реализуйте нужные интерфейсы). 
			Заполните ее минимум 8 элементами. 

			   3. Запросы:
			+ 1) список абитуриентов, имеющих неудовлетворительные оценки;
			+ 2) список абитуриентов, у которых сумма баллов выше заданной;
			+ 3) массив абитуриентов упорядоченных по алфавиту;
			+ 4) 4 последних абитуриента с самой низкой успеваемостью */

			Task_2_3();


			/* 5. Придумайте запрос с оператором Join */

			Task_5();


			void Task_1()
			{
				string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

				// запрос, выбирающий последовательность месяцев с длиной строки равной n:
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine(" > Введите число, равное длине строки для поиска месяца: ");
				int? number = Convert.ToInt32(Console.ReadLine());
				var selected_1 = from m in months
								 where m.Length == number
								 select m;
				Console.WriteLine("Месяцы длиной n:");
				foreach (string str in selected_1)
					Console.Write(str + ",  ");
				Console.WriteLine();


				// запрос возвращающий только летние и зимние месяцы:
				Console.WriteLine();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				var selected_2 = months.Where(x => x == "December" || x == "January" || x == "February" || x == "June" || x == "July" || x == "August");
				Console.WriteLine(" > Летние и зимние месяцы:");
				foreach (string str in selected_2)
					Console.Write(str + ",  \n");
				Console.WriteLine();


				// запрос вывода месяцев в алфавитном порядке:
				Console.ForegroundColor = ConsoleColor.White;
				var selected_3 = from n in months
								 orderby n
								 select n;
				Console.WriteLine(" > Месяцы в алфавитном порядке:");
				foreach (string str in selected_3)
					Console.Write(str + ",  ");
				Console.WriteLine();


				// запрос, считающий месяцы, содержащие букву «u» и длиной имени не менее 4 - х:
				Console.WriteLine();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				var selected_4 = from o in months
								 where (o.Length >= 4) && (o.Contains('u'))
								 select o;
				Console.WriteLine(" > Месяцы, содержащие букву «u» и длиной имени не менее 4 - х :");
				foreach (string str in selected_4)
					Console.Write(str + ",  ");
				Console.WriteLine("\n");
				Console.WriteLine("\n");
			}

			void Task_2_3()
			{
				Console.ForegroundColor = ConsoleColor.White;

				List<Abiturient> myList = new List<Abiturient>();
				myList.Add(new Abiturient("Voronova", "Kate", "Maksimovna", "Belarus, Brest", 375292006545, new int[] { 8, 2, 8, 3, 7 }, 375292006545));
				myList.Add(new Abiturient("Adamov", "Ilya", "Andreevich", "Russia, Moscow", 375333318749, new int[] { 8, 7, 7, 10, 6 }, 375333318749));
				myList.Add(new Abiturient("Sokol", "Leo", "Vladimirovich", "Belarus, Minsk", 375445050128, new int[] { 10, 8, 9, 9, 8 }, 375445050128));
				myList.Add(new Abiturient("Sunova", "Dana", "Fadeevna", "Belarus, Baranovichi", 375292053673, new int[] { 9, 7, 8, 9, 10 }, 375292053673));
				myList.Add(new Abiturient("Gerasimovich", "Kirill", "Olegovich", "Belarus, Gomel", 375337653927, new int[] { 4, 2, 8, 6, 5 }, 375337653927));
				myList.Add(new Abiturient("Borisov", "Mark", "Olegovich", "France, Paris", 375448762343, new int[] { 8, 8, 8, 9, 8 }, 375448762343));
				myList.Add(new Abiturient("Shulyak", "Kamila", "Mihailovna", "China, Shanghai", 375294057891, new int[] { 6, 7, 10, 10, 8 }, 375294057891));
				myList.Add(new Abiturient("Kotova", "Mary", "Leonidovna", "Poland, Warsaw", 375339022868, new int[] { 9, 10, 9, 10, 8 }, 375339022868));


				// список абитуриентов, имеющих неудовлетворительные оценки:
				IEnumerable<Abiturient> BadGrade = myList
					.Where(x => x.hasbadmarks);
				Console.WriteLine("\tСписок абитуриентов, имеющих неудовлетворительные оценки: ");
				BadGrade.ToList().ForEach(x => Console.WriteLine(x));
				Console.WriteLine();


				// список абитуриентов, у которых сумма баллов выше заданной:
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				Console.WriteLine("\tСписок абитуриентов, у которых сумма баллов выше заданной: ");
				foreach (var abit in myList.Where(b => b.CountSum() >= 20))
				{
					Console.WriteLine(abit.Name + ",  ");
				}
				Console.WriteLine();


				// массив абитуриентов упорядоченных по алфавиту:
				Console.ForegroundColor = ConsoleColor.Magenta;
				var sorted_3 = from m in myList
							   orderby m.Surname
							   select m;
				Console.WriteLine("\tМассив абитуриентов, фамилии которых упорядоченны по алфавиту: ");
				foreach (var str in sorted_3)
					Console.WriteLine(str.Surname + ",  ");
				Console.WriteLine();


				// 4 последних абитуриента с самой низкой успеваемостью:
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("\tМассив абитуриентов с самой низкой успеваемостью: ");
				Console.Write(myList.OrderBy(i => i.SumMarks()).ToList()[0].Name + "\t");
				Console.Write("Его сумма отметок: ");
				Console.WriteLine(myList.OrderBy(i => i.SumMarks()).ToList()[0].SumMarks());

				Console.Write(myList.OrderBy(i => i.SumMarks()).ToList()[1].Name + "\t");
				Console.Write("Его сумма отметок: ");
				Console.WriteLine(myList.OrderBy(i => i.SumMarks()).ToList()[1].SumMarks());
				Console.Write(myList.OrderBy(i => i.SumMarks()).ToList()[2].Name + "\t");
				Console.Write("Его сумма отметок: ");
				Console.WriteLine(myList.OrderBy(i => i.SumMarks()).ToList()[2].SumMarks());
				Console.Write(myList.OrderBy(i => i.SumMarks()).ToList()[3].Name + "\t");
				Console.Write("Его сумма отметок: ");
				Console.WriteLine(myList.OrderBy(i => i.SumMarks()).ToList()[3].SumMarks());
				Console.WriteLine();



				/* 4. Придумайте и напишите свой собственный запрос, в котором было бы не менее 5 операторов из разных категорий: условия, проекций, 
				упорядочивания, группировки, агрегирования, кванторов и разбиения. */

				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Собственный запроc, состоящий из нескольких операторов: ");
				var ownSample = myList.Where(t => t.Name.Length > 0).OrderBy(t => t.Surname.Contains('S')).Last().Name;
				Console.WriteLine(ownSample);
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("\n");
				Console.WriteLine("\n");
			}


			void Task_5()
			{
				List<Organization> organizations = new List<Organization>()
				{
					new Organization {Name = "БРСМ", University ="БГУИР" },
					new Organization {Name = "Профком", University ="БГТУ" },
					new Organization {Name = "Октябрята", University ="БГМУ" }
				};
				List<Person> persons = new List<Person>()
				{
					new Person {Name="Наташа", Organization="Профком"},
					new Person {Name="Ира", Organization="БРСМ"},
					new Person {Name="Карина", Organization="Октябрята"}
				};

				var result = persons.Join(organizations,		// второй набор
				 p => p.Organization,							// свойство-селектор объекта из первого набора
				 t => t.Name,									// свойство-селектор объекта из второго набора
				 (p, t) => new { Name = p.Name, Organization = p.Organization, University = t.University }); // результат

				foreach (var item in result)
					Console.WriteLine($"{item.Name} - {item.Organization} ({item.University})");
				Console.WriteLine();
			}
		}
		class Person
		{
			public string Name { get; set; }
			public string Organization { get; set; }
		}
		class Organization
		{
			public string Name { get; set; }
			public string University { get; set; }
		}
	}
}
