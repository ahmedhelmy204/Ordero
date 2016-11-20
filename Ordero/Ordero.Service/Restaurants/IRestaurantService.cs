using Ordero.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Service
{
    public interface IRestaurantService
    {
        Restaurant GetRestaurantById(object id);

        IQueryable<Restaurant> GetAllRestaurants();

        void InsertRestaurant(Restaurant restaurant);

        void UpdateRestaurant(Restaurant restaurant);
    }
}
