﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamFactory.Model {
    public class Product {
        public string Variant { get; set; }
        public int Size { get; set; }
        public int FruitContent { get; set; }
        public double Price { get; set; }
        public int ID { get; set; }

        public Product(string Variant, int Size, int FruitContent, double Price) {
            this.Variant = Variant;
            this.Size = Size;
            this.FruitContent = FruitContent;
            this.Price = Price;
        }
    }
}
