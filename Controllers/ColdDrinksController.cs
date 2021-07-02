using Akijfood.Model;
using Akijfood.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akijfood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColdDrinksController : ControllerBase
    {
        private readonly IColdDrinksRepository _coldDrinkRepository;

        public ColdDrinksController(IColdDrinksRepository coldDrinkRepository)
        {
            _coldDrinkRepository = coldDrinkRepository;
        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult> GetProducts()
        {
            return Ok(await _coldDrinkRepository.Products());
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct()
        {
            return Ok(await _coldDrinkRepository.AddDrinks());
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(tblColdDrinks tblColdDrinks)
        {
            return Ok(await _coldDrinkRepository.UpdateDrink(tblColdDrinks));
        }

        [HttpDelete("DeleteSpeed")]
        public async Task<ActionResult> DeleteProduct()
        {
            await _coldDrinkRepository.DeleteDrink();

            return null;
        }

        [HttpDelete("DeleteProductUnder500")]
        
        public async Task<ActionResult> DeleteProductUnder500()
        {
            await _coldDrinkRepository.DeleteDrinkUnder500();

            return null;
        }

        
        [HttpGet("totalPrice")]
        public async Task<ActionResult> totalPrice()
        {
            return Ok(await _coldDrinkRepository.totalPrice());
        }
    }
}
