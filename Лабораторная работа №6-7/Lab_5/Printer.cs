using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
	class Printer
	{
        public virtual void IAmPrinting(Equipment tech)     
        {
            Console.WriteLine(tech.GetType().Name);     // определение типа объекта
        }
    }
}
