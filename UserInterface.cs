using CoffeeShop.PointOfSale.EntityFramework.Models;
using CoffeeShop.PointOfSale.EntityFramework.Models.DTOs;
using CoffeeShop.PointOfSale.EntityFramework.Services;
using Spectre.Console;
using static CoffeeShop.PointOfSale.EntityFramework.Enums;

namespace CoffeeShop.PointOfSale.EntityFramework;

internal class UserInterface
{
  

    internal static void MainMenu()
    {
        var isAppRunning = true;

        while (isAppRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<MainMenuOptions>().Title("What would you like to do?")
                .AddChoices(
                MainMenuOptions.ManageCategories,
                MainMenuOptions.ManageProducts,
                MainMenuOptions.ManageOrders,
                MainMenuOptions.GenerateReport,
                MainMenuOptions.Quit
                )
                );

            switch (option)
            {
                case MainMenuOptions.ManageCategories:
                    CategoriesMenu();
                    break;
                case MainMenuOptions.ManageProducts:
                    ProductsMenu();
                    break;
                case MainMenuOptions.ManageOrders:
                    OrdersMenu();
                    break;
                case MainMenuOptions.GenerateReport:
                    ReportService.CreateMonthlyReport();
                    break;
                case MainMenuOptions.Quit:
                    Console.WriteLine("Goodbye");
                    isAppRunning = false;
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    break;
            }
        }
    }

    private static void OrdersMenu()
    {
        var isAppRunning = true;

        while (isAppRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<OrderMenu>().Title("Orders Menu")
                .AddChoices(
                OrderMenu.AddOrder,
                OrderMenu.GetOrders,
                OrderMenu.GetOrder,
                OrderMenu.GoBack
                )
                );

            switch (option)
            {
                case OrderMenu.AddOrder:
                    OrderService.InsertOrder();
                    break;
                case OrderMenu.GetOrders:
                    OrderService.GetOrders();
                    break;
                case OrderMenu.GetOrder:
                    OrderService.GetOrder();
                    break;
                case OrderMenu.GoBack:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    break;
            }
        }
    }

    private static void ProductsMenu()
    {
        var isAppRunning = true;

        while (isAppRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<ProductMenu>().Title("Product Menu")
                .AddChoices(
                ProductMenu.AddProduct,
                ProductMenu.DeleteProduct,
                ProductMenu.UpdateProduct,
                ProductMenu.ViewProduct,
                ProductMenu.ViewAllProducts,
                ProductMenu.GoBack
                )
                );

            switch (option)
            {
                case ProductMenu.AddProduct:
                    ProductService.InsertProduct();
                    break;
                case ProductMenu.DeleteProduct:
                    ProductService.DeleteProduct();
                    break;
                case ProductMenu.UpdateProduct:
                    ProductService.UpdateProduct();
                    break;
                case ProductMenu.ViewProduct:
                    ProductService.GetProduct();
                    break;
                case ProductMenu.ViewAllProducts:
                    ProductService.GetAllProducts();
                    break;
                case ProductMenu.GoBack:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    break;
            }
        }
    }

    private static void CategoriesMenu()
    {
        var isAppRunning = true;

        while (isAppRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<CategoryMenu>().Title("Categories Menu")
                .AddChoices(
                CategoryMenu.AddCategory,
                CategoryMenu.DeleteCategory,
                CategoryMenu.UpdateCategory,
                CategoryMenu.ViewAllCategories,
                CategoryMenu.ViewCategory,
                CategoryMenu.GoBack
                )
                );

            switch (option)
            {
                case CategoryMenu.AddCategory:
                    CategoryService.InsertCategory();
                    break;
                case CategoryMenu.DeleteCategory:
                    CategoryService.DeleteCategory();
                    break;
                case CategoryMenu.UpdateCategory:
                    CategoryService.UpdateCategory();
                    break;
                case CategoryMenu.ViewAllCategories:
                    CategoryService.GetCategories();
                    break;
                case CategoryMenu.ViewCategory:
                    CategoryService.GetCategory();
                    break;
                case CategoryMenu.GoBack:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    break;
            }
        }
    }

    internal static void ShowCategory(Category category)
    {
        //panel comes from spectre console
        var panel = new Panel($@"Id: {category.Id}
Name: {category.Name}
Product Count: {category.Products.Count}");

        panel.Header = new PanelHeader($"{category.Name}");
        panel.Padding = new Padding(2, 2, 2, 2); ;

        AnsiConsole.Write(panel);

        ShowProductsTable(category.Products);

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
        Console.Clear();
    }

    internal static void ShowCategoryTable(List<Category> categories)
    {
        //table class belongs to spectre.console
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");

        foreach (var category in categories)
        {
            table.AddRow(category.Id.ToString(), category.Name);
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
        Console.Clear();
    }

    internal static void ShowProducts(Product product)
    {
        //panel comes from spectre console
        var panel = new Panel($@"Id: {product.ProductId}
Name: {product.Name}
Category: {product.Category.Name}");

        panel.Header = new PanelHeader("Product Info");
        panel.Padding = new Padding(2, 2, 2, 2); ;

        AnsiConsole.Write(panel);
        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
        Console.Clear();
    }

    static internal void ShowProductsTable(List<Product> products)
    {
        //table class belongs to spectre.console
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Price");
        table.AddColumn("Category");

        foreach (var product in products)
        {
            table.AddRow(product.ProductId.ToString(), product.Name,product.Price.ToString(), product.Category.Name);
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
        Console.Clear();
    }

    internal static void ShowOrderTable(List<Order> orders)
    {
        //table class belongs to spectre.console
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Date");
        table.AddColumn("Count");
        table.AddColumn("Total Price");

        foreach (Order order in orders)
        {
            table.AddRow(
                order.OrderId.ToString(), 
                order.CreatedDate.ToString(),
                order.OrderProducts.Sum(x => x.Quantity).ToString(),
                order.TotalPrice.ToString()
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
        Console.Clear();
    }

    internal static void ShowOrder(Order order)
    {
        //panel comes from spectre console
        var panel = new Panel($@"Id: {order.OrderId}
Date: {order.CreatedDate}
Product Count: {order.OrderProducts.Sum(x => x.Quantity)}");

        panel.Header = new PanelHeader($"Order #{order.OrderId}");
        panel.Padding = new Padding(2, 2, 2, 2); ;

        AnsiConsole.Write(panel);
    }

    internal static void ShowProductForOrderTable(List<ProductForOrderViewDTO> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Category");
        table.AddColumn("Price");
        table.AddColumn("Quantity");
        table.AddColumn("Total Price");

        foreach (var product in products)
        {
            table.AddRow(
                product.Id.ToString(),
                product.Name.ToString(),
                product.CategoryName,
                product.Price.ToString(),
                product.Quantity.ToString(),
                product.TotalPrice.ToString()
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press Any Key to Return to Menu");
        Console.ReadLine();
        Console.Clear();
    }

    internal static void ShowReportByMonth(List<MonthlyReportDTO> report)
    {
        var table = new Table();
        table.AddColumn("Month");
        table.AddColumn("Total Quantity");
        table.AddColumn("Total Sales");

        foreach(var item in report)
        {
            table.AddRow(
                item.Month,
                item.TotalQuantity.ToString(),
                item.TotalPrice.ToString()
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press Any Key to Return to Menu");
        Console.ReadLine();
        Console.Clear();
    }
}
