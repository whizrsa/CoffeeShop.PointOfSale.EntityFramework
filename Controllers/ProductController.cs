using CoffeeShop.PointOfSale.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace CoffeeShop.PointOfSale.EntityFramework.Controllers;

internal class ProductController
{
    internal static void AddProduct(Product product)
    {
        using var db = new ProductContext();
        db.Add(product);
        db.SaveChanges();
        Console.Clear();
    }

    internal static void DeleteProduct(Product product)
    {
        using var db = new ProductContext();
        db.Remove(product);
        db.SaveChanges();
    }

    internal static void UpdateProduct(Product product)
    {
        using var db = new ProductContext();
        db.Update(product);

        db.SaveChanges();
    }

    internal static List<Product> GetProducts()//returns a list of products
    {
        using var db = new ProductContext();
        var products = db.Products
            .Include(x => x.Category)
            .ToList();

        return products;
    }


    internal static Product GetProductById(int id)
    {
        using var db = new ProductContext();
        var product = db.Products
            .Include(x => x.Category)
            .SingleOrDefault(x => x.ProductId == id);

        return product;
    }
}
