using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomersService
    {
        IDataResult<List<Customers>> GetAll();
        IResult Add(Customers customer);
        IResult Delete(Customers customer);
        IResult Update(Customers customer);
    }
}
