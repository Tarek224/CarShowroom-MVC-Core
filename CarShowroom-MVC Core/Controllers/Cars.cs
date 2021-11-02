using CarShowroom.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarShowroom.Models;
using CarShowroom.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace CarShowroom.Controllers
{
    public class Cars : Controller
    {
        private readonly IService<Car> carService;
        private readonly IService<Category> catService;
        private readonly IFilterService<Car> filterService;
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IService<WishList> wishList;
        private readonly IService<Comment> comService;

        public Cars(IService<Car> CarService,
                    IService<Category> CatService,
                    IFilterService<Car> filterService,
                    ApplicationDbContext context,
                    UserManager<IdentityUser> userManager,
                    IService<WishList> wishList,
                    IService<Comment> comService)
        {
            carService = CarService;
            catService = CatService;
            this.filterService = filterService;
            this.context = context;
            this.userManager = userManager;
            this.wishList = wishList;
            this.comService = comService;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = catService.GetAll();
            return View(carService.GetAll());
        }

        public IActionResult InCategory(int Id)
        {
            List<Car> cars = carService.GetAll().Where(c => c.Category_ID == Id).ToList();
            ViewBag.Categories = catService.GetAll();
            return View("Index" , cars);
        }
        
        public IActionResult SortCars(int Id)
        {
            ViewBag.Categories = catService.GetAll();
            return View("Index", filterService.Sort(Id));
        }

        public IActionResult CarsWithPrice(int Id)
        {
            ViewBag.Categories = catService.GetAll();
            return View("Index", filterService.FilterByPrice(Id));
        }

        public IActionResult CarsWithColor(Color color)
        {
            ViewBag.Categories = catService.GetAll();
            return View("Index", filterService.FilterByColor(color));
        }

        public IActionResult CarSearch(string name)
        {
            ViewBag.Categories = catService.GetAll();
            return View("Index", filterService.FilterByName(name));
        }

        public IActionResult Details(int Id)
        {
            ViewBag.RelatedCars = carService.GetAll().Where(c => c.Category_ID == Id).ToList();
            ViewBag.Reviews = comService.GetAll().Where(c => c.Car_ID == Id).ToList();
            return View(carService.GetById(Id));
        }

        [Authorize]
        public async Task<IActionResult> AddToFav(int Id)
        {
            foreach (var item in wishList.GetAll())
            {
                if(item.Car_ID == Id)
                {
                    return RedirectToAction("Index", "Cars");
                }
            }
            Car car = carService.GetById(Id);
            IdentityUser user = await userManager.FindByEmailAsync(User.Identity.Name);
            WishList wish = new WishList { Car_ID = car.Car_ID, Customer_ID = user.Id };
            wishList.Add(wish);
            return RedirectToAction("Index", "Cars");
        }

        [Authorize]
        public async Task<IActionResult> ShowFav()
        {
            IdentityUser user = await userManager.FindByEmailAsync(User.Identity.Name);
            List<WishList> wishLists = wishList.GetAll().Where(c => c.Customer_ID == user.Id).ToList();
            return View(wishLists);
        }

        [Authorize]
        public IActionResult RemoveFav(int Id)
        {
            wishList.Delete(Id);
            return RedirectToAction("ShowFav", "Cars");
        }

        [Authorize]
        public async Task<IActionResult> AddReview(Comment com, int Id)
        {
            IdentityUser user = await userManager.FindByEmailAsync(User.Identity.Name);
            Car car = carService.GetById(Id);
            Comment comment = new Comment { Car_ID = car.Car_ID, Customer_ID = user.Id , Text = com.Text , Comment_Date = DateTime.Now};
            comService.Add(comment);
            return RedirectToAction("Details", new { Id = Id});
        }

    }
}
