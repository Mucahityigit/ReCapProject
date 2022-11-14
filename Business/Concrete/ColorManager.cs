using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Entities.Concrete.Color;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccesResult(Messages.AddedSuccessMessage);
        }
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccesResult(Messages.UpdatedSuccessMessage);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccesResult(Messages.DeletedSuccessMessage);
        }

        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();

            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.SuccessGetAllMessage);
        }
        public IDataResult<Color> GetById(int id)
        {
            var result = _colorDal.Get(p => p.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<Color>(Messages.ErrorGetByIdMessage);
            }
            return new SuccessDataResult<Color>(result,Messages.SuccessGetByIdMessage);
        }
    }
}
