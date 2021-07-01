using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.cs;
using Microsoft.AspNetCore.Http;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            
            builder.RegisterType<ColorsManager>().As<IColorsService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            
            builder.RegisterType<RentalsManager>().As<IRentalsService>().SingleInstance();
            builder.RegisterType<EfRentalsDal>().As<IRentalsDal>().SingleInstance();

            builder.RegisterType<UsersManager>().As<IUsersService>().SingleInstance();
            builder.RegisterType<EfUsersDal>().As<IUsersDal>().SingleInstance();

            builder.RegisterType<CustomersManager>().As<ICustomersService>().SingleInstance();
            builder.RegisterType<EfCustomersDal>().As<ICustomersDal>().SingleInstance();

            builder.RegisterType<CarsImageManager>().As<ICarsImageService>().SingleInstance();
            builder.RegisterType<EfCarsImageDal>().As<ICarsImageDal>().SingleInstance();

            builder.RegisterType<UsersManager>().As<IUsersService>();
            builder.RegisterType<EfUsersDal>().As<IUsersDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
