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
            Console.WriteLine(getById.Data.Id + "   " + getById.Data.BrandId + "   " + getById.Data.ColorId + "   " + getById.Data.ModelYear + "   " + getById.Data.DailyPrice + "   " + getById.Data.Description);

            Console.WriteLine("CarId    BrandId    ColorId    ModelYear    DailyPrice    Description");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine();
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Id + "   " + car.BrandId +"   " + car.ColorId + "   " + car.ModelYear + "   " + car.DailyPrice + "   " + car.Description);
            }

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                Console.WriteLine("CarName    BrandName    ColorName    DailyPrice");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine();
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "   " + car.BrandName + "   " + car.ColorName + "   " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
