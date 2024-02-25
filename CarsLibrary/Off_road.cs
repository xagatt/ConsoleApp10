using ConsoleApp10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsLibrary
{
    public class Off_road : Auto, IInit
    {
        //Внедорожник: полный привод (логическое поле), тип бездорожья;
        private bool fourWD;
        private string pathType;

        public bool FourWD 
        {
            get { return fourWD; }
            set { fourWD = value; }
        }

        public string PathType
        { 
            get { return pathType; } 
            set { pathType = value; } 
        }

        public Off_road() : base()
        {
            fourWD = true;
            pathType = "асфальт";
            count++;
        }

        public Off_road(string brand, int year, string color, int cost, int clearance, string pathType) : base(brand, year, color, cost, clearance)
        {
            this.FourWD = fourWD;
            this.PathType = pathType;
        }

        public override void Show()
        {
            Console.WriteLine("Off_road");

            base.Show();

            Console.WriteLine("Полный привод: " + (fourWD ? "Да" : "Нет"));
            Console.WriteLine($"Тип бездорожья: {pathType}" );
        }

        public override void Init()
        {
            base.Show();

            Console.WriteLine("Введите информацию о машине:");

            Console.Write("Есть ли полный привод (true/false): ");
            bool.TryParse(Console.ReadLine(), out fourWD);

            Console.Write("Введите тип дороги (гравий/асфальт/грунт/снег/болото): ");
            pathType = Console.ReadLine();
        }

        public override void RandomInit()
        {
            base.RandomInit();

            Random rnd = new Random();

            fourWD = rnd.Next(2) == 1; 

            string[] pathTypes = { "грунт", "асфальт", "гравий", "снег", "болото"};
            pathType = pathTypes[rnd.Next(0, pathTypes.Length)];
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Off_road otherOff_road = (Off_road)obj;
            return FourWD == otherOff_road.FourWD && PathType == otherOff_road.PathType;
        }

        public int Off_roadCount { get; set; }
        public Off_road(IdNumber id, int off_roadCount) : base(id)
        {
            Off_roadCount = off_roadCount;
        }

        public override object Clone()
        {
            Off_road clone = (Off_road)base.Clone();
            clone.Off_roadCount = Off_roadCount;
            return clone;
        }
    }
}