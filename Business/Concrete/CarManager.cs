using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
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

        public IResult Add(Car car)
        {
            if (car.Description.Length >= 2)
            {
                if (car.DailyPrice > 0)
                {
                    _carDal.Add(car);
                    return new SuccesResult(Messages.AddedSuccessMessage);
                }
                else
                    return new ErrorResult(Messages.ErrorDailyPriceMessage);
            }
            else
            {
                return new ErrorResult(Messages.AddedErrorMessage);
            }
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccesResult(Messages.UpdatedSuccessMessage);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccesResult(Messages.DeletedSuccessMessage);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.SuccessGetAllMessage);
        }
        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(p => p.Id == id);
            if(result == null)
            {
                return new ErrorDataResult<Car>(Messages.ErrorGetByIdMessage);
            }
            return new SuccessDataResult<Car>(result, Messages.SuccessGetByIdMessage);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id),Messages.ErrorGetCarsByBrandIdMessage);   
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id),Messages.SuccessGetCarsByColorIdMessage);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.SuccessGetCarDetailsMessage);
        }
    }
}
