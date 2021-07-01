using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework.cs
{
    public class EfRentalsDal : EfEntityRepositoryBase<Rentals, ProjectContext>, IRentalsDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ProjectContext context = new ProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.brandId
                             join ct in context.Customers
                              on r.CustomerId equals ct.CustomersId
                             join u in context.Users
                             on ct.UsersId equals u.Id
                             select new RentalDetailDto { BrandName = b.brandName, FirstName = u.FirstName, LastName = u.LastName, RentDate = r.RentDate, ReturnDate = r.ReturnDate };
                return result.ToList();
            };
        }
    }
}
