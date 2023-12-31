﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Core.Entities;
using Entities.Concrete;
using Entities.DTOs;

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
                new Product{ProductId = 1,CategoryId = 1,ProductName = "Bardak",UnitPrice = 15,UnitsInStock = 15},
                new Product{ProductId = 2,CategoryId = 1,ProductName = "Kamera",UnitPrice = 500,UnitsInStock = 3},
                new Product{ProductId = 3,CategoryId = 2,ProductName = "Telefon",UnitPrice = 1500,UnitsInStock = 2},
                new Product{ProductId = 4,CategoryId = 2,ProductName = "Klavye",UnitPrice = 150,UnitsInStock = 65},
                new Product{ProductId = 5,CategoryId = 2,ProductName = "Fare",UnitPrice = 150,UnitsInStock = 1},
            };
        }
        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
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
            productToUpdate.UnitsInStock = product.UnitsInStock;
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


        //Linq ödev gelişmiş
        public void Any()
        {
            var result = _products.Any(p => p.ProductName == "K");
        }

        public void Find()
        {
            var result = _products.Find(p => p.ProductId == 3);
        }

        public void FindAll()
        {
            var result = _products.FindAll(p => p.ProductName.Contains("top"));
        }

        public void OrderBy()
        {
            var result = _products.Where(p => p.ProductName.Contains("top")).OrderByDescending(p=> p.UnitPrice).ThenBy(p=> p.ProductName);
        }

        public void Query()
        {
            var result = from p in _products
                    where p.UnitPrice>= 150 
                    orderby p.UnitPrice descending , p.ProductName ascending 
                        select new ProductDto{ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice};
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        class ProductDto
        {
            public int ProductId { get; set; }
            public string  ProductName { get; set; }
            public decimal UnitPrice { get; set; }
        }
    }

}
