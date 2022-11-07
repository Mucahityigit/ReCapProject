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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand car)
        {
            _brandDal.Add(car);
            return new SuccesResult(Messages.AddedSuccessMessage);
        }
        public IResult Update(Brand car)
        {
            _brandDal.Update(car);
            return new SuccesResult(Messages.UpdatedSuccessMessage);
        }

        public IResult Delete(Brand car)
        {
            _brandDal.Delete(car);
            return new SuccesResult(Messages.DeletedSuccessMessage);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var result = _brandDal.GetAll();

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.SuccessGetAllMessage);
        }
        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.Id == id),Messages.SuccessGetByIdMessage);
        }

    }
}
