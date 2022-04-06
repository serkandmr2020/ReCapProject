using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car() {Id=1,BrandId=1,ColorId=1, DailyPrice=1000, ModelYear="2016", Description="Volkswagen Passat"},
                new Car() {Id=2,BrandId=1,ColorId=2, DailyPrice=800, ModelYear="2017", Description="Volkswagen Golf"},
                new Car() {Id=3,BrandId=2,ColorId=1, DailyPrice=600, ModelYear="2020", Description="Renault Passat"},
                new Car() {Id=4,BrandId=3,ColorId=1, DailyPrice=900, ModelYear="2017", Description="Scoda Octavia"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(f => f.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }


        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(f => f.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
