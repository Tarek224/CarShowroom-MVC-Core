using CarShowroom.Data;
using CarShowroom.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShowroom.Models;

namespace CarShowroom.Services
{
    public class CategoryService : IService<Category>
    {
        private readonly ApplicationDbContext context;

        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Category c)
        {
            context.Categories.Add(c);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Category category = context.Categories.FirstOrDefault(c => c.Category_ID == Id);
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            List<Category> categories = context.Categories.ToList();
            return categories;
        }

        public Category GetById(int Id)
        {
            Category category = context.Categories.FirstOrDefault(c => c.Category_ID == Id);
            return category;
        }

        public List<Category> Search(string name)
        {
            List<Category> categories = context.Categories.Where(c => c.Category_Name.Contains(name)).ToList();
            return categories;
        }

        public void Update(Category c, int Id)
        {
            Category category = context.Categories.FirstOrDefault(c => c.Category_ID == Id);
            category.Category_Name = c.Category_Name;
            category.Category_Describtion = c.Category_Describtion;
            context.SaveChanges();
        }
    }
}
