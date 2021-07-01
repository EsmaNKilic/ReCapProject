using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concretee;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomersManager : ICustomersService
    {
        ICustomersDal _customerDal;

        public CustomersManager(ICustomersDal customerDal)
        {
            _customerDal = customerDal;
        }
        //[ValidationAspect(typeof(CustomersValidator))]
        public IResult Add(Customers customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomersAdded);
        }

        public IResult Delete(Customers customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomersDeleted);
        }

        public IDataResult<List<Customers>> GetAll()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Customers>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Customers>>(_customerDal.GetAll(), Messages.CustomersListed);
        }

        public IResult Update(Customers customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomersUpdated);
        }
    }
}
