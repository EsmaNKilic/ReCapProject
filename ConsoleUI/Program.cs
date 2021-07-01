using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.cs;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //ColorsTest();

            //BrandTest();

            CustomersManager customerManager = new CustomersManager(new EfCustomersDal());
            customerManager.Add(new Customers { CustomersId = 1, UsersId = 4, CompanyName = "Kılıç Yazılım" });

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { brandName = "Chevrolet" });
            brandManager.Update(new Brand { brandId = 2, brandName = "Maserati" });
            brandManager.Delete(new Brand { brandId = 3, brandName = "Mercedes" });

            Console.WriteLine("Marka Seçeneklerimiz:");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.brandName);
            }
        }


        private static void ColorsTest()
        {
            ColorsManager colorsManager = new ColorsManager(new EfColorDal());
            colorsManager.Add(new Colors { Name = "Red" });
            colorsManager.Update(new Colors {Id = 2, Name = "Black" });
            colorsManager.Delete(new Colors { Id = 3, Name = "Blue" });

            Console.WriteLine("Renk Seçeneklerimiz:");
            foreach (var color in colorsManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 2, ColorId = 2, DailyPrice = 465000, Description = "Audi A4", ModelYear = 2018 });
            carManager.Update(new Car { Id = 5, BrandId = 1, ColorId = 5, DailyPrice = 111500, Description = "Renault Clio", ModelYear = 2015 });
            carManager.Delete(new Car { Id = 5, BrandId = 4, ColorId = 5, DailyPrice = 65000, Description = "Ford T", ModelYear = 1990 });

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description + " = " + car.DailyPrice + "TL");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
            //carManager.Add(new Brand { Name = "Mercedes Benz CLS" }, new Car { DailyPrice = 840000 });
            //carManager.Add(new Brand { Name = "Audi A4" }, new Car { DailyPrice = 465000 });
        }
    }
}
