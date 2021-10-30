using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
	class Scanner :  Equipment, IMovable
	{
        public static int amount = 0;
		private int service_life = 7;
		private string type;
        private int speed;

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

public Scanner()
		{
		}

        public Scanner(int sl)
        {
            Service_life = sl;
        }

        public Scanner(double cost, double weight, string model, string type, int speed)             // Конструктор с параметрами
        {
            this.cost = cost;
            this.weight = weight;
            this.model = model;
            this.type = type;
            this.speed = speed;
            amount++;
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
}
