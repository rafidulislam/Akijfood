using Akijfood.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akijfood.Repository
{
     public interface IColdDrinksRepository
    {
        public Task<tblColdDrinks> AddDrinks();
        public Task<tblColdDrinks> UpdateDrink(tblColdDrinks tblColdDrinks);
        public Task DeleteDrink();
        public Task<IEnumerable<tblColdDrinks>> Products();
        public Task DeleteDrinkUnder500();
        public Task<decimal> totalPrice();

    }
}
