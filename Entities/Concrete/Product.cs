﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        // Internal ConsoleUI ın içindekiler erişebilir demek default olarak da o gelir.
        //ama biz public uygulamalıyız çünkü diğer katmanlar buraya erişmesi gerek.
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }


    }
}