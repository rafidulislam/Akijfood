using Akijfood.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akijfood.Repository
{
    public class ColdDrinksRepository:IColdDrinksRepository
    {

        private readonly DataContext _dataContext;

        public ColdDrinksRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<tblColdDrinks> AddDrinks()
        {
            var result = new tblColdDrinks();
            result.strColdDrinksName = "Mojo";
            result.numUnitPrice = 35;
            result.numQuantity = 575;

            await _dataContext.tblColdDrinks.AddAsync(result);

            await _dataContext.SaveChangesAsync();
            return result;

            //return
        }

        public async Task<tblColdDrinks> UpdateDrink(tblColdDrinks tblColdDrinks)
        {
            var result = await _dataContext.tblColdDrinks.FirstOrDefaultAsync(e => e.strColdDrinksName == "Frutika");
            if (result != null)
            {
                result.numUnitPrice = 35;

                _dataContext.tblColdDrinks.Update(result);
                await _dataContext.SaveChangesAsync();
                return result;
            }
            return null;
        }


        public async Task DeleteDrink()
        {
            var result = await _dataContext.tblColdDrinks.FirstOrDefaultAsync(e => e.strColdDrinksName == "Speed");
            if (result != null)
            {
                _dataContext.tblColdDrinks.Remove(result);
                await _dataContext.SaveChangesAsync();

            }
        }

        public async Task<IEnumerable<tblColdDrinks>> Products()
        {
            return await _dataContext.tblColdDrinks.ToListAsync();
        }

        public async Task DeleteDrinkUnder500()
        {

            var result = await _dataContext.tblColdDrinks.Where(e => e.numQuantity <= 500).ToListAsync();
            if (result != null)
            {
                _dataContext.tblColdDrinks.RemoveRange(result);

                await _dataContext.SaveChangesAsync();

            }
        }

        public async Task<decimal> totalPrice()
        {
            var total = await _dataContext.tblColdDrinks.SumAsync(e => e.numUnitPrice * e.numQuantity);
            return total;
        }
    }
}
