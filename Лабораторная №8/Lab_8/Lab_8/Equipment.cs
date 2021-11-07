using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    abstract class Product                      // Абстрактный класс (базовый класс или родитель)
    {
        public double cost;     // стоимость
        public double weight;   // вес
        static int count = 0;   // количество

        public double Cost { get; set; }
        public double Weight { get; set; }
        public abstract void Move();

        public Product()        // конструктор по умолчанию
        {
            count++;
        }

        protected Product(double cost, double weight)
        {
            Cost = cost;
            Weight = weight;
        }


        virtual public void GetInfo()
        {
            Console.WriteLine("\nСтоимость: " + cost + "\nВес: " + weight);
        }
    }
    abstract class Equipment : Product, IMovable
    {
        public string model;    // модель
        static int count = 0;   // количество

        public string Model { get; set; }
        public Equipment()      // конструктор по умолчанию
        {
            count++;
        }

        public virtual void Print()
        {
            Console.WriteLine($"  >>> Метод virtual Print()\n\t > Стоиомть продукта: {cost}\n\t > Вес: {weight}\n\t > Количество товаров: {count}");
        }

		public Equipment(double cost, double weight, string model) : base(cost, weight)
        {
            Model = model;
        }
    }
    sealed class Scanner : Equipment, IMovable
    {
        private string type;
        private int speed;

        public Scanner()
        {
        }

        public Scanner(double cost, double weight, string model, string type, int speed)             // Конструктор с параметрами
        {
            this.cost = cost;
            this.weight = weight;
            this.model = model;
            this.type = type;
            this.speed = speed;
        }


        public override void Move()
        {
            Console.WriteLine("Сканирование документа...");
        }

        public override void Print()
        {
            Console.WriteLine("Перенос отсканированного документа на бумагу...");
        }

        public override void GetInfo()
        {
            Console.WriteLine("\n\n___Сканер___" + "\nСтоимость: " + cost + "\nВес: " + weight + "\nПроизводитель: " + model + "\nТип: " + type + "\nСкорость: " + speed);
        }

        public override string ToString()
        {
            return base.ToString() + " " + cost.ToString() + " " + weight.ToString() + " " + model.ToString() + " " + type.ToString() + " " + speed.ToString();
        }
    }
    sealed class PrintingDevice : Equipment, IMovable
    {
        private string color;
        private int speed;


        public PrintingDevice(double cost, double weight, string model, string color, int speed)   // Конструктор с параметрами
        {
            this.cost = cost;
            this.weight = weight;
            this.model = model;
            this.color = color;
            this.speed = speed;
        }

        public override void Move()
        {
            Console.WriteLine("Загрузка всех компонентов принтера...");
        }

        public override void GetInfo()
        {
            Console.WriteLine("\n\n___Печатающее устройство___" + "\nСтоимость:" + cost + "\nВес:" + weight + "\nПроизводитель:" + model + "\nЦвет: " + color + "\nСкорость печати: " + speed);
        }

        public override string ToString()
        {
            return base.ToString() + " " + cost.ToString() + " " + weight.ToString() + " " + model.ToString() + " " + color.ToString() + " " + speed.ToString();
        }
    }
    sealed class Tablet : Equipment, IMovable
    {
        private string type;
        private int memory;


        public string Type { get; set; }
        public int Memory { get; set; }

        public Tablet()
        {
        }

        public Tablet(double cost, double weight, string model, string type, int memory) : base(cost, weight, model)
        {
            this.cost = cost;
            this.weight = weight;
            this.model = model;
            this.Type = type;
            this.memory = memory;
        }

        public override void Move()
        {
            Console.WriteLine("Начало работы планшета...");
        }

        public override void Print()
        {
            Console.WriteLine("Загрузка данных...");
        }

        public override void GetInfo()
        {
            Console.WriteLine("\n\n___Планшет___" + "\nСтоимость: " + cost + "\nВес: " + weight + "\nПроизводитель: " + model + "\nЦвет: " + type + "\nПамять: " + memory);
        }

        public override string ToString()
        {
            return base.ToString() + " " + cost.ToString() + " " + weight.ToString() + " " + model.ToString() + " " + type.ToString() + " " + memory.ToString();
        }
    }
    sealed class Computer : Equipment, IMovable
    {
        private string type;
        private string operating_system;
        private string processor;
        private string number = "10";

        public string Number { get; set; }

        public Computer(double cost, double weight, string model, string type, string operating_system, string processor)   // Конструктор с параметрами
        {
            this.cost = cost;
            this.weight = weight;
            this.model = model;
            this.type = type;
            this.operating_system = operating_system;
            this.processor = processor;
        }

        public Computer()
        {
            this.Number = number;
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
            return base.ToString() + " " + cost.ToString() + " " + weight.ToString() +  " " + processor.ToString();
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
