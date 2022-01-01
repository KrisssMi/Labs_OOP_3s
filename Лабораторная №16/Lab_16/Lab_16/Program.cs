using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Collections.Concurrent;

namespace Lab_16
{
	class Program
	{
		static void Main(string[] args)
		{
            /* 1. Используя TPL создайте длительную по времени задачу (на основе Task) на выбор: умножение вектора размера 100000 на число. */
            //First();
            Console.WriteLine();

            /* 2. Реализуйте второй вариант этой же задачи с токеном отмены CancellationToken и отмените задачу. */
            //Second();
            Console.WriteLine();

            /* 3. Создайте три задачи с возвратом результата и используйте их для выполнения четвертой задачи. Например, расчет по формуле. */
            //Third();
            Console.WriteLine();

            /* 4. Создайте задачу продолжения (continuation task) в двух вариантах:
                    1) C ContinueWith - планировка на основе завершения множеств,  предшествующих задач
                    2) На основе объекта ожидания и методов GetAwaiter(), GetResult(); */
            //Forth();
            Console.WriteLine();


            /* 5. Используя Класс Parallel распараллельте вычисления циклов For(), ForEach(). Например, на выбор: обработку (преобразования) последовательности, 
             * генерация нескольких массивов по 1000000 элементов, быстрая сортировка последовательности, обработка текстов (удаление, замена). 
             * Оцените производительность по сравнению с обычными циклами. */
            //Fifth();
            Console.WriteLine();


            /* 6. Используя Parallel.Invoke() распараллельте выполнение блока операторов. */
            //Sixth();
            Console.WriteLine();


            /* 7. Используя Класс BlockingCollection реализуйте следующую задачу: Есть 5 поставщиков бытовой техники, 
             * они завозят уникальные товары на склад (каждый по одному) и 10 покупателей – покупают все подряд, если товара нет - уходят. 
             * В вашей задаче: cпрос превышает предложение. Изначально склад пустой. У каждого поставщика своя скорость завоза товара. 
             * Каждый раз при изменении состоянии склада выводите наименования товаров на складе. */
            //Seventh();
            Console.WriteLine();


            /* 8. Используя async и await организуйте асинхронное выполнение любого метода. */
            //Eighth();
            Console.WriteLine();

            Console.ReadKey();
		}


        static void First()                         // создание длительной по времени задачи
        {
            for (int i = 0; i < 5; i++)
            {
                Stopwatch sw = new Stopwatch();     // точное измерение затраченного времени
                sw.Start();
                Task task = new Task(() => MulByVector(10000));
                task.Start();
                Console.WriteLine($"ID: {task.Id}, статус: {task.Status}");                 // идентификатор текущей задачи
                task.Wait();
                Console.WriteLine($"ID: {task.Id}, статус: {task.Status}");                 // статус задачи
                sw.Stop();
                Console.WriteLine($"Производительность: {sw.ElapsedMilliseconds}ms");       // оценка производительности выполнения 
                Console.WriteLine();
            }
        }
        static void MulByVector(int k, object ob = null)                                    // переменожение векторов
        {
            Random random = new Random();
            List<int> vector = new List<int>();
            for (int i = 0; i < k; i++)
            {
                vector.Add(random.Next(1, 10));
            }
            vector = vector.Select(x => x * 10).ToList();
        }


        static void Second()
        {
            CancellationTokenSource cancellation = new CancellationTokenSource();       // Структура CancellationToken - токен отмены
            Task task = Task.Run(() => MulByVector(1000, cancellation), cancellation.Token);
            try
            {
                cancellation.Cancel();      // отменяем задачи
                task.Wait();
            }
            catch (Exception)
            {
                if (task.IsCanceled)    
                    Console.WriteLine("Задача отменена");
            }
        }


        static void Third()         // три задачи с возвратом результата и использование их для выполнения четвертой задачи
        {
            Task<int> first = new Task<int>(() => new Random().Next(1, 9) * 100);
            Task<int> second = new Task<int>(() => new Random().Next(0, 9) * 10);
            Task<int> third = new Task<int>(() => new Random().Next(0, 9));

            first.Start();
            second.Start();
            third.Start();
            first.Wait();
            second.Wait();
            third.Wait();

            Task<int> number = new Task<int>(() => first.Result + second.Result + third.Result);
            number.Start();
            Console.WriteLine($"Number: {number.Result}");
        }


        static void Forth()             // задача продолжения 
        {
            Task<int> task4 = new Task<int>(() => 100 + 10 + 1);
            Task show = task4.ContinueWith(sum => Console.WriteLine($"Sum = {sum.Result}"));
            task4.Start();
            show.Wait();

            Task<double> sqrt = new Task<double>(() => Math.Sqrt(49));
            TaskAwaiter<double> awaiter = sqrt.GetAwaiter();      // здесь хранится временный объект, который ожидает завершения асинхронной задачи
            awaiter.OnCompleted(() => Console.WriteLine($"Result is: {sqrt.Result}"));
            sqrt.Start();
            sqrt.Wait();
            awaiter.GetResult();
            Thread.Sleep(10);
        }


        static void Factorial(int num)
        {
            int result = 1;
            for (int i = 1; i <= num; i++)
                result *= i;

            Console.WriteLine($"Факториал числа {num} равен {result}");
        }

        static void Fifth()
		{
            int[] arr1 = new int[1000000];
            int[] arr2 = new int[1000000];
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            Parallel.For(0, arr1.Length, t => arr1[t] = t);
            stopwatch2.Stop();
            Console.WriteLine($"Parallel.For: {stopwatch2.Elapsed}");       // вывод повторяющегося события

            Stopwatch stopwatch3 = new Stopwatch();
            stopwatch3.Start();
            for (int i = 0; i < arr2.Length; i++)
                arr2[i] = i + 1;

            stopwatch3.Stop();
            Console.WriteLine("foreach: " + stopwatch3.Elapsed);            // вывод повторяющегося события
            Stopwatch stopwatch4 = new Stopwatch();
            stopwatch4.Start();
            Parallel.ForEach<int>(new List<int>() { 1, 2, 3, 4 }, Factorial);
            stopwatch4.Stop();
            Console.WriteLine("Parallel.Foreach: " + stopwatch4.Elapsed);   // вывод повторяющегося события

            Stopwatch stopwatch5 = new Stopwatch();
            stopwatch5.Start();
            foreach (var m in new List<int>() { 1, 2, 3, 4 })
            {
                Factorial(m);
            }
            stopwatch5.Stop();
            Console.WriteLine("foreach: " + stopwatch5.Elapsed);              // вывод повторяющегося события
            Console.WriteLine();
        }


        static void Sixth()           // Используя Parallel.Invoke() распараллельте выполнение блока операторов
        {
            int count = 0;
            int maxCount = 100;
            Parallel.Invoke( () =>      // в качестве параметра принимает массив объектов Action
            {
                while (count < maxCount)        // выполняется на одном ядре целевой машины
                {
                    count++;
                    Console.WriteLine($"1: {count}");
                }
            },               () =>
            {
                while (count < maxCount)         // выполняется на другом ядре целевой машины
                {
                    count++;
                    Console.WriteLine($"2: {count}");
                }
            });
        }


        static void Seventh()
        {
            BlockingCollection<string> bc = new BlockingCollection<string>(5);      // Коллекция, которая осуществляет блокировку и ожидает, пока не появится возможность
                                                                                    // выполнить действие по добавлению или извлечению элемента

            Task[] sellers = new Task[10]
            {
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Стол"); } }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Шкаф"); } }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Зеркало"); } }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Бра"); } }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Подоконник"); } }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Микроволновка"); } }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Кровать"); } }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Дверь"); } }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Вазон"); } }),
                new Task(() => { while (true) { Thread.Sleep(700); bc.Add("Стул"); } })
            };

            Task[] consumers = new Task[5]
            {
                new Task(() => { while (true) { Thread.Sleep(300); bc.Take(); } }),
                new Task(() => { while (true) { Thread.Sleep(500); bc.Take(); } }),
                new Task(() => { while (true) { Thread.Sleep(500); bc.Take(); } }),
                new Task(() => { while (true) { Thread.Sleep(400); bc.Take(); } }),
                new Task(() => { while (true) { Thread.Sleep(250); bc.Take(); } })
            };

            foreach (var i in sellers)
                if (i.Status != TaskStatus.Running)
                    i.Start();

            foreach (var i in consumers)
                if (i.Status != TaskStatus.Running)
                    i.Start();

            int count = 1;
            while (true)
            {
                if (bc.Count != count && bc.Count != 0)
                {
                    count = bc.Count;
                    Thread.Sleep(500);
                    Console.Clear();
                    Console.WriteLine("--- СКЛАД ---");

                    foreach (var i in bc)
                        Console.WriteLine(i);
                }
            }
        }

        static void Eighth()            // Используя async и await организуйте асинхронное выполнение любого метода
        {
            void Factorial()
            {
                int result = 1;
                for (int i = 1; i <= 6; i++)
                {
                    result *= i;
                }
                Thread.Sleep(1000);
                Console.WriteLine($"Факториал равен {result}");
            }

            async void FactorialAsync()     // Асинхонный метод (слово async, которое указывается в определении метода, не делает автоматически метод асинхронным.
                                            // Оно лишь указывает, что данный метод может содержать одно или несколько выражений await)
            {
                Console.WriteLine("Начало метода FactorialAsync");  // выполняется синхронно
                await Task.Run(() => Factorial());                  // выполняется асинхронно
                Console.WriteLine("Конец метода FactorialAsync");
            }
            FactorialAsync();
        }
        //  Преимущество асинхронных методов - асинхронная задача, которая может выполняться довольно долгое время, не блокирует метод Main,
        //  и мы можем продолжать работу с ним, например, вводить и обрабатывать данные.
    }
}
