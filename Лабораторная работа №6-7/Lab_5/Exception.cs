using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6.Exceptions
{
        public class NullObject : Exception
        {
            private string message;
            public NullObject()
            {
                message = "Null-объект";
            }
            public void PrintInfo()
            {
                Console.WriteLine("Сообщение: " + message + ", метод, где возникло исключение: " + TargetSite + "\n");
            }
        }

        public class WrongDate : Exception
        {
            private string message;
            public WrongDate(string message)
            {
                this.message = message;
            }
            public void PrintInfo()
            {
                Console.WriteLine("Сообщение: " + message + ", метод, где возникло исключение: " + TargetSite+ "\n");
            }
        }

        public class EmptyStruct : Exception
        {
            public void PrintInfo()
            {
                Console.WriteLine("Сообщение: член класса не инициализирован" + "\n");
            }
        }
}
