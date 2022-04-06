using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (CheckValidityOfName(car))
            {
                if (CheckDailyPrice(car))
                {
                    _carDal.Add(car);
                }
            }

        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(f => f.Id == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        private bool CheckValidityOfName(Car car)
        {
            if (car.Description.Length >= 2)
            {
                return true;
            }

            return false;
        }

        private bool CheckDailyPrice(Car car)
        {
            if (car.DailyPrice > 0)
            {
                return true;
            }

            return false;
        }
    }
}
