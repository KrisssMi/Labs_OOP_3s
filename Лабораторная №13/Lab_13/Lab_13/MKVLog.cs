using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13
{
	class MKVLog
	{
		/* 1.Создать класс XXXLog. Он должен отвечать за работу с текстовым файлом xxxlogfile.txt, в который записываются все действия пользователя и 
		 * соответственно методами записи в текстовый файл, чтения, поиска нужной информации.a.Используя данный класс выполните запись всех последующих действиях пользователя 
		 * с указанием действия, детальной информации (имя файла, путь) и времени (дата/время). */

		public static void AddNote(string message, string utility, string path)
		{
			using (var stream = new StreamWriter(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13\Log.txt", true))
			{
				stream.WriteLine($"{DateTime.Now.ToString()}\n{message}");
				stream.WriteLine($"\n{utility}: {path}");
			}
		}

		public static void Clear()
		{
			using (StreamWriter stream = new StreamWriter(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №13\Lab_13\Lab_13\Log.txt"))
			{
				stream.WriteLine(DateTime.Now);
				stream.WriteLine();
				stream.Close();
			}
		}
	}
}
