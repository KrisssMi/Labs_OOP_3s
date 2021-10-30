using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Класс-контроллер. 
 Управляет объектом-контейнером и реализовывает в нем необходимые методы:
			Найти технику старше заданного срока службы. 
			Подсчитать количество каждого вида техники. 
			Вывести список техники в порядке убывания цены. */

namespace Lab_6
{
	class Сontroller
	{
		public Сontroller()												// конструктор без параметров (по умолчанию)
		{
		}

	
		public void NumberOfEachType()									// Подсчёт количества каждого вида техники
		{
			Console.WriteLine("\n\tКоличество каждого вида техники: ");
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine(" -> Количество принтеров: " + PrintingDevice.amount);
			Console.WriteLine(" -> Количество сканеров:" + Scanner.amount);
			Console.WriteLine(" -> Количество компьютеров: " + Computer.amount);
			Console.WriteLine(" -> Количество планшетов: " + Tablet.amount);
			Console.ForegroundColor = ConsoleColor.White;
		}

		public void SearchByServiceLife(int t, Equipment obj)			// Поиск техники старше заданного срока службы 
		{
			//foreach (var i in list)
				if (t < obj.Service_life)
				{
					Console.WriteLine("Срок службы техники старше заданного");
				}
				else
				{
					Console.WriteLine("Срок службы техники младше заданного");
				}
		}

		public void SortByCost(Laboratory obj)                              // Cписок техники в порядке убывания цены
		{
			obj.list = obj.list.OrderByDescending(item => item.cost).ToList();  // Сортирует элементы последовательности в порядке убывания ключа
		}
	}
}
