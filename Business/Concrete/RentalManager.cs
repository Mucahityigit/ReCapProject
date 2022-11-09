using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
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

        public IResult Add(Rental rental)
        {
            if(rental == null)
            {
                return new ErrorResult(Messages.ErrorEmpityMessage);
            }
            else
            {
               var result =  _rentalDal.GetAll(r => r.CarId == rental.CarId);
                var check = 0;
                foreach(var item in result)
                {
                    if (item.ReturnDate > item.RentDate)
                    {
                        check++;
                    }
                }
                if(check == result.Count)
                {
                    _rentalDal.Add(rental);
                    return new SuccesResult(Messages.AddedSuccessMessage);
                }
                return new ErrorResult(Messages.ErrorReturnDateMessage);

            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccesResult(Messages.DeletedSuccessMessage);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.SuccessGetAllMessage);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == id), Messages.SuccessGetByIdMessage);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccesResult(Messages.UpdatedSuccessMessage);
        }
    }
}
