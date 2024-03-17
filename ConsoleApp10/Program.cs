using CarsLibrary;
using ConsoleApp9;
using System;
using System.Linq;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            IInit[] vehicles = new IInit[20];
            for (int i = 0; i < vehicles.Length; i++)
            {
                int num = random.Next(4);
                if (num == 0)
                {
                    vehicles[i] = new Passenger();
                    vehicles[i].RandomInit();
                }
                else if (num == 1)
                {
                    vehicles[i] = new Truck();
                    vehicles[i].RandomInit();
                }
                else if (num == 2)
                {
                    vehicles[i] = new Off_road();
                    vehicles[i].RandomInit();
                }
                else
                {
                    vehicles[i] = new DialClock();
                    vehicles[i].RandomInit();
                }
            }

            foreach (IInit item in vehicles)
            {
                item.Show();
                // Console.WriteLine(item);
            }

            MostExpensiveOffroad(vehicles);
            AveragePassengerSpeed(vehicles);

            static void MostExpensiveOffroad(IInit[] vehicles)
            {
                Off_road mostExpensiveOffroad = null;
                int maxCost = 0;

                foreach (var vehicle in vehicles)
                {
                    if (vehicle is Off_road offroad && offroad.Cost > maxCost)
                    {
                        mostExpensiveOffroad = offroad;
                        maxCost = offroad.Cost;
                    }
                }

                if (mostExpensiveOffroad != null)
                {
                    Console.WriteLine("Самый дорогой внедорожник:");
                    mostExpensiveOffroad.Show();
                }
                else
                {
                    Console.WriteLine("Нет внедорожников в массиве.");
                }
            }

            static void AveragePassengerSpeed(IInit[] vehicles)
            {
                var passengerVehicles = vehicles.OfType<Passenger>();
                double averageSpeed = 0;
                int count = 0;

                foreach (var vehicle in passengerVehicles)
                {
                    averageSpeed += vehicle.TopSpeed;
                    count++;
                }

                if (count > 0)
                {
                    averageSpeed /= count;
                    Console.WriteLine($"Средняя скорость легковых автомобилей: {averageSpeed}");
                }
                else
                {
                    Console.WriteLine("В массиве нет легковых автомобилей.");
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Количество объектов Passenger: {Passenger.GetObjectCount()}");
            Console.WriteLine($"Количество объектов Truck: {Truck.GetObjectCount()}");
            Console.WriteLine($"Количество объектов Off_road: {Off_road.GetObjectCount()}");
            Console.WriteLine($"Количество объектов DialClock: {DialClock.GetObjectCount()}");
            Console.WriteLine();

            Console.WriteLine("Элементы массива до сортировки:");
            foreach (Auto vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
            Console.WriteLine();

            // сортировка
            Array.Sort(vehicles);

            Console.WriteLine("Элементы массива после сортировки:");
            foreach (Auto vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }

            // поиск по году
            int searchYear = 1990;

            int index = Array.BinarySearch(vehicles, new Auto { Year = searchYear });

            if (index >= 0)
            {
                Console.WriteLine($"Автомобиль {searchYear} года выпуска, найден в массиве на позиции {index}");
            }
            else
            {
                Console.WriteLine($"Автомобиль {searchYear} года выпуска, не найден в массиве");
            }

            Console.WriteLine();
            Console.WriteLine("Массив #2");
            Console.WriteLine();

            Console.WriteLine("Элементы массива до сортировки:");
            foreach (Auto vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
            Console.WriteLine();

            // сортировка
            Array.Sort(vehicles);

            Console.WriteLine("Элементы массива после сортировки:");
            foreach (Auto vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }

            int searchCost = 50000;

            int index1 = Array.BinarySearch(vehicles, new Auto { Year = searchYear });

            if (index >= 0)
            {
                Console.WriteLine($"Автомобиль за {searchCost}$, найден в массиве на позиции {index1}");
            }
            else
            {
                Console.WriteLine($"Автомобиль за {searchCost}$, не найден в массиве");
            }


            IdNumber id = new IdNumber(123);
            Auto originalAuto = new Auto(id);

            // Клонирование объекта
            Auto clonedAuto = (Auto)originalAuto.Clone();

            // Изменение номера у клонированного объекта
            clonedAuto.id.Number = 456;

            Console.WriteLine("Исходный объект:");
            Console.WriteLine(originalAuto);

            Console.WriteLine("Клонированный объект (после изменения номера):");
            Console.WriteLine(clonedAuto);

            // Поверхностное копирование
            Auto shallowCopyAuto = (Auto)originalAuto.ShallowCopy();

            // Изменение номера у поверхностной копии
            shallowCopyAuto.id.Number = 789;

            Console.WriteLine("Исходный объект:");
            Console.WriteLine(originalAuto);

            Console.WriteLine("Поверхностная копия (после изменения номера):");
            Console.WriteLine(shallowCopyAuto);
        }
    }
}
