using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
	/* 2. Oбобщенный тип (класс) Set<T> */
	public class Set<T> : ITechnic<T> where T : struct, IComparable<T>
	{
		// Классы элемента списка:
		public class Date                                           // Вложенный класс, содержащий дату
		{
			public readonly DateTime time;
			public Date()                                           // Конструктор
			{
				time = DateTime.Now;
			}
			public void ShowDate()                                  // Метод для вывода времени
			{
				Console.WriteLine(time);
			}
		}


		public class Owner
		{
			private readonly int ownerId;
			public string Name { get; set; }
			public string Organisation { get; set; }

			public Owner()
			{
			}

			public Owner(string name, string organisation)
			{
				ownerId = GetHashCode();
				Name = name;
				Organisation = organisation;
			}
		}

		private int count;
		private int size;
		public T[] setArr;
		private readonly Owner owner;
		private readonly Date date;


		public int GetSize()                                        // Размер множества
		{
			int size = 0;
			foreach (T item in setArr)
			{
				size++;
			}
			return size;
		}
		public T GetItemByIndex(int index)                          // Получение элемента множества по индексу
		{
			if (index > this.GetSize() - 1)
				throw new Exception("GetItemByIndex: OutOfRange");  // Исключение, возникающее при попытке обращения к элементу массива или коллекции с индексом, который находится вне границ.

			int size = -1;
			foreach (T item in setArr)
			{
				size++;
				if (size == index)
					return item;
			}
			return new T();
		}


		public void Add(T element)                                  // Добавление элемента во множество
		{
			if (count == size)
				throw new Exception($"ИСКЛЮЧЕНИЕ: Массив заполнен! [{count}/{size}]");
			setArr[count] = element;
			count++;
		}

		public void Delete(T element) => setArr = setArr.Where(x => !x.Equals(element)).ToArray();  // Удалить элемент из множества

		internal void Add()
		{
			throw new NotImplementedException("ИСКЛЮЧЕНИЕ: Метод или операция не реализованы!\n");
		}

		public void Show()                                           // Вывод множества
		{
			Console.Write("{");
			foreach (T a in setArr)
				Console.Write($"{a} ");
			Console.Write("}");
		}


		public Set()
		{
			setArr = new T[size = 10];     // 50 - размер множества по умолчанию.
			count = 0;
		}


		public Set(int arrSize)
		{
			setArr = new T[size = arrSize];
			count = 0;
		}
	}


	/* 4. Определить пользовательский класс, который будет использоваться в качестве параметра обобщения. 
	 * Для пользовательского типа взять класс из лабораторной №5 «Наследование» */

	public class CollectionType<T> : ITechnic<T> where T : class
	{
		private int count;
		private int size;
		public T[] setArr;

		public CollectionType() {}

		public void Add(T element)                                  // Добавление элемента во множество
		{
			if (count == size)
				throw new Exception($"ИСКЛЮЧЕНИЕ: Массив заполнен! [{count}/{size}]");
			setArr[count] = element;
			count++;
		}
		public void Delete(T element) => setArr = setArr.Where(x => !x.Equals(element)).ToArray();  // Удалить элемент из множества
		public void Show()                                           // Вывод множества
		{
			Console.Write("{");
			foreach (T a in setArr)
				Console.Write($"{a} ");
			Console.Write("}");
		}
		public CollectionType(int arrSize)
		{
			setArr = new T[size = arrSize];
			count = 0;
		}
	}
}


