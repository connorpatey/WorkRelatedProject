using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WorkRelatedProject.Models
{
    public class PropertyDBContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
   
}