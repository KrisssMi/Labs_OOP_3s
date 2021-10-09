using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    class Tablet : Equipment, IMovable
    {
        private string type;
        private int memory;


        public string Type {get; set;}
        public int Memory { get; set; }

        public Tablet()
		{
		}

		public Tablet(double cost, double weight, string model, string type, int memory) : base(cost,weight,model)
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
}
