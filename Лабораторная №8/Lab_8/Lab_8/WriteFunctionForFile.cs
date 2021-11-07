using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
	partial class MyClass
	{
		public static class WriteFunction<T> where T : struct
		{
			public static void WriteToFile(T[] arr)
			{
				using (StreamWriter file = new StreamWriter(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №8\Lab_8\Lab_8\MyFile.txt", true))
				{
					file.Write("{");
					foreach (var i in arr)
						file.Write($"{i} ");
					file.Write("}");
					file.Close();
				}
			}


			public static void LoadFromFile()             // Чтение из файла
			{
				using (FileStream fstream = File.OpenRead(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №8\Lab_8\Lab_8\MyFile2.txt"))
				{
					// преобразуем строку в байты
					byte[] array = new byte[fstream.Length];
					// считываем данные
					fstream.Read(array, 0, array.Length);
					// декодируем байты в строку
					string textFromFile = System.Text.Encoding.Default.GetString(array);
					Console.WriteLine($"Текст из файла: {textFromFile}");
				}
			}
				









			//	public static void LoadFromFile(ref Set<int> objCollectionType)
			//		{
			//	string text = "";

			//	using (StreamReader sr = new StreamReader(@"E:\БГТУ (Теория, лабы, подготовка к экзам)\2 курс\1 семестр\ООП\Лабораторные\Лабораторная №8\Lab_8\Lab_8\MyFile2.txt"))
			//	{
			//		while (sr.ReadLine() != null)
			//		{
			//			text = sr.ReadLine();
			//			switch (text)
			//			{
			//				case "1":
			//					objCollectionType.Add(1);
			//					break;
			//				case "2":
			//					objCollectionType.Add(2);
			//					break;
			//				case "3":
			//					objCollectionType.Add(3);
			//					break;
			//				case "4":
			//					objCollectionType.Add(4);
			//					break;
			//				case "5":
			//					objCollectionType.Add(5);
			//					break;
			//			}
			//		}
			//	}
			//}
		}
	}
}
