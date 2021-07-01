using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalsService
    {
        IDataResult<List<Rentals>> GetAll();
        IResult Add(Rentals rental);
        IResult Delete(Rentals rental);
        IResult Update(Rentals rental);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
