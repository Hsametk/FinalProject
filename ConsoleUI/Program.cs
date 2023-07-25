// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//IoC



void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

    foreach (var category in categoryManager.GetAll())
    {
        Console.WriteLine(category.CategoryName);
    }
}

//CategoryTest();


void ProductTest()
{
    ProductManager productManager = new ProductManager(new EfProductDal());
    var result = productManager.GetProductDetails();
    if (result.Success == true)
    {
        foreach (var product in result.Data )
        {
            Console.WriteLine(product.ProductName + "/" + product.CategoryName);
        }
    }
    else
    {
        Console.WriteLine(result.Message );
    }
  

    Console.WriteLine("-----------------");

    //foreach (var product in productManager.GetByUnitPrice(50, 200))
    //{
    //    Console.WriteLine(product.ProductName);
    //}
}

ProductTest();
