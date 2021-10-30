using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
	class Scanner :  Equipment, IMovable
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
}
