using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
	class PrintingDevice : Equipment, IMovable
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
}
