using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
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
}
