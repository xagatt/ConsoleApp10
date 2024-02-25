using ConsoleApp10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsLibrary
{
    public class Passenger : Auto, IInit
    {
        //Легковой: количество мест, максимальная скорость;
        private int seats;
        private int topSpeed;
        private int count = 0;

        public int Seats
        {
            get { return seats; }
            set
            {
                if (value > 0)
                    seats = value;
                else
                    throw new Exception("Должно быть хоть одно сиденье.");

            }
        }

        public int TopSpeed
        {
            get { return topSpeed; }
            set
            {
                if (value > 0)
                    topSpeed = value;
                else
                    throw new Exception("Скорость не может быть отрицательной");

            }
        }

        public Passenger() : base()
        {
            seats = 0;
            topSpeed = 0;
            count++;
        }

        public Passenger(string brand, int year, string color, int cost, int clearance) : base(brand, year, color, cost, clearance)
        {
            this.Seats = seats;
            this.TopSpeed = topSpeed;
        }


        public override void Show()
        {
            Console.WriteLine("Passenger");

            base.Show();

            Console.WriteLine($"Количество мест: {seats}");
            Console.WriteLine($"Максимальная скорость: {topSpeed}");
        }

        public override void Init()
        {
            base.Show();

            Console.WriteLine("Введите информацию о машине:");

            Console.Write("Количество мест: ");
            seats = int.Parse(Console.ReadLine());

            Console.Write("Введите максимальную скорость: ");
            topSpeed = int.Parse(Console.ReadLine());
        }

        public override void RandomInit()
        {
            base.RandomInit();

            Random rand = new Random();

            Seats = rand.Next(1, 8);
            TopSpeed = rand.Next(120, 400);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Passenger otherPassenger = (Passenger)obj;
            return Seats == otherPassenger.Seats && TopSpeed == otherPassenger.TopSpeed;
        }

        public int PassengerCount { get; set; }
        public Passenger(IdNumber id, int passengerCount) : base(id)
        {
            PassengerCount = passengerCount;
        }

        public override object Clone()
        {
            Passenger clone = (Passenger)base.Clone();
            clone.PassengerCount = PassengerCount;
            return clone;
        }

    }
}
