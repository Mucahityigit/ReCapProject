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
            ICarService carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car() { Description="Tesla", DailyPrice=505});

            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.BrandId + " numaralı markaya ait araç : " + car.Id);
            }
        }
    }
}
