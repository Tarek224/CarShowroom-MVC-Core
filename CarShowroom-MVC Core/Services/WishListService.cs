using CarShowroom.Data;
using CarShowroom.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShowroom.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShowroom.Services
{
    public class WishListService : IService<WishList>
    {
        private readonly ApplicationDbContext context;

        public WishListService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(WishList w)
        {
            context.WishLists.Add(w);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            WishList wishList = context.WishLists.FirstOrDefault(w => w.ID == Id);
            context.WishLists.Remove(wishList);
            context.SaveChanges();
        }

        public List<WishList> GetAll()
        {
           return context.WishLists.Include(c => c.Car).ThenInclude(c => c.CarImages).ToList();
        }

        public WishList GetById(int Id)
        {
            return context.WishLists.Include(c => c.Car).ThenInclude(c => c.CarImages).FirstOrDefault(c => c.ID == Id);
        }

        public void Update(WishList w, int Id)
        {
            WishList wishList = context.WishLists.FirstOrDefault(w => w.ID == Id);
            wishList.Car_ID = w.Car_ID;
            wishList.Customer_ID = w.Customer_ID;
            context.SaveChanges();
        }
    }
}
