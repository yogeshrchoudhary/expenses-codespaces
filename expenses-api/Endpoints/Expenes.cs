using System.Linq.Expressions;

namespace expenses_api.Endpoints;

public class ExpenesEndpoints
{
    public void Map(WebApplication app)
    {
        app.MapGet("/expenses", () =>
        {
            // return new[] { "Expense1", "Expense2", "Expense3" };
            return new[]
            {
                new Expense(1, "Groceries", 150.75m, DateTime.Now.AddDays(-2), "Food", "Bought groceries for the week"),
                new Expense(2, "Electricity Bill", 60.00m, DateTime.Now.AddDays(-10), "Utilities", "Monthly electricity bill"),
                new Expense(3, "Movie Tickets", 30.00m, DateTime.Now.AddDays(-5), "Entertainment", "Went to the movies with friends"),
                new Expense(4, "Gym Membership", 45.00m, DateTime.Now.AddDays(-15), "Health", "Monthly gym membership fee"),
                new Expense(5, "Dining Out", 80.00m, DateTime.Now.AddDays(-3), "Food", "Dinner at a restaurant with family"),
                new Expense(6, "Internet Bill", 55.00m, DateTime.Now.AddDays(-12), "Utilities", "Monthly internet bill"),
                new Expense(7, "Books", 120.00m, DateTime.Now.AddDays(-7), "Education", "Purchased textbooks for school"),
                new Expense(8, "Clothing", 200.00m, DateTime.Now.AddDays(-20), "Shopping", "Bought new clothes for the season"),
                new Expense(9, "Car Maintenance", 300.00m, DateTime.Now.AddDays(-30), "Transportation", "Oil change and tire rotation"),
                new Expense(10, "Coffee", 15.00m, DateTime.Now.AddDays(-1), "Food", "Daily coffee from the local cafe")
            };
        })
        .WithName("GetExpenses");
    }
}

public record Expense(int Id, string Title, decimal Amount, DateTime Date, string Category, string? Notes);