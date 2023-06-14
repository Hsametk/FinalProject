using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            //Oracle,Sql Server dan geliyomuş gibi düşün
            _products = new List<Product>
            {
                new Product{ProductId = 1,CategoryId = 1,ProductName = "Bardak",UnitPrice = 15,UnitInStock = 15},
                new Product{ProductId = 2,CategoryId = 1,ProductName = "Kamera",UnitPrice = 500,UnitInStock = 3},
                new Product{ProductId = 3,CategoryId = 2,ProductName = "Telefon",UnitPrice = 1500,UnitInStock = 2},
                new Product{ProductId = 4,CategoryId = 2,ProductName = "Klavye",UnitPrice = 150,UnitInStock = 65},
                new Product{ProductId = 5,CategoryId = 2,ProductName = "Fare",UnitPrice = 150,UnitInStock = 1},
            };
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün ID'sine sahip olan listedeki ürünü bul
            Product productToUpdate;
            productToUpdate =_products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitInStock = product.UnitInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
            
        }

        public void Delete(Product product)
        {
            // LİNQ olmasaydı bu sistemle update edebilirdik.
            Product productToDelete;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}


            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
