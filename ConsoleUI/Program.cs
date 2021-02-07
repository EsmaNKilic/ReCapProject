using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 2, ColorId = 2, DailyPrice = 465000, Description = "Audi A4", ModelYear = 2018 });
            carManager.Update(new Car { Id = 5, BrandId = 1, ColorId = 5, DailyPrice = 111500, Description = "Renault Clio", ModelYear = 2015 });
            carManager.Delete(new Car { Id = 5, BrandId = 4, ColorId = 5, DailyPrice = 65000, Description = "Ford T", ModelYear = 1990 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description + " = " + car.DailyPrice + "TL");
            }
            carManager.Add(new Brand { Name = "Mercedes Benz CLS" }, new Car { DailyPrice = 840000 });
            carManager.Add(new Brand { Name = "Audi A4" }, new Car { DailyPrice = 465000 });

            ColorsManager colorsManager = new ColorsManager(new EfColorDal());
            colorsManager.Add(new Colors { Name = "Red" });
            colorsManager.Update(new Colors { Id = 2, Name = "Black" });
            colorsManager.Delete(new Colors { Id = 3, Name = "Blue" });

            foreach (var color in colorsManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Name = "Chevrolet" });
            brandManager.Update(new Brand { Id = 2, Name = "Maserati" });
            brandManager.Delete(new Brand { Id = 3, Name = "Mercedes" });



        }
    }
}
