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
    public class CommentService : IService<Comment>
    {
        private readonly ApplicationDbContext context;

        public CommentService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Comment c)
        {
            context.Comments.Add(c);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Comments.Remove(context.Comments.FirstOrDefault(c => c.ID == Id));
            context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return context.Comments.Include(c => c.User).Include(c => c.Car).ThenInclude(c => c.CarImages).ToList();
        }

        public Comment GetById(int Id)
        {
            return context.Comments.Include(c => c.User).Include(c => c.Car).ThenInclude(c => c.CarImages).FirstOrDefault(c => c.ID == Id);
        }

        public List<Comment> Search(string text)
        {
            return context.Comments.Where(c => c.Text.Contains(text)).ToList();
        }

        public void Update(Comment c, int Id)
        {
            Comment comment = this.GetById(Id);
            comment.Text = c.Text;
            context.SaveChanges();
        }
    }
}
