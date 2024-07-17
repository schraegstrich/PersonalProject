using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class FoodItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Link { get; set; }
        public int? QuantityInPackInGramsOrMl { get; set; }
        public int? QuantityInPcs { get; set; }
        public List<Ingredient>? UsedAsIngredient { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
