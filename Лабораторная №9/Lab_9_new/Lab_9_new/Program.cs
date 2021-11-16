using System;

namespace Lab_9_new
{
	class Program
	{
		static void Main(string[] args)
		{

            var first_object = new Items("Мирный житель");
            var second_object = new Items("Мафия");
           
            Game.OnHeal += first_object.ChangeLife;
            first_object.ShowInfo();

            Game.OnAttack += second_object.ChangeLife;
            second_object.ShowInfo();

            Console.WriteLine();

            Game.Attack(first_object, "4.0");
            first_object.ShowInfo();

            Game.StartWorkWithItem(first_object);
            first_object.ShowInfo();

            Game.EndWorkWithItem(first_object);
            first_object.ShowInfo();

            Game.Heal(second_object, "6.0");
            second_object.ShowInfo();
        }
	}
}
