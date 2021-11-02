using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShowroom.Models;

namespace CarShowroom.Interfaces
{
    public interface IFilterService<T>
    {
        List<T> FilterByCategory(int Id);

        List<T> FilterByPrice(int price);

        List<T> FilterByColor(Color color);

        List<T> FilterByName(string name);

        List<T> Sort(int Id);
    }
}
