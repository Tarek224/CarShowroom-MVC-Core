using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShowroom.Interfaces
{
    public interface IService<T> where T : class
    {
        public List<T> GetAll();

        public T GetById(int Id);

        public void Add(T t);

        public void Update(T t, int Id);

        public void Delete(int Id);
    }
}
