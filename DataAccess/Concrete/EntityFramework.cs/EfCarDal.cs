using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ProjectContext context = new ProjectContext())
            {
                var result = from c in filter == null?context.Cars:context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.brandId
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailDto()
                             {
                                 Id = c.Id,
                                 BrandName = b.brandName,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                                 
                             };
                return result.ToList();
            }
        }
    }
}