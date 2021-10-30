using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* ЧАСТИЧНЫЙ КЛАСС. 
Имеет несколько файлов с определением одного и того же класса, 
и при компиляции все эти определения будут скомпилированы в одно, 
при этом нам не нужно вновь инициализировать поля и свойста, имеющиеся в этом же классе, 
но в другом файле. */

namespace Lab_6
{
	partial class Equipment : Product
	{
		internal int service_life;
		internal int Service_life;

		public Equipment(double cost, double weight, string model) : base(cost, weight)
		{
			Model = model;
		}



        ///-----------------------СТРУКТУРА---------------------------------
        struct Technics      // размещение в стеке
        {
            public int power;                           // Мощность
            public int energy_consumption;              // Энергопотребление
            public int size;                            // Размер
            public int warranty;                        // Гарантия
            public int service_life;                    // Срок службы
            public string manufacturing_country;        // Страна-производитель

            public int Service_life                     // Свойство
            {
                get => service_life;
                set => service_life = value;
            }

            public Technics(int Power, int Energy_consumption, int Size, int Warranty, int Service_life, string Manufacturing_country)       // Конструктор
            {
                power = Power;
                energy_consumption = Energy_consumption;
                size = Size;
                warranty = Warranty;
                service_life = Service_life;
                manufacturing_country = Manufacturing_country;
            }
        }



        ///-----------------------ПЕРЕЧИСЛЕНИЯ---------------------------------
        /* набор логически связанных констант */
        protected enum Manufacturing_Country : int   // по умолчанию используется тип int
        {
            Russia,     // значение: 0;
            USA,        // значение: 1;
            China,      // значение: 2;
            Japan,      // значение: 3;
            Belgium,    // значение: 4;
            Belarus,    // значение: 5;
            Lithuania,  // значение: 6;
            Poland      // значение: 7;
        }

        protected enum Types
        {
            Computer,
            Printer,
            Tablet,
            Scanner
        }
    }
}
