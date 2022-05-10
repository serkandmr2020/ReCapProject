using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);


            /*FluentValidation öncesi*/
            //if (CheckValidityOfName(car))
            //{
            //    if (CheckDailyPrice(car))
            //    {
            //        _carDal.Add(car);
            //        return new SuccessResult(Messages.CarAdded);
            //    }
            //    return new ErrorResult(Messages.CarPriceInvalid);
            //}

            //return new ErrorResult(Messages.CarNameInvalid);

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(result, Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(f => f.Id == id);
            return new SuccessDataResult<Car>(result, Messages.CarListedById);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            var result = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(result, Messages.CarsListedWithDetails);
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
