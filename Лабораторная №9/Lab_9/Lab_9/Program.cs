using System;
using System.Collections.Generic;

namespace Lab_9
{
	class Program
	{
		static void TaskWithString()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("\n\n\t\t___________Работа со строками___________\n");
			Func<string, string> A;
	
			Console.ForegroundColor = ConsoleColor.White;
			string str = "MY, first;: string?! ";
			Console.WriteLine($" > Исходная строка:\t\t{str}");
			Console.WriteLine("--------------------------------------------------\n");

			A = StringEditor.AddSymbol;
			Console.WriteLine($" > С добавлением символа:\t{str = A(str)}");

			A = StringEditor.ToUpper;
			Console.WriteLine($" > Верхний регистр:\t\t{str = A(str)}");

			A = StringEditor.ToLower;
			Console.WriteLine($" > Нижний регистр:\t\t{str = A(str)}");

			A = StringEditor.RemoveSpase;
			Console.WriteLine($" > Без пробелов:\t\t{str = A(str)}");

			A = StringEditor.RemoveS;
			Console.WriteLine($" > Без знаков препинания:\t{str = A(str)}");
			Console.WriteLine("\n\n\n");
		}

		static void MainTask()
		{
			//Game.Items Items;
			Game game = new Game();

			List<string> mylist = new List<string> { "Мирный житель №1", "Мирный житель №2", "Мирный житель №3", "Мирный житель №4", "Мафия", "Врач", "Комиссар" };

			foreach (string item in mylist)
			{
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				Console.Write(item + " | ");
				Console.ForegroundColor = ConsoleColor.White;
			}

			game.OnAttack += (list, killedperson) =>
					{
						Console.WriteLine($"{killedperson} Мёртв");

						for (int i = 0; i < list.Count; i++)
							if (list[i] == killedperson)
								list[i] = "МЁРТВЫЙ";
					
						foreach (string item in list)
						{
							Console.ForegroundColor = ConsoleColor.DarkGreen;
							Console.Write(item + " | ");
							Console.ForegroundColor = ConsoleColor.White;
						}
					};

			game.OnHeal += (list, revivedPerson) =>
			{
				Console.WriteLine($"{revivedPerson} Воскрес");

				for (int i = 0; i < list.Count; i++)
					if (list[i] == revivedPerson)
						list[i] = "Мирный житель";

				foreach (string item in list)
				{
					Console.ForegroundColor = ConsoleColor.DarkGreen;
					Console.Write(item + " | ");
					Console.ForegroundColor = ConsoleColor.White;
				}
			};

				bool flag = true;

				while (flag)
				{
					Console.WriteLine("\n\t > 1 - ударить,\n\t > 2 - лечить, \n\t > всё остальное - выход");
					string input = Console.ReadLine();

					switch (input)
					{
						case ("1"): game.Strike(mylist); break;
						case ("2"): game.Сure(mylist); break;
						default: flag= false; break;
					}
				}
		}

			
		static void Main(string[] args)
		{
			MainTask();
			TaskWithString();

			Console.ReadKey();
		}
	}
}
