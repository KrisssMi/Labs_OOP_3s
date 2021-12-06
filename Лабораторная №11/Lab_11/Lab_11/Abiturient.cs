using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11
{
	public partial class Abiturient
	{
		//-------------------ПОЛЯ-------------------
		//id, Фамилия, Имя, Отчество, Адрес, Телефон, массив оценок
		//const int maxStudents = 3;                 //поле константа
		private readonly long id;                    //поле только для чтения
		private static int count;                    //статическое поле с количеством объектов
		public int[] evaluation = new int[5];        //массив оценок
		private int summarks = 0;


		//-------------------СВОЙСТВА-------------------
		public string name { get; set; }       // Автоматическое свойство (уже определяет место в памяти)
		public bool hasbadmarks;
		public string surname { get; set; }
		public string middle_name { get; set; }
		public string address { get; private set; }

		private long phone_number;              //формат 375ххххххxxx

		public long Phone_number                //свойство с ограничением доступа по set
		{
			get
			{
				return phone_number;
			}
			set
			{
				if (value < 375000000000 && value > 375999999999)
				{
					Console.WriteLine("Неправильно введен телефон");
				}
				else
				{
					phone_number = value;         // явное имя параметра, передаваемого в метод set свойства класса
				}
			}
		}

		public string Name                      //свойство с ограничением доступа по set
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public string Surname                   //свойство с ограничением доступа по set
		{
			get
			{
				return surname;
			}
			set
			{
				surname = value;
			}
		}

		public string Middle_name               //свойство с ограничением доступа по set
		{
			get
			{
				return middle_name;
			}
			set
			{
				middle_name = value;
			}
		}


		//-------------------КОНСТРУКТОРЫ-------------------
		static Abiturient()                // статический конструктор (закрыт, без параметров, нельзя вызвать явно)
		{
			count = 0;
		}

		//private Abiturient() { }         // закрытый конструктор

		public Abiturient(int id)         // конструктор без параметров
		{

			this.id = id;
			Abiturient.count++;
		}

		// конструктор с параметрами по умолчанию
		public Abiturient(string surname, string name, string middle_name, string address, long phone_number, int[] mas, long id)
		{
			if (phone_number > 375000000000 && phone_number < 375999999999)                         // this обеспечивает доступ к текущему экземпляру класса
			{
				Abiturient.count++;
				this.Surname = surname;
				this.Name = name;
				this.Middle_name = middle_name;
				this.address = address;
				this.Phone_number = phone_number;
				if (mas.Length == 5) evaluation = mas;
				else
				{
					evaluation = new int[5];
				}
				hasbadmarks = hasbadmarks_f(mas);
				//sumismore = SumIsMore();
				//sr = Sr(mas);

				this.id = GetHashCode();
			}
			else
				throw new Exception("Некорректный ввод номера телефона!");
		}

		public Abiturient()
		{
			Abiturient.count++;
			this.Surname = Surname;
			this.Name = Name;
			this.Middle_name = Middle_name;
			this.address = address;
			this.Phone_number = Phone_number;
			this.evaluation = new int[5];
			this.id = GetHashCode();
		}


		//-------------------МЕТОДЫ-------------------

		public void ShowClassInfo()
		{
			Console.WriteLine(this.ToString());

		}

		public bool hasbadmarks_f(int[] mas)       // метод для поиска абитуриентов с неудовлетворительными оценками
		{
			foreach (int mark in mas)
			{
				if (mark < 4)
				{
					return true;
				}

			}
			return false;
		}

		public int SumMarks()
		{
			summarks=this.evaluation[0] + this.evaluation[1] + this.evaluation[2] + this.evaluation[3] + this.evaluation[4];
			return summarks;
		}

		public int CountSum()                           // сумма отметок объекта
		{
			int sum = 0;

			foreach (int item in this.evaluation)
			{
				sum += item;
			}

			return sum;
		}


		public void FindAverageMark()                       // метод для расчёта среднего балла
		{
			int sum = 0;
			double averageMark = 0;
			foreach (int mark in evaluation)
			{
				sum = this.evaluation[0] + this.evaluation[1] + this.evaluation[2] + this.evaluation[3] + this.evaluation[4];
				averageMark = (double)sum / 5;
			}
			Console.WriteLine($"Средний балл: {averageMark}");
		}

		public void FindMaxAndMinMark()                    // метод для поиска максимального и минимального балла
		{
			int maxMark = 0;
			int minMark = 11;

			foreach (int mark in this.evaluation)
			{
				if (mark > maxMark)
					maxMark = mark;
				if (mark < minMark)
					minMark = mark;
			}
			Console.WriteLine($"Максимальный балл = {maxMark}");
			Console.WriteLine($"Минимальный балл = {minMark}");
		}

		public static void ChangeName(out string AbiturName, string newName)
		{
			AbiturName = newName;
		}

		public static void ChangeSurname(ref string surname, string newSurname)
		{
			surname = newSurname;
		}
		public override string ToString()
		{
			return $"ID: {this.id}\n" +
				$"Фамилия: {this.surname}\n" +
				$"Имя: {this.name}\n" +
				$"Отчество: {this.middle_name}\n" +
				$"Номер телефона: {this.phone_number }\n" +
				$"Адрес: {this.address}\n" +
				$"Оценки: {this.evaluation[0]} {this.evaluation[1]} {this.evaluation[2]} {this.evaluation[3]} {this.evaluation[4]}\n" +
				$"Абитуриент имеет неудовлетворительные оценки? { this.hasbadmarks}\n" +
				$"_________________________________________________________";

		}       // Вывод информации об объектах класса

		public override int GetHashCode()
		{
			return (int)(this.phone_number);
		}       // Возвращает хэш-код для значения данного объекта

		public override bool Equals(object obj)
		{
			if (obj == null)
				throw new NullReferenceException();

			Abiturient abiturient = obj as Abiturient;
			if (abiturient == null)
				return false;
			return abiturient.id == this.id;
		}   // Реализует проверку на тождество
	}
}
