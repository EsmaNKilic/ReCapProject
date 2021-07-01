using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concretee;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarsImageManager : ICarsImageService
    {
        ICarsImageDal _carImageDal;
        public CarsImageManager(ICarsImageDal carImage)
        {
            _carImageDal = carImage;
        }
        //[SecuredOperation("carimage.add,admin")]
        //[PerformanceAspect(7)]
        [ValidationAspect(typeof(CarsImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(IFormFile file, CarsImage carImage, int carId)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carId));
            if (result != null)
            {
                return result;
            }
            var imageResult = FileHelper.Add(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.imageAdd);
        }
        //[CacheRemoveAspect("ICarImageService.GetCarImageDetails")]
        public IResult Delete(CarsImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }
        //[CacheAspect]
        //[PerformanceAspect(7)]
        public IDataResult<List<CarsImage>> GetAll()
        {
            return new SuccessDataResult<List<CarsImage>>(_carImageDal.GetAll(), Messages.listed);
        }

        //! Refactor Et
        //[CacheAspect]
        //[PerformanceAspect(7)]
        public IDataResult<List<CarImageDto>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetCarImageDetails(carImage => carImage.CarId == carId).Any();
            return new SuccessDataResult<List<CarImageDto>>(_carImageDal.GetCarImageDetails(p => p.CarId == carId), Messages.succeed);
        }



        public IResult Update(IFormFile image, CarsImage carImage)
        {
            var isImage = _carImageDal.Get(c => c.CarId == carImage.CarId);

            var updatedFile = FileHelper.Update(image, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult("Car image updated");

        }

        private IResult CheckImageLimitExceeded(int id)
        {
            if (_carImageDal.GetAll(image => image.CarId == id).Count >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();

        }
        //[CacheAspect]
        //[PerformanceAspect(7)]
        public IDataResult<CarsImage> Get(int id)
        {
            return new SuccessDataResult<CarsImage>(_carImageDal.Get(p => p.Id == id));
        }
        private IResult CarImageDelete(CarsImage carImage)
        {
            var newPath = carImage.ImagePath.Replace('/', '\\');
            var secondPath = "C:" + newPath + ".";
            try
            {
                File.Delete(secondPath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public IDataResult<List<CarsImage>> GetAllByCarId(int carId)
        {
            var getAllbyCarIdResult = _carImageDal.GetAll(p => p.CarId == carId);
            if (getAllbyCarIdResult.Count == 0)
            {
                return new SuccessDataResult<List<CarsImage>>(new List<CarsImage>
                {
                    new CarsImage
                    {
                        Id = -1,
                        CarId = carId,
                        Date = DateTime.MinValue,
                        ImagePath = "images/default.jpg"
                    }
                });
            }

            return new SuccessDataResult<List<CarsImage>>(getAllbyCarIdResult);
        }
    }
}

