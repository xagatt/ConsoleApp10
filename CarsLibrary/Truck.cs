using ConsoleApp10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsLibrary
{
    public class Truck : Auto, IInit
    {
        //Грузовой автомобиль: грузоподъёмность.
        private int lifting_capacity;

        public int Lifting_capacity
        {
            get { return lifting_capacity; }
            set
            {
                if (value > 0)
                    lifting_capacity = value;
                else
                    throw new Exception("Грузоподъемность не может быть отрицательной.");

            }
        }

        public Truck() : base()
        {
            lifting_capacity = 0;
        }

        public Truck(string brand, int year, string color, int cost, int clearance) : base(brand, year, color, cost, clearance)
        {
            this.Lifting_capacity = lifting_capacity;
        }

        public override void Show()
        {
            Console.WriteLine("Truck");

            base.Show();

            Console.WriteLine($"Грузоподъемность: {lifting_capacity}");
        }

        public override void Init()
        {
            base.RandomInit();

            Console.WriteLine("Введите информацию о машине:");

            Console.Write("Грузоподъемность: ");
            lifting_capacity = int.Parse(Console.ReadLine());

        }

        public override void RandomInit()
        {
            base.RandomInit();

            Random rand = new Random();

            lifting_capacity = rand.Next(800, 4000);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Truck otherTruck = (Truck)obj;
            return lifting_capacity == otherTruck.lifting_capacity;
        }


        public int TruckCount { get; set; }
        public Truck(IdNumber id, int truckCount) : base(id)
        {
            TruckCount = truckCount;
        }

        public override object Clone()
        {
            Truck clone = (Truck)base.Clone();
            clone.TruckCount = TruckCount;
            return clone;
        }
    }
}
