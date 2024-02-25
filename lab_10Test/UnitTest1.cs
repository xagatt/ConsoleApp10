using ConsoleApp10;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using CarsLibrary;
using ConsoleApp9;

namespace lab_10Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_Equals_Capacity()
        {
            // Arrange
            Truck truck1 = new Truck();
            Truck truck2 = new Truck();
            // Act
            bool result = truck1.Equals(truck2);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            DialClock clock = new DialClock(10, 30);
            //Act
            DialClock d = new DialClock(10, 30);
            //Assert
            Assert.AreEqual(clock, d);
        }
        [TestMethod]
        public void TestMethodNullTime()
        {
            DialClock expected = new DialClock(0, 0);

            DialClock m = new DialClock();

            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMethodMinutesMinus()
        {
            DialClock expected = new DialClock(5, 0);
            DialClock m = new DialClock(5, 1);

            m--;

            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMethodMinutesMinus2()
        {
            DialClock expected = new DialClock(4, 59);
            DialClock m = new DialClock(5, 0);

            m--;

            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMethodCalculateAngleStatic()
        {
            DialClock expected = new DialClock(0, 0);

            double m = 0;
            double angle;
            angle = DialClock.CalculateAngleStatic(expected.Hours, expected.Minutes);

            Assert.AreEqual(m, angle);
        }

        [TestMethod]
        public void TestMethodCalculateAngle()
        {
            DialClock expected = new DialClock(0, 0);

            double m = 0;
            double angle;
            angle = expected.CalculateAngle();

            Assert.AreEqual(m, angle);
        }

        [TestMethod]
        public void TestMethodGetObjectCount()
        {
            int count = 0;
            int m = 0;

            DialClock.GetObjectCount();

            Assert.AreEqual(m, count);
        }

        [TestMethod]
        public void TestMethodIsTwoHalf()
        {
            bool expected = true;

            bool m = DialClock.IsTwoHalf(0, 0);

            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMethodAddMin1()
        {
            DialClock expected = new DialClock(5, 50);
            DialClock m = new DialClock(5, 49);

            m++;

            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMethodAddMin2()
        {
            DialClock expected = new DialClock(5, 0);
            DialClock m = new DialClock(4, 59);

            m++;

            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMethodPlusOperator()
        {
            DialClock dc = new DialClock(10, 30);

            int minutes = 15;
            int result = dc + minutes;

            Assert.AreEqual(45, result);
        }

        [TestMethod]
        public void TestMethodMinusOperator()
        {
            DialClock dc = new DialClock(10, 30);

            int minutes = 5;
            int result = dc - minutes;

            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void TestMethodPlusOperator1()
        {
            DialClock dc = new DialClock(10, 30);

            int minutes = 15;
            int result = minutes + dc;

            Assert.AreEqual(45, result);
        }

        [TestMethod]
        public void TestMethodMinusOperator1()
        {
            DialClock dc = new DialClock(10, 30);

            int minutes = 5;
            int result = minutes - dc;

            Assert.AreEqual(25, result);
        }

        public void TestMethodPrintInfo()
        {
            DialClock clock = new DialClock(10, 30);
            string expectedOutput = "Часы: 10, Минуты: 30";
            StringWriter sw = new StringWriter();

            Console.SetOut(sw);
            clock.PrintInfo();
            string actualOutput = sw.ToString().Trim();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestMethodCounter()
        {
            DialClock clock = new DialClock(9, 15);

            int count = clock.Counter();

            Assert.AreEqual(610, count);
        }

        [TestMethod]
        public void TestMethodToString()
        {
            DialClock clock = new DialClock(9, 5);

            string result = clock.ToString();

            Assert.AreEqual("09:05", result);
        }

        [TestMethod]
        public void LiftingCapacity_SetValidValue_Success()
        {
            Truck car = new Truck();
            int expectedValue = 100;

            car.Lifting_capacity = expectedValue;

            Assert.AreEqual(expectedValue, car.Lifting_capacity);
        }

        [TestMethod]
        public void LiftingCapacity_SetInvalidValue_ExceptionThrown()
        {
            Truck car = new Truck();
            int invalidValue = -100;

            Assert.ThrowsException<Exception>(() => car.Lifting_capacity = invalidValue);
        }

        [TestMethod]
        public void OffRoad_Constructor_Default()
        {
            Off_road offRoad = new Off_road();

            Assert.IsTrue(offRoad.FourWD); 
            Assert.AreEqual("асфальт", offRoad.PathType);
        }

        [TestMethod]
        public void OffRoad_Set()
        {
            Off_road offRoad = new Off_road();

            offRoad.FourWD = false;
            offRoad.PathType = "гравий";

            Assert.IsFalse(offRoad.FourWD); 
            Assert.AreEqual("гравий", offRoad.PathType);
        }
               

        [TestMethod]
        public void OffRoad_FourWD_Set()
        {
            Off_road offRoad = new Off_road("Toyota", 2022, "Red", 30000, 150, "снег");

            offRoad.FourWD = false;

            Assert.IsFalse(offRoad.FourWD);
        }

        [TestMethod]
        public void OffRoad_PathType_Can_Be_Set()
        {
            Off_road offRoad = new Off_road("Toyota", 2022, "Red", 30000, 150, "снег");

            offRoad.PathType = "снег";

            Assert.AreEqual("снег", offRoad.PathType);
        }

        [TestMethod]
        public void Seats_GreaterThanZero_SetSeats()
        {
            Passenger car = new Passenger();

            car.Seats = 4;

            Assert.AreEqual(4, car.Seats);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Seats_LessThanOrEqualToZero_ThrowException()
        {
            Passenger car = new Passenger();

            car.Seats = 0;

        }

        [TestMethod]
        public void TopSpeed_GreaterThanZero_SetTopSpeed()
        {
            Passenger car = new Passenger();

            car.TopSpeed = 200;

            Assert.AreEqual(200, car.TopSpeed);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TopSpeed_LessThanOrEqualToZero_ThrowException()
        {
            Passenger car = new Passenger();

            car.TopSpeed = -50;
        }

        [TestMethod]
        public void Year_SetValidValue_Success()
        {
            Auto auto = new Auto();

            auto.Year = 2000;

            Assert.AreEqual(2000, auto.Year);
        }

        [TestMethod]
        public void Year_SetInvalidValue_ThrowsException()
        {
            Auto auto = new Auto();

            Assert.ThrowsException<Exception>(() => auto.Year = 1500);
        }

        [TestMethod]
        public void Cost_SetValidValue_Success()
        {
            Auto auto = new Auto();

            auto.Cost = 10000;

            Assert.AreEqual(10000, auto.Cost);
        }

        [TestMethod]
        public void Cost_SetInvalidValue_ThrowsException()
        {
            Auto auto = new Auto();

            Assert.ThrowsException<Exception>(() => auto.Cost = -100);
        }

        [TestMethod]
        public void Clearance_SetValidValue_Success()
        {
            Auto auto = new Auto();

            auto.Clearance = 150;

            Assert.AreEqual(150, auto.Clearance);
        }

        [TestMethod]
        public void Clearance_SetInvalidValue_ThrowsException()
        {
            Auto auto = new Auto();

            Assert.ThrowsException<Exception>(() => auto.Clearance = -50);
        }

        [TestMethod]
        public void CopyConstructor_SameValues()
        {
            IdNumber id = new IdNumber(123);
            Auto originalAuto = new Auto(id);

            Auto copiedAuto = new Auto(originalAuto);

            Assert.AreNotSame(originalAuto, copiedAuto);
            Assert.AreEqual(originalAuto.Brand, copiedAuto.Brand);
            Assert.AreEqual(originalAuto.Year, copiedAuto.Year);
            Assert.AreEqual(originalAuto.Color, copiedAuto.Color);
            Assert.AreEqual(originalAuto.Cost, copiedAuto.Cost);
        }

        [TestMethod]
        public void GetObjectCount_ReturnsCorrectCount()
        {
            int initialCount = Auto.GetObjectCount();
            IdNumber id = new IdNumber(123);
            Auto auto = new Auto(id);

            int countAfterCreation = Auto.GetObjectCount();

            Assert.AreEqual(initialCount, countAfterCreation);
        }

        [TestMethod]
        public void CompareTo_ReturnsNegativeYear()
        {
            Auto auto1 = new Auto(new IdNumber(1)) { Year = 2000 };
            Auto auto2 = new Auto(new IdNumber(2)) { Year = 2020 };

            int result = auto1.CompareTo(auto2);

            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void CompareTo_ReturnsPositiveYear()
        {
            Auto auto1 = new Auto(new IdNumber(1)) { Year = 2020 };
            Auto auto2 = new Auto(new IdNumber(2)) { Year = 2000 };

            int result = auto1.CompareTo(auto2);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CompareTo_ReturnsZeroYear()
        {
            Auto auto1 = new Auto(new IdNumber(1)) { Year = 2020 };
            Auto auto2 = new Auto(new IdNumber(2)) { Year = 2020 };

            int result = auto1.CompareTo(auto2);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareToCost_ReturnsNegativeCost()
        {
            Auto auto1 = new Auto(new IdNumber(1)) { Cost = 20000 };
            Auto auto2 = new Auto(new IdNumber(2)) { Cost = 50000 };

            int result = auto1.CompareToCost(auto2);

            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void CompareToCost_ReturnsPositiveCost()
        {
            Auto auto1 = new Auto(new IdNumber(1)) { Cost = 50000 };
            Auto auto2 = new Auto(new IdNumber(2)) { Cost = 20000 };

            int result = auto1.CompareToCost(auto2);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CompareToCost_ReturnsZeroCost()
        {
            Auto auto1 = new Auto(new IdNumber(1)) { Cost = 50000 };
            Auto auto2 = new Auto(new IdNumber(2)) { Cost = 50000 };

            int result = auto1.CompareToCost(auto2);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ToString_ReturnsCorrectString()
        {
            IdNumber id = new IdNumber(123);

            string result = id.ToString();

            Assert.AreEqual("123", result);
        }

        [TestMethod]
        public void Number_SetValidNumber()
        {
            int validNumber = 123;
            IdNumber id = new IdNumber(5);

            id.Number = validNumber;

            Assert.AreEqual(validNumber, id.Number);
        }

        [TestMethod]
        public void Number_SetNegativeNumberException()
        {
            int negativeNumber = -123;
            IdNumber id = new IdNumber(5);

            Assert.ThrowsException<ArgumentException>(() => id.Number = negativeNumber);
        }

        [TestMethod]
        public void ShallowCopy_ReturnsValues()
        {
            IdNumber id = new IdNumber(123);
            Auto originalAuto = new Auto(id);

            Auto shallowCopyAuto = (Auto)originalAuto.ShallowCopy();

            Assert.AreNotSame(originalAuto, shallowCopyAuto);
            Assert.AreEqual(originalAuto.ToString(), shallowCopyAuto.ToString());
        }

        [TestMethod]
        public void Clone_ReturnsValues()
        {
            IdNumber id = new IdNumber(123);
            Auto originalAuto = new Auto(id);

            Auto clonedAuto = (Auto)originalAuto.Clone();

            Assert.AreNotSame(originalAuto, clonedAuto); 
            Assert.AreEqual(originalAuto.ToString(), clonedAuto.ToString()); 
        }

        [TestMethod]
        public void ToString_Returns1()
        {
            IdNumber id = new IdNumber(123);
            Auto auto = new Auto(id);

            string result = auto.ToString();

            Assert.AreEqual("Auto: 123", result);
        }

        [TestMethod]
        public void OffRoadCount_SetValue_ReturnsSetValue()
        {
            IdNumber id = new IdNumber(123);
            Off_road offRoad = new Off_road(id, 0);

            offRoad.Off_roadCount = 10;

            Assert.AreEqual(10, offRoad.Off_roadCount);
        }

        [TestMethod]
        public void PassengerCount_SetValue_ReturnsSetValue()
        {
            IdNumber id = new IdNumber(123);
            Passenger passenger = new Passenger(id, 0);

            passenger.PassengerCount = 10;

            Assert.AreEqual(10, passenger.PassengerCount);
        }

        [TestMethod]
        public void TruckCount_SetValue_ReturnsSetValue()
        {
            IdNumber id = new IdNumber(123);
            Truck truck = new Truck(id, 0);

            truck.TruckCount = 10;

            Assert.AreEqual(10, truck.TruckCount);
        }

        
    }
}