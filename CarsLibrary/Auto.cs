using CarsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp10
{
    public class Auto : IInit, IComparable<Auto>
    {
        //Автомобиль: бренд, год выпуска, цвет, стоимость, дорожный просвет;
        protected string brand;
        protected int year;
        protected string color;
        protected int cost;
        protected int clearance;
        protected static int count = 0;
        public IdNumber id;


        public string Brand
        {
            get => brand;

            set { brand = value; }
        }

        public int Year
        { 
            get => year; 
            set 
            {
                if (value > 1800)
                    year = value;
                else
                    throw new Exception("Еще не было автомобилей.");

            } 
        }

        public string Color
        { 
            get => color; 
            set {  color = value; } 
        }

        public int Cost
        { 
            get => cost; 
            set 
            {
                if (value > 0)
                    cost = value;
                else
                    throw new Exception("Цена не может быть отрицательной.");
            } 
        }

        public int Clearance
        {
            get => clearance;
            set 
            {
                if (value > 0)
                    cost = value;
                else
                    throw new Exception("Клиренс не может быть отрицательным.");
            }
        }

        // конструкторы
        public Auto()
        {
            brand = string.Empty;
            year = 0;   
            color = string.Empty;
            cost = 0;
            clearance = 0;
            count++;
        }
        // конструктор для явных
        public Auto(string brand, int year, string color, int cost, int clearance)
        {
            this.Brand = brand;
            this.Year = year;
            this.Color = color;
            this.Cost = cost;
            this.Clearance = clearance;
        }
        // конструктор копирования
        public Auto(Auto Cars)
        {
            brand = Cars.Brand;
            year = Cars.Year;
            color = Cars.Color;
            cost = Cars.Cost;
            clearance = Cars.Clearance;
        }

        public static int GetObjectCount()
        {
            return count;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Cost: {Cost}$");
            Console.WriteLine($"Clearance: {Clearance}");
        }

        public virtual void Init()
        {
            Console.WriteLine("Введите информацию о объекте:");

            Console.Write("Введите бренд: ");
            brand = Console.ReadLine();

            Console.Write("Введите год: ");
            year = int.Parse(Console.ReadLine());

            Console.Write("Введите цвет: ");
            color = Console.ReadLine();

            Console.Write("Введите стоимость: ");
            cost = int.Parse(Console.ReadLine());

            Console.Write("Введите клиренс: ");
            clearance = int.Parse(Console.ReadLine());
        }

        public virtual void RandomInit()
        {
            Random rnd = new Random();

            string[] brands = { "Toyota", "Honda", "Audi", "Mercedes-benz", "BMW", "Porsche"};
            brand = brands[rnd.Next(0, brands.Length)];

            year = rnd.Next(1990, 2023);

            string[] colors = { "Red", "Blue", "Green", "Black", "White" };
            color = colors[rnd.Next(0, colors.Length)];

            cost = rnd.Next(5000, 50000);

            clearance = rnd.Next(50, 200);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Auto otherCar = (Auto)obj;
            return Brand == otherCar.Brand && Year == otherCar.Year && Color == otherCar.Color && Cost == otherCar.Cost && Clearance == otherCar.Clearance;
        }

        public int CompareTo(Auto other)
        {
            if (other == null)
                return 1;
            // сортировка по году в порядке возрастания
            return this.Year.CompareTo(other.Year);
        }

        public int CompareToCost(Auto other)
        {
            if (other == null)
                return 1;
            // сортировка по году в порядке возрастания
            return this.Cost.CompareTo(other.Cost);
        }

        //public override string ToString()
        //{
        //    return $"Бренд: {brand};\n Год: {year};\n Цвет: {color};\n Цена: {cost}$";
        //}
        
        public Auto(IdNumber id)
        {
            this.id = new IdNumber(id);
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public virtual object Clone()
        {
            return new Auto(new IdNumber(id.Number));
        }
        public override string ToString()
        {
            return $"Auto: {id}";
        }

    }
    public class IdNumber
    {
        public int Number
        {
            get { return number; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Номер не должен быть отрицательным.");
                }
                number = value;
            }
        }

        private int number;

        public IdNumber(int number)
        {
            Number = number;
        }

        // конструктор копирования
        public IdNumber(IdNumber id)
        {
            Number = id.Number;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            IdNumber other = (IdNumber)obj;
            return Number == other.Number;
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
