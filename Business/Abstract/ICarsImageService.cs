using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarsImageService
    {
        IDataResult<List<CarImageDto>> GetImagesByCarId(int carId);
        IResult Add(IFormFile file, CarsImage carImage, int id);
        IResult Delete(CarsImage carImage);
        IResult Update(IFormFile file, CarsImage carImage);
        IDataResult<CarsImage> Get(int id);
        IDataResult<List<CarsImage>> GetAll();
        IDataResult<List<CarsImage>> GetAllByCarId(int carId);
    }
}
