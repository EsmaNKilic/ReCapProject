using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework.cs
{
    public class EfCarsImageDal : EfEntityRepositoryBase<CarsImage, ProjectContext>, ICarsImageDal
    {
        public List<CarImageDto> GetCarImageDetails(Expression<Func<CarsImage, bool>> filter = null)
        {
           
                using (ProjectContext context = new ProjectContext())
                {
                    var result = from image in filter == null ? context.CarsImage : context.CarsImage.Where(filter)
                                 join car in context.Cars
                                 on image.CarId equals car.Id
                                 select new CarImageDto
                                 {
                                     CarId = car.Id,
                                     ImagePath = image.ImagePath,
                                     Id = image.Id
                                 };
                    return result.ToList();
                }
            }
        
    }
}
