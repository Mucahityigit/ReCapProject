using Business.Abstract;
using Business.Constants;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccesResult(Messages.AddedSuccessMessage);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccesResult(Messages.DeletedSuccessMessage);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.SuccessGetAllMessage);
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(p => p.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<User>(Messages.ErrorGetByIdMessage);
            }
            return new SuccessDataResult<User>(result, Messages.SuccessGetByIdMessage);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccesResult(Messages.UpdatedSuccessMessage);
        }
    }
}
