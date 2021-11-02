using CarShowroom.Data;
using CarShowroom.Interfaces;
using CarShowroom.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CarShowroom.Services
{
    public class CarService : IService<Car> , IFilterService<Car>
    {
        private readonly ApplicationDbContext context;

        public CarService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Car c)
        {
            context.Cars.Add(c);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Car car  = context.Cars.FirstOrDefault(c => c.Car_ID == Id);
            context.Cars.Remove(car);
            context.SaveChanges();
        }

        public List<Car> FilterByCategory(int Id)
        {
            List<Car> cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).Where(c => c.Category_ID == Id).ToList();
            return cars;
        }

        public List<Car> FilterByColor(Color color)
        {
            List<Car> cars;
            switch (color)
            {
                case (Color.Red):
                    cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).Where(c => c.color == Color.Red).ToList();
                    break;
                case (Color.Green):
                    cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).Where(c => c.color == Color.Green).ToList();
                    break;
                case (Color.Blue):
                    cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).Where(c => c.color == Color.Blue).ToList();
                    break;
                case (Color.Yellow):
                    cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).Where(c => c.color == Color.Yellow).ToList();
                    break;
                case (Color.Black):
                    cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).Where(c => c.color == Color.Black).ToList();
                    break;
                case (Color.White):
                    cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).Where(c => c.color == Color.White).ToList();
                    break;
                default:
                    cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).ToList();
                    break;
            }
            return cars;
        }

        public List<Car> FilterByName(string name)
        {
            List<Car> cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).Where(c => c.Name.Contains(name)).ToList();
            return cars;
        }

        public List<Car> FilterByPrice(int price)
        {
            List<Car> cars;
            switch (price)
            {
                case (1):
                    cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).Where(c => c.Price > 0 && c.Price <= 400000).ToList();
                    break;
                case (2):
                    cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).Where(c => c.Price > 400000 && c.Price <= 550000).ToList();
                    break;
                case (3):
                    cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).Where(c => c.Price > 550000 && c.Price <= 700000).ToList();
                    break;
                case (4):
                    cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).Where(c => c.Price > 700000).ToList();
                    break;
                default:
                    cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).ToList();
                    break;
            }
            return cars;
        }

        public List<Car> GetAll()
        {
            List<Car> cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).ToList();
            
            return cars;
        }

        public Car GetById(int Id)
        {
            Car car = context.Cars.Include(c => c.Category).Include(c => c.CarImages).FirstOrDefault(c => c.Car_ID == Id);
            return car;
        }

        public List<Car> Search(string name)
        {
            List<Car> cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).Where(c => c.Name.Contains(name)).ToList();
            return cars;
        }

        public List<Car> Sort(int Id)
        {
            List<Car> cars;
            switch (Id)
            {
                case (1):
                    cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).OrderBy(c => c.Acceleration).ToList();
                    break;
                case (2):
                    cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).OrderBy(c => c.Model).ToList();
                    break;
                case (3):
                    cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).OrderBy(c => c.Price).ToList();
                    break;
                case (4):
                    cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).OrderByDescending(c => c.Price).ToList();
                    break;
                default:
                    cars = context.Cars.Include(c => c.Category).Include(c => c.CarImages).ToList();
                    break;
            }
            return cars;
        }

        public void Update(Car c, int Id)
        {
            Car car = context.Cars.FirstOrDefault(c => c.Car_ID == Id);
            car.Acceleration = c.Acceleration;
            car.CarImages = c.CarImages;
            car.Category = c.Category;
            car.Category_ID = c.Category_ID;
            car.color = c.color;
            car.Comments = c.Comments;
            car.Description = c.Description;
            car.Model = c.Model;
            car.Name = c.Name;
            car.Price = c.Price;
            car.Stored_Quantity = c.Stored_Quantity;
            car.WishLists = c.WishLists;
            context.SaveChanges();
        }
    }
}
