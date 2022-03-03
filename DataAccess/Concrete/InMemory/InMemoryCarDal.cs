using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            //BrandId = 1 (Fiat), 2 (Peugeout), 3 (Audi), 4 (Renault)
            //ColorId = 1 (Beyaz),2 (Gri), 3 (Siyah)
            _cars = new List<Car> {
                new Car{Id=1, BrandId=1, ColorId=1, ModelYear="2010", DailyPrice=5250, Description="Fiat Fiorino" },
                new Car{Id=2, BrandId=2, ColorId=2, ModelYear="2010", DailyPrice=5750, Description="Peugeout 301" },
                new Car{Id=3, BrandId=2, ColorId=1, ModelYear="2011", DailyPrice=9500, Description="Peugeout Boxer" },
                new Car{Id=4, BrandId=3, ColorId=1, ModelYear="2018", DailyPrice=8250, Description="Audi A3" },
                new Car{Id=5, BrandId=4, ColorId=3, ModelYear="2019", DailyPrice=7500, Description="Renault Megane" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }



        public List<Car> GetById(int id)
        {
            return _cars.Find(c => c.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.ColorId = car.ColorId;

        }
    }
}