using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
	class Game
	{
        public delegate void Items(List<string> list, string actionObject);
        public event Items OnAttack;    /// атака          
        public event Items OnHeal;      /// лечение


        public void Strike(List<string> list)
        {
            Console.Write("\n\n\tВведите номер объекта [1-7], который хотите атаковать: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string killedPerson = list[number - 1];
            OnAttack?.Invoke(list,killedPerson);        /// Событие связано с делегатом Items и возникает в методе Strike
        }

        public void Сure(List<string> list)
        {
			Console.Write("\n\tВведите номер объекта [1-7], который хотите вылечить: ");
            int number = Convert.ToInt32(Console.ReadLine());
            string revivedPerson = list[number - 1];
			OnHeal?.Invoke(list, revivedPerson);
		}
    }
}
