using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ordero.Core.Domain;
using Ordero.Data;
using Ordero.Core;

namespace Ordero.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IOrderoRepository<Restaurant> _restaurantRepository;
        private readonly IWorkContext _workContext;

        public RestaurantService(IOrderoRepository<Restaurant> restaurantRepository,
            IWorkContext workContext)
        {
            _restaurantRepository = restaurantRepository;
            _workContext = workContext;
        }

        public IQueryable<Restaurant> GetAllRestaurants()
        {
            return _restaurantRepository.Table;
        }

        public Restaurant GetRestaurantById(object id)
        {
            return _restaurantRepository.GetById(id);
        }

        public void InsertRestaurant(Restaurant restaurant)
        {
            if (restaurant == null)
                throw new ArgumentException("restaurant");

            _restaurantRepository.Insert(restaurant);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            if (restaurant == null)
                throw new ArgumentException("restaurant");

            _restaurantRepository.Update(restaurant);
        }
    }
}
