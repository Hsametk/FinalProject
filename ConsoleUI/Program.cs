// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

ProductManager productManager = new ProductManager(new EfProductDal ());

foreach (var product in productManager.GetAll())
{
    Console.WriteLine(product.ProductName);
}

Console.WriteLine("-----------------");

foreach (var product in productManager.GetByUnitPrice(50,200))
{
    Console.WriteLine(product.ProductName);
}
