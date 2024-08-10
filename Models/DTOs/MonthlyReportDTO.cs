﻿namespace CoffeeShop.PointOfSale.EntityFramework.Models.DTOs;

internal class MonthlyReportDTO
{
    public string Month { get; set; }
    public decimal TotalPrice { get; set; }
    public int TotalQuantity { get; set; }
}
