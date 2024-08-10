using CoffeeShop.PointOfSale.EntityFramework.Controllers;
using CoffeeShop.PointOfSale.EntityFramework.Models;
using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework.Services;

internal class ProductService
{
    internal static void InsertProduct()
    {
        var product = new Product();
        product.Name = AnsiConsole.Ask<string>("Product's name: ");
        product.Price = AnsiConsole.Ask<decimal>("Product price: ");
        product.CategoryId = CategoryService.GetCategoryOptionInput().Id;
        ProductController.AddProduct(product);
    }
    internal static void DeleteProduct()
    {
        var product = GetProductOptionInput();
        ProductController.DeleteProduct(product);
    }

    internal static void GetAllProducts()
    {
        var products = ProductController.GetProducts();
        UserInterface.ShowProductsTable(products);
    }

    internal static void UpdateProduct()
    {
        //ternary
        var product = GetProductOptionInput();
        product.Name = AnsiConsole.Confirm("Update name?")
            ? AnsiConsole.Ask<string>("Product's new name: ")
            : product.Name;

        product.Price = AnsiConsole.Confirm("Update price?")
            ? AnsiConsole.Ask<decimal>("Product's new price: ")
            : product.Price;
        product.Category = AnsiConsole.Confirm("Update Category?")
            ? CategoryService.GetCategoryOptionInput() : product.Category;
        ProductController.UpdateProduct(product);
    }

    internal static void GetProduct()
    {
        var product = GetProductOptionInput();
        UserInterface.ShowProducts(product);
    }
    static internal Product GetProductOptionInput()
    {
        var products = ProductController.GetProducts();
        var productsArray = products.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Product")
            .AddChoices(productsArray));
        var id = products.Single(x => x.Name == option).ProductId;
        var product = ProductController.GetProductById(id);

        return product;
    }
}
