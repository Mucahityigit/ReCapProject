using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.AddedSuccessMessage);

        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdatedSuccessMessage);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeletedSuccessMessage);
        }

        
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.SuccessGetAllMessage);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(p => p.Id == id);
            if(result == null)
            {
                return new ErrorDataResult<Car>(Messages.ErrorGetByIdMessage);
            }
            return new SuccessDataResult<Car>(result, Messages.SuccessGetByIdMessage);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(c=>c.BrandId==id).ToList(),Messages.SuccessGetCarsByBrandIdMessage);   
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(c => c.ColorId == id).ToList(), Messages.SuccessGetCarsByBrandIdMessage);   
        }
        public IDataResult<CarDetailDto> GetCarDetailPage(int id) 
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetails().SingleOrDefault(c => c.CarId == id), Messages.SuccessGetCarsByBrandIdMessage);
        }


        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.SuccessGetCarDetailsMessage);
        }

        public IResult AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
