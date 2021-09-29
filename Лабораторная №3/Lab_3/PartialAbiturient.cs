using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public partial class Abiturient             //Слово partial пишется перед определением класса и позволяет описать class в разных файлах
    {
        public static void ShowCount()
        {
            Console.WriteLine($"\t\t\t\t\t\t\t\t\t--------> Текущее количество абитуриентов: {count}\n");
        }

        public override string ToString()
        {
            return $"ID: {this.id}\n" +
                $"Имя: {this.name}\n" +
                $"Фамилия: {this.surname}\n" +
                $"Отчество: {this.middle_name}\n" +
                $"Номер телефона: {this.phone_number }\n" +
                $"Адрес: {this.address}\n" +
                $"Оценки: {this.evaluation[0]} {this.evaluation[1]} {this.evaluation[2]} {this.evaluation[3]} {this.evaluation[4]}\n" +
                $"Абитуриент имеет неудовлетворительные оценки? { this.hasbadmarks}\n" +
                $"_________________________________________________________";

        }

        public override int GetHashCode()
        {
            return (int)(this.phone_number);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                throw new NullReferenceException();

            Abiturient abiturient = obj as Abiturient;
            if (abiturient == null)
                return false;
            return abiturient.id == this.id;
        }
    }
}
