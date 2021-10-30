using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    class Computer : Equipment, IMovable
    {
        public static int amount = 0;
        private string type;
		private int service_life = 8;
		private string operating_system;
        private string processor;
        private string number="10"; 

        public string Number { get; set; }

		public int Service_life
        {
            get
            {
                return service_life;
            }
            set
            {
                service_life = value;
            }
        }

        public Computer(double cost, double weight, string model, string type, string operating_system, string processor)   // Конструктор с параметрами
        {
            this.cost = cost;
            this.weight = weight;
            this.model = model;
            this.type = type;
            this.operating_system = operating_system;
            this.processor = processor;
            amount++;
    }

        public Computer()
            {
            this.Number = number;
            }

        public Computer(int sl)
        {
            Service_life = sl;
        }

        public override void Move()
        {
            Console.WriteLine("Загрузка данных...");
        }

        public override void Print()
        {
            Console.WriteLine($"  >>> Переопределенный метод Print()\n \t > Операционная система: {operating_system}");
        }

        public override void GetInfo()
        {
            Console.WriteLine("\n\n___Компьютер___" + "\nСтоимость: " + cost + "\nВес: " + weight + "\nПроизводитель: " + model + "\nТип: " + type + "\nОперационная система: " + operating_system + "\nПроцессор: " + processor);
        }

       public override string ToString()       // Метод ToString() переопределен, поэтому в консоль будет выведено не название класса, а информация, которую мы задаем при инициализации объекта
       {
			return base.ToString() + " " + cost.ToString() + " " + weight.ToString() + " " + model.ToString() + " " + type.ToString() + " " + operating_system.ToString() + " " + processor.ToString();
       }

        public override int GetHashCode()       // Метод GetHashCode() позволяет возвратить некоторое числовое значение, соответствующее объекту или, как ещё говорят, его хэш-код
        {
            return Number.GetHashCode();
        }

        public override bool Equals(object obj)  // Позволяет проверить два объекта на равенство, используя собственный алгоритм сравнения
        {
            if (obj.GetType() != this.GetType()) return false;

            Computer comp = (Computer)obj;
            return (this.Number == comp.Number);
        }
    }
}
