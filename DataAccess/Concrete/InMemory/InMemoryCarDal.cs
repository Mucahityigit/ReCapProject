﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car(){Id=1,BrandId=1,ColorId=1,DailyPrice=250,Description="Aracımız günlük kullanıma uygundur. Az yakar."},
                new Car(){Id=2,BrandId=1,ColorId=2,DailyPrice=250,Description="Aracımız günlük kullanıma uygundur. Az yakar."},
                new Car(){Id=3,BrandId=2,ColorId=2,DailyPrice=500,Description="Aracımız günlük kullanıma uygundur. Az yakar."},
                new Car(){Id=4,BrandId=2,ColorId=1,DailyPrice=500,Description="Aracımız günlük kullanıma uygundur. Az yakar."},
                new Car(){Id=5,BrandId=3,ColorId=3,DailyPrice=300,Description="Aracımız günlük kullanıma uygundur. Az yakar."}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.FirstOrDefault(c=>c.Id==car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.BrandId == id).ToList();
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
