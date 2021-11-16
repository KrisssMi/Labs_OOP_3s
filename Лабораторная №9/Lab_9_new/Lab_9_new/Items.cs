using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9_new
{
	public class Items
	{
        public Items()
        {
        }

        public Items(string name)
        {
            Name = name;
        }

        public string Name { get; set; } = "Default";
        public string Life { get; set; } = "5.0";
        public bool IsLiving { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} has lifes {Life}. It's living now - {IsLiving}");
        }

        public void ChangeLife(string newLife)
        {
            Life = newLife;
        }

        public void living_true()
        {
            IsLiving = true;
        }

        public void living_false()
        {
            IsLiving = false;
        }
    }
}
