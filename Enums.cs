﻿namespace CoffeeShop.PointOfSale.EntityFramework;

internal class Enums
{
    internal enum MainMenuOptions
    {
        ManageCategories,
        ManageProducts,
        ManageOrders,
        GenerateReport,
        Quit
    }

    internal enum CategoryMenu
    {
        AddCategory,
        DeleteCategory,
        UpdateCategory,
        ViewAllCategories,
        ViewCategory,
        GoBack
    }

    internal enum ProductMenu
    {
        AddProduct,
        DeleteProduct,
        UpdateProduct,
        ViewProduct,
        ViewAllProducts,
        GoBack
    }

    internal enum OrderMenu
    {
        AddOrder,
        GetOrders,
        GetOrder,

        GoBack
    }
}
