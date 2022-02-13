﻿using Microsoft.AspNetCore.Identity;

namespace Store.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        public int Price { get; set; }
    }
}