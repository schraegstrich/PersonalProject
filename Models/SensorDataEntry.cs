using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum Position
    {
        Right,
        Middle,
        Left
    }
    public class SensorDataEntry
    {
        public Guid DataEntryId { get; set; }
        public int SensorId { get; set; }
        public int Shelf {get; set; }
        public Position PositionOnShelf { get; set; }
        public Guid FoodItemId { get; set; }
        public int ProductPresent { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
