using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Akijfood.Model
{
    public class tblColdDrinks
    {
        [Key]
        public int intColdDrinksId { get; set; }
        public string strColdDrinksName { get; set; }
        public decimal numQuantity { get; set; }
        public decimal numUnitPrice { get; set; }
    }
}
