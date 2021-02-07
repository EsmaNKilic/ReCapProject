using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Brand brand, Car car)
        {
            if (brand.Name.Length > 2 && car.DailyPrice > 0)
            {
                Console.WriteLine(brand.Name + " adlı yeni araç eklendi.");
                Console.WriteLine("Günlük Fiyat: " + car.DailyPrice);

            }
            else
            {
                Console.WriteLine("DİKKAT! Araba ismi minimum 2 karakter olmalıdır. \n Araba günlük fiyatı 0'dan büyük olmalıdır.");
            }
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}