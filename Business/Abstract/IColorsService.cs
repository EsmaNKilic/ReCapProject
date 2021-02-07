using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorsService
    {
        List<Colors> GetAll();

        void Add(Colors color);
        void Delete(Colors color);
        void Update(Colors color);
    }
}
