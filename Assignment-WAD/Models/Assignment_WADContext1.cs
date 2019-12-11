﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment_WAD.Models
{
    public class Assignment_WADContext1 : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Assignment_WADContext1() : base("name=Assignment_WADContext1")
        {
        }

        public System.Data.Entity.DbSet<Assignment_WAD.Models.ProductCategory> ProductCategories { get; set; }
    }
}