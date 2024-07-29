using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FoodItem
    {
        public enum Position
        {
            Right,
            Middle,
            Left
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Link { get; set; }
        public int? QuantityInPackInGramsOrMl { get; set; }
        public int? QuantityInPcs { get; set; }
        public int Shelf {get; set; }
        public Position PositionOnShelf { get; set; }
        public string SensorId { get; set; }

        public DateTime DateAdded { get; set; }
        public List<Ingredient>? UsedAsIngredient { get; set; }

        public string SetSensorId()
        {
            return $"{Shelf}-{(int)PositionOnShelf}";
        }

    }
}
