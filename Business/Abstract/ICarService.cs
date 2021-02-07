using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<CarDetailDto> GetCarDetails();
        List<Car> GetAll();

        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);

        void Add(Brand brand, Car car);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}