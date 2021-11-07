using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
	class My_SetAndOverloads
	{
		public class My_Set
		{
			public HashSet<String> collection;
			public int Size;


			public My_Set()
			{
			}


			public HashSet<string> GetHash()
			{
				return collection;
			}

			public void Show()                                           // Вывод множества
			{
				foreach (string item in collection)
				{
					Console.WriteLine(item);
				}
			}


			public int GetSize()                                        // Размер множества
			{
				int size = 0;
				foreach (string item in collection)
				{
					size++;
				}
				return size;
			}


			public void AddItem(string item)                            // Добавление элемента во множество
			{
				collection.Add(item);
			}

		

			public string GetItemByIndex(int index)                     // Получение элемента множества по индексу
			{
				if (index > this.GetSize() - 1)
					throw new Exception("GetItemByIndex: OutOfRange"); // Исключение, возникающее при попытке обращения к элементу массива или коллекции с индексом, который находится вне границ.

				int size = -1;
				foreach (string item in collection)
				{
					size++;
					if (size == index)
						return item;
				}
				return "";
			}


			// --------------------------------Перегруженные операции----------------------------------------
			public static My_Set operator -(My_Set set, string item)            // Удалить элемент из множества
			{
				Console.WriteLine("Удаление элемента из множества\n");
				set.collection.Remove(item);
				return set;
			}

			public static My_Set operator +(My_Set set, string item)            // Добавить элемент в множество 
			{
				Console.WriteLine("Добавление элемента в множество\n");
				set.collection.Add(item);
				return set;
			}

			public static bool operator >(My_Set set3, My_Set set2)              // Проверка на подмножество
			{
				Console.WriteLine("Проверка на подмножество\n");
				if (set3.collection.IsSubsetOf(set2.collection))
					return true;
				else
					return false;
			}

			public static bool operator <(My_Set set, My_Set set2)
			{
				Console.WriteLine("Проверка на подмножество\n");
				if (set.collection.IsSubsetOf(set2.collection))
					return false;
				else
					return true;
			}

			public static bool operator !=(My_Set set, My_Set set2)                 // Проверка на неравенство множеств
			{
				return !set.Equals(set2);
			}


			public static bool operator ==(My_Set set, My_Set set2)                 // Проверка на равенство множеств
			{                                                                       //если перегружаются операторы == и !=, то для этого требуется переопределить метод Object.Equals()
				return set.Equals(set2);
			}


			public static My_Set operator %(My_Set set, My_Set set2)                // Пересечение множеств
			{
				Console.WriteLine("Пересечение множеств\n");
				set.collection.IntersectWith(set2.collection);
				return set;
			}
		}
	}
}
