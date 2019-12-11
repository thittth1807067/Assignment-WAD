using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_WAD.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}