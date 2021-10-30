using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
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
}
