using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_14
{
    [Serializable]
    public class Computer
    {
        public Computer() { }
        public string Brand { get; set; }
        public string Model { get; set; }

        [NonSerialized]
        public int price;

        public Computer(string brand, string model, int price)
        {
            Brand = brand;
            Model = model;
            this.price = price;
        }

        public override string ToString() => $"Brand: {Brand}, model: {Model}";
    }
}
