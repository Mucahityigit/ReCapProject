using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            //if(rental == null)
            //{
            //    return new ErrorResult(Messages.ErrorEmpityMessage);
            //}
            //else
            //{
               //var result =  _rentalDal.GetAll(r => r.CarId == rental.CarId);
               // var check = 0;
               // foreach(var item in result)
               // {
               //     if (item.ReturnDate > item.RentDate)
               //     {
               //         check++;
               //     }
               // }
                //if(check == result.Count)
                //{
                    _rentalDal.Add(rental);
                    return new SuccessResult(Messages.AddedSuccessMessage);
                //}
                //return new ErrorResult(Messages.ErrorReturnDateMessage);

            //}
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.DeletedSuccessMessage);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.SuccessGetAllMessage);
        }

        public IDataResult<Rental> GetById(int id)
        {
            var result = _rentalDal.Get(p => p.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Rental>(Messages.ErrorGetByIdMessage);
            }
            return new SuccessDataResult<Rental>(result, Messages.SuccessGetByIdMessage);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.UpdatedSuccessMessage);
        }
    }
}
