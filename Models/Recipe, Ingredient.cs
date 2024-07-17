namespace Models
{
    internal class Recipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
        public int CookingTimeInMinutes { get; set; }
        public DateTime DateAdded { get; set; }
    }

    internal class Ingredient
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public Guid FoodItemId { get; set; }
        public string Name { get; set; }
        public int QuantityInGramsOrMl { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
