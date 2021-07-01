using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concretee;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _rentalDal;

        public RentalsManager(IRentalsDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        //[ValidationAspect(typeof(RentalsValidator))]
        public IResult Add(Rentals rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalsAdded);

        }
        public IResult Delete(Rentals rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalsDeleted);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Rentals>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Rentals>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IResult Update(Rentals rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalsUpdated);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
    }
}