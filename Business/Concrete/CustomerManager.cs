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
    public class CustomerManager:ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccesResult(Messages.AddedSuccessMessage);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccesResult(Messages.DeletedSuccessMessage);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.SuccessGetAllMessage);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id), Messages.SuccessGetByIdMessage);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccesResult(Messages.UpdatedSuccessMessage);
        }
    }
}
