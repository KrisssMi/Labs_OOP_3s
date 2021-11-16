using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab_10
{
    class Program
    {
        static void Main(string[] args)
        {
			First();
			Second();
			Third();
		}



        private static void First()
		{
            /* 1. Создайте класс по варианту, определите в нем свойства и методы, реализуйте указанный интерфейс и другие при необходимости, 
             соберите объекты класса в коллекцию (можно сделать специальный класс с вложенной коллекцией и методами ею управляющими), продемонстрируйте работу с ней 
            (добавление/удаление/поиск/вывод): */

            var myCollection = new MyCollection<Student>();
            var enotherCollection = myCollection;

            var stud_null = new Student();
            var stud_2 = new Student("Boris", 20);
            var array = new Student[7];

            myCollection.Add(new Student());
            myCollection.Add(new Student("Anna", 18));
            myCollection.Add(new Student("Gleb", 19));
            myCollection.Add(new Student("Ilya", 19));
            myCollection.Add(new Student("Mary", 18));
            myCollection.Add(new Student("Jony", 20));
            myCollection.Add(stud_2);

            myCollection.Show();                                    // вывод коллекции
            myCollection.Insert(1, stud_null);                      // вставка нулевого студента на первое место в коллекции
            Console.WriteLine(myCollection.Contains(stud_null));    // проверка на наличие
            Console.WriteLine($"  Индекс нулевого студента равен -> {myCollection.IndexOf(stud_null)}");

            Console.WriteLine();
            myCollection.Remove(stud_null);
            myCollection.Remove(stud_2);
            myCollection.RemoveAt(0);
            myCollection.Show();
            Console.WriteLine(myCollection[2]);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\tДобавление всех объектов в массив: ");
            myCollection.CopyTo(array, 2);
            foreach (var i in array)
                Console.Write($"{i}");
            Console.WriteLine();

            myCollection.Clear();
            myCollection.Show();
            Console.WriteLine($"Cравнение моей очищенной коллекции с пустой коллекцией enotherCollection: ____{myCollection.Equals(enotherCollection)}____");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }



        private static void Second()
		{
            /* 2. Создайте универсальную коллекцию в соответствии с вариантом задания и заполнить ее данными встроенного типа .Net (int, char,…). 
                     +   a. Выведите коллекцию на консоль
                     +   b. Удалите из коллекции n последовательных элементов
                     +   c. Добавьте другие элементы (используйте  все  возможные  методы добавления для вашего типа коллекции).
                     +   d. Создайте вторую  коллекцию (из таблицы  выберите  другой  тип коллекции) и заполните ее данными из первой коллекции.
                     +   e. Выведите  вторую  коллекцию  на  консоль.
                     +   f. Найдите во второй коллекции заданное значение */

            Console.ForegroundColor = ConsoleColor.White;
            Queue<int> numbers = new Queue<int>();      // создание экземпляра очереди типа int

            numbers.Enqueue(3);             // очередь 3
            numbers.Enqueue(5);             // очередь 3, 5
            numbers.Enqueue(8);             // очередь 3, 5, 8

            // получаем первый элемент очереди
            int queueElement = numbers.Dequeue();   //теперь очередь 5, 8
            Console.WriteLine($" Элемент, который мы удалили: {queueElement}");
            Console.WriteLine($"  Количество оставшихся элементов в очереди: {numbers.Count}");

            Queue<Student> persons = new Queue<Student>();
            persons.Enqueue(new Student() { name = "Tom" });
            persons.Enqueue(new Student() { name = "Bill" });
            persons.Enqueue(new Student() { name = "John" });
            persons.Enqueue(new Student() { name = "Lara" });

            // получаем первый элемент без его извлечения
            Student pp = persons.Peek();
            Console.WriteLine($"   Первый элемент без его извлечения: {pp.name}");
            Console.WriteLine("    Сейчас в очереди {0} человек", persons.Count);

            // теперь в очереди Tom, Bill, John, Lara
            foreach (Student p in persons)
            {
                Console.Write($" {p.name} : ");
            }


            Console.WriteLine("\n");
            HashSet<int> Set = new HashSet<int>();
            // заполняем HashSet значениями от 0 до 10
            for (int i = 0; i < 10; i++)
                Set.Add(i);
            Console.WriteLine(" Вывод сета: ");
            foreach (int item in Set)
            {
                Console.Write(item + " ");
            }
            // удаляем из HashSetа значения от 3 до 5 (3,4)
            for (int i = 3; i < 5; i++)
                Set.Remove(i);

            Console.WriteLine();
            Console.WriteLine("  Вывод сета после удаления двух элементов: ");
            foreach (int item in Set)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Введите число для поиска: ");
            int? number = Convert.ToInt32(Console.ReadLine());
            foreach (int item in Set)
            {
                if (item == number) Console.Write("Число имеется ");
            }
            Console.WriteLine();
        }



        private static void Third()
		{
            /* 3. Создайте объект наблюдаемой коллекции ObservableCollection<T>. 
            Создайте произвольный метод и зарегистрируйте его на событие CollectionChange. 
            Напишите демонстрацию с добавлением и удалением элементов. В качестве типа T используйте свой класс из таблицы. */

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            var data = new ObservableCollection<Student>();
            Student st1 = new Student("Sergey", 19);
            Student st2 = new Student("Polly", 18);
            Student st3 = new Student("Milky", 18);
            data.CollectionChanged += Data_CollectionChanged;
            data.Add(st1);
            data.Add(st2);
            data.Add(st3);

            Console.Write("\n\t\tНаблюдаемая коллекция:   \n");
            foreach (Student i in data)
            {
                Console.Write($"{i}");
            }
            data.Remove(st3);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Data_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
            if (e.Action == NotifyCollectionChangedAction.Add)
                Console.WriteLine(" _______> Add comlete <_______ ");
            else if (e.Action == NotifyCollectionChangedAction.Remove) 
                Console.WriteLine(" _______> Remove complete <_______ ");
        }
	}
}