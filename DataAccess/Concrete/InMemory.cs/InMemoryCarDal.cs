using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, BrandId =1 , ColorId = 1, ModelYear = 1974, DailyPrice =37500, Description ="Volkswagen 1303 VW Big"},
                new Car { Id = 2, BrandId =3 , ColorId = 2, ModelYear = 1967, DailyPrice =138000, Description ="Chevrolet Impala"},
                new Car { Id = 3, BrandId =4 , ColorId = 4, ModelYear = 1985, DailyPrice =160000, Description ="Jaguar XJ"},
                new Car { Id = 4, BrandId =2 , ColorId = 4, ModelYear = 1973, DailyPrice =2150000, Description ="Maserati Bora"},
                new Car { Id = 5, BrandId =4 , ColorId = 5, ModelYear = 1990, DailyPrice =65000, Description ="Ford T"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
    }
}