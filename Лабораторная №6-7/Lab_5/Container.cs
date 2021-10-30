using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Класс-Контейнер (Laboratory) 
для хранения разных типов объектов (в пределах иерархии) в виде списка или массива 
(использовать абстрактный тип данных). 
Класс-контейнер должен содержать методы get и set для управления списком/массивом, 
методы для добавления и удаления объектов в список/массив, 
метод для вывода списка на консоль. */

namespace Lab_6
{
    class Laboratory
    {
        public int amount = 0;

        public List<Equipment> list = new List<Equipment>();
		internal int service_life;

		public Laboratory()             /// конструктор без параметров
        {
        }
        public Laboratory(Computer firstItem, PrintingDevice secondItem, Scanner thirdItem, Tablet fourthItem, Computer fifthItem)
        {
        }

        public void Add(Equipment obj)      /// метод для добавление объектов в список
        {
            list.Add(obj);
            amount++;
        }

        public void Delete(Equipment obj)   /// метод для удаления объектов из списка
        {
            if (amount == 0)
            {
                throw new NullReferenceException("Количество объектов не может быть равно 0!");
            }
            list.Remove(obj);
            amount--;
        }

        public void Printing()              /// метод для вывода списка на консоль
        {
            foreach (var i in list)
                Console.WriteLine(i.ToString());
        }
    }
}