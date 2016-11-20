using Ordero.Core;
using Ordero.Core.Domain;
using Ordero.Service;
using Ordero.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ordero.Web.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantService _restaurantService;
        private IWorkContext _workContext;

        public RestaurantController(IRestaurantService restaurantService,
            IWorkContext workContext)
        {
            _restaurantService = restaurantService;
            _workContext = workContext;
        }

        // GET: Restaurant
        public ActionResult Index()
        {
            List<Restaurant> model = _restaurantService.GetAllRestaurants().ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Save(int? id)
        {
            RestaurantModel model = new RestaurantModel();

            if (id.HasValue)
            {
                Restaurant entity = _restaurantService.GetRestaurantById(id);

                model.Id = entity.Id;
                model.Name = entity.Name;
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(RestaurantModel model)
        {
            if (ModelState.IsValid)
            {
                Restaurant entity = _restaurantService.GetRestaurantById(model.Id);

                if (entity == null)
                {
                    entity = new Restaurant()
                    {
                        Name = model.Name,
                        Description = null,
                        InsertedBy = _workContext.CurrentUser.Id,
                        InsertedOn = DateTime.Now
                    };

                    entity.Menus.Add(new Menu()
                    {
                        Name = "قائمة الطعام",
                        IsCurrent = true,
                        InsertedBy = _workContext.CurrentUser.Id,
                        InsertedOn = DateTime.Now
                    });

                    _restaurantService.InsertRestaurant(entity);
                }
                else
                {
                    entity.Name = model.Name;
                    entity.UpdatedBy = _workContext.CurrentUser.Id;
                    entity.UpdatedOn = DateTime.Now;

                    _restaurantService.UpdateRestaurant(entity);
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}