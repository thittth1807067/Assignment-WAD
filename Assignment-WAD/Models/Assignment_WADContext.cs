using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment_WAD.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class Assignment_WADContext : DbContext
    {
      
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public Assignment_WADContext() : base("name=MyContext")
        {
        }

        public System.Data.Entity.DbSet<Assignment_WAD.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Assignment_WAD.Models.ProductCategory> ProductCategories { get; set; }
        public System.Data.Entity.DbSet<Assignment_WAD.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<Assignment_WAD.Models.OrderDetail> OrderDetails { get; set; }
    }
}
