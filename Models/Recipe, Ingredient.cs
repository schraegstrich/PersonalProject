namespace Models
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CookingTimeInMinutes { get; set; }
        public DateTime DateAdded { get; set; }
        public List<Ingredient>? Ingredients { get; set; }

    }

    public class Ingredient
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public Guid FoodItemId { get; set; }
        public string Name { get; set; }
        public int? QuantityInGramsOrMl { get; set; }
        public int? QuantityInPc { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
