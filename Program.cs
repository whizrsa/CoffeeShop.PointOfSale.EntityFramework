using Spectre.Console;
namespace CoffeeShop.PointOfSale.EntityFramework;

internal class Program
{
    static void Main(string[] args)
    {
        var context = new ProductContext();
        //everytime app is run database is deleted and created again
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        UserInterface.MainMenu();
    }
 
}
