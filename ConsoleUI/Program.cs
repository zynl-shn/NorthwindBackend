﻿// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using Core.Extensions;
using DataAccess.Concrete.EntityFramework;

//GetProductList();

//CategoryTest();
//ProductTest1(int.MaxValue, string.Empty);


// var productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
var details = new ErrorDetails();
details.Message = "asdas";
details.StatusCode = 600;

Console.WriteLine(details.ToString());

// var product = new Product { ProductId = 88, UnitPrice = 25, CategoryId = 2, ProductName = "Su Bardagı", UnitsInStock = 25 };

// productManager.Update(product);
// var productGet = productManager.GetById(88);
// Console.WriteLine(productGet.Data.UnitPrice);
// var result = productManager.GetProductCategory();
// if (result.Success)
// {
//     Console.WriteLine($"Message: {result.Message}");
//     foreach (var product in result.Data)
//         Console.WriteLine($"Product Name : {product.ProductName} Category Name: {product.CategoryName}");
// }
// else
// {
//     foreach (var product in result.Data)
//         Console.WriteLine($"Product Name : {product.ProductName} Category Name: {product.CategoryName}");
//     Console.WriteLine($"Message: {result.Message}");
// }


void CategoryTest()
{
    var categoryManager = new CategoryManager(new EfCategoryDal());
    categoryManager.GetAll().Data.ForEach(c => Console.WriteLine(c.CategoryName));
}

void ProductTest()
{
    var productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
    foreach (var product in productManager.GetAllByCategory(2).Data) Console.WriteLine(product.ProductName);
}

void ProductTest1(int deneme, string dasd)
{
    var productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
    foreach (var product in productManager.GetProductCategory().Data) Console.WriteLine($"Product Name : {product.ProductName} Category Name: {product.CategoryName}");
}