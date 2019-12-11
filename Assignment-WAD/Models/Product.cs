using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Assignment_WAD.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        [DisplayName("Category")]
        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}