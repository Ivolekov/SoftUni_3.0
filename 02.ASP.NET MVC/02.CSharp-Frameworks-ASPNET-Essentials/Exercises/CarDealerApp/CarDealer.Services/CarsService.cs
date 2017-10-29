namespace CarDealer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Models;
    using Data;
    using Models.BindingModels;
    using AutoMapper;

    public class CarsService : Service
    {
       // private CarDealerContext db = new CarDealerContext();
        public CarsService(CarDealerContext context):base(context)
        {

        }
        public List<Car> FindCarByMakeAndOrderDescByTravelDist(string make)
        {
            List<Car> cars = new List<Car>();

            if (make == "" || string.IsNullOrEmpty(make))
            {
                cars = this.Context.Cars.ToList();
                return cars;
            }

            cars = this.Context.Cars.Where(c => c.Make == make).OrderBy(c => c.Make).OrderByDescending(c => c.TravelledDistance).ToList();
            return cars;
        }

        public Car FindCarById(int? id)
        {
            Car car = this.Context.Cars.Find(id);
            return car;
        }

        public void AddCar(AddCarBindingModel bind)
        {
            Car car = Mapper.Map<AddCarBindingModel, Car>(bind);
            int[] partsIds = bind.Parts.Split(' ').Select(int.Parse).ToArray();
            foreach (var partId in partsIds)
            {
                Part part = this.Context.Parts.Find(partId);
                if (part!=null)
                {
                    car.Parts.Add(part);
                }
                this.Context.Cars.Add(car);
                this.Context.SaveChanges();
            }
            //Car car = new Car
            //{
            //    Make = AddCarBindingModel.Make,
            //    Model = AddCarBindingModel.Model,
            //    TravelledDistance = AddCarBindingModel.TravelledDistance
            //};
            this.Context.Cars.Add(car);
            this.Context.SaveChanges();
        }
    }
}