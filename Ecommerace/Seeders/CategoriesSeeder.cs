using Bogus;
using Bogus.DataSets;
using Ecommerace.Models;
using NuGet.Packaging;

namespace Ecommerace.Seeders;

public class CategoriesSeeder
{
    public static async Task Run()
    {
        MVCECommeraceContext _context = new MVCECommeraceContext();

        var categories = new List<Category>();


        // Create parent categories
        var electronics = new Category
        {
            Name = "Electronics",
            Parent_Id = null,
            Image = "electronics.jpg"
        };

        var games = new Category
        {
            Name = "Games",
            Parent_Id = null,
            Image = "games.jpg"
        };

        var clothes = new Category
        {
            Name = "Clothes",
            Parent_Id = null,
            Image = "clothes.jpg"
        };

        var books = new Category
        {

            Name = "Books",
            Parent_Id = null,
            Image = "books.jpg"
        };

        var furniture = new Category
        {

            Name = "Furniture",
            Parent_Id = null,
            Image = "furniture.jpg"
        };

        // Add parent categories to the list
        categories.Add(electronics);
        categories.Add(games);
        categories.Add(clothes);
        categories.Add(books);
        categories.Add(furniture);

        // Create child categories
        electronics.SubCategories.AddRange(new List<Category>
    {
        new Category { Name = "Smartphones", Parent_Id = electronics.Id, Image = "smartphones.jpg" },
        new Category { Name = "Laptops", Parent_Id = electronics.Id, Image = "laptops.jpg" },
        new Category { Name = "Cameras", Parent_Id = electronics.Id, Image = "cameras.jpg" },
        new Category { Name = "Televisions", Parent_Id = electronics.Id, Image = "televisions.jpg" },
        new Category { Name = "Headphones", Parent_Id = electronics.Id, Image = "headphones.jpg" },
    });

        games.SubCategories.AddRange(new List<Category>
    {
        new Category { Name = "Action Games", Parent_Id = games.Id, Image = "action_games.jpg" },
        new Category { Name = "Adventure Games", Parent_Id = games.Id, Image = "adventure_games.jpg" },
        new Category { Name = "Puzzle Games", Parent_Id = games.Id, Image = "puzzle_games.jpg" },
        new Category { Name = "Sports Games", Parent_Id = games.Id, Image = "sports_games.jpg" },
        new Category { Name = "Simulation Games", Parent_Id = games.Id, Image = "simulation_games.jpg" },
    });

        clothes.SubCategories.AddRange(new List<Category>
    {
        new Category {  Name = "Men's Clothing", Parent_Id = clothes.Id, Image = "mens_clothing.jpg" },
        new Category {  Name = "Women's Clothing", Parent_Id = clothes.Id, Image = "womens_clothing.jpg" },
        new Category {  Name = "Kids' Clothing", Parent_Id = clothes.Id, Image = "kids_clothing.jpg" },
        new Category {  Name = "Accessories", Parent_Id = clothes.Id, Image = "accessories.jpg" },
        new Category {  Name = "Footwear", Parent_Id = clothes.Id, Image = "footwear.jpg" },
    });

        books.SubCategories.AddRange(new List<Category>
    {
        new Category { Name = "Fiction", Parent_Id = books.Id, Image = "fiction.jpg" },
        new Category { Name = "Non-Fiction", Parent_Id = books.Id, Image = "non_fiction.jpg" },
        new Category { Name = "Children's Books", Parent_Id = books.Id, Image = "childrens_books.jpg" },
        new Category { Name = "Educational Books", Parent_Id = books.Id, Image = "educational_books.jpg" },
        new Category { Name = "Comics & Graphic Novels", Parent_Id = books.Id, Image = "comics.jpg" },
    });

        furniture.SubCategories.AddRange(new List<Category>
    {
        new Category { Name = "Living Room Furniture", Parent_Id = furniture.Id, Image = "living_room_furniture.jpg" },
        new Category { Name = "Bedroom Furniture", Parent_Id = furniture.Id, Image = "bedroom_furniture.jpg" },
        new Category { Name = "Office Furniture", Parent_Id = furniture.Id, Image = "office_furniture.jpg" },
        new Category { Name = "Outdoor Furniture", Parent_Id = furniture.Id, Image = "outdoor_furniture.jpg" },
        new Category { Name = "Storage Furniture", Parent_Id = furniture.Id, Image = "storage_furniture.jpg" },
    });

          _context.Categories.AddRange(categories);
        _context.SaveChanges();
    }

    public static List<Category> GenerateCategories()
    {
        // Create a Faker instance for generating category names
        var faker = new Faker();

        // Generate 5 parent categories
        var parentCategories = new Faker<Category>()
            .RuleFor(c => c.Name, f => f.Commerce.Categories(1).First())
            .RuleFor(c => c.Parent_Id, f => (int?)null)
            .RuleFor(c => c.Image, f => f.Image.PicsumUrl())
            .RuleFor(c => c.Created_at, f => f.Date.Past())
            .RuleFor(c => c.Updated_at, f => f.Date.Recent())
            .Generate(5);

        // Generate subcategories for each parent category
        var categories = new List<Category>();
        foreach (var parent in parentCategories)
        {
            // Generate 5 subcategories for each parent category
            var subcategories = new Faker<Category>()
                .RuleFor(c => c.Name, f => f.Commerce.Categories(1).First())
                .RuleFor(c => c.Parent_Id, f => parent.Id)
                .RuleFor(c => c.Image, f => f.Image.PicsumUrl())
                .RuleFor(c => c.Created_at, f => f.Date.Past())
                .RuleFor(c => c.Updated_at, f => f.Date.Recent())
                .Generate(5);

            parent.SubCategories = subcategories;

            categories.Add(parent);
            categories.AddRange(subcategories);
        }

        return categories;
    }
}
