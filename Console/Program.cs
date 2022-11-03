using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

namespace ReCapProject // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarTest();
        }

        private static void CarTest()
        {
            ICarService carManager = new CarManager(new EfCarDal());

            var getById = carManager.GetById(5);
            Console.WriteLine(getById.Id + "   " + getById.BrandId + "   " + getById.ColorId + "   " + getById.ModelYear + "   " + getById.DailyPrice + "   " + getById.Description);

            Console.WriteLine("CarId    BrandId    ColorId    ModelYear    DailyPrice    Description");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine();
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "   " + car.BrandId +"   " + car.ColorId + "   " + car.ModelYear + "   " + car.DailyPrice + "   " + car.Description);
            }

            Console.WriteLine("CarName    BrandName    ColorName    DailyPrice");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + "   " + car.BrandName + "   " + car.ColorName + "   " + car.DailyPrice);
            }
        }
    }
}
