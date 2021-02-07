using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorsManager : IColorsService
    {
        IColorDal  _colorsDal;

        public ColorsManager(IColorDal colorsDal)
        {
            _colorsDal = colorsDal;
        }

        public void Add(Colors color)
        {
            _colorsDal.Add(color);
        }

        public void Delete(Colors color)
        {
            _colorsDal.Delete(color);
        }

        public List<Colors> GetAll()
        {
            return _colorsDal.GetAll();
        }

        public void Update(Colors color)
        {
            _colorsDal.Update(color);
        }
    }
}
