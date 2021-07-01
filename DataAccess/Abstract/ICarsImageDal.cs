using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarsImageDal : IEntityRepository<CarsImage>
    {
        List<CarImageDto> GetCarImageDetails(Expression<Func<CarsImage, bool>> filter = null);
    }
}
