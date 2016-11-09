using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspnetWebApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(): base("ConnectionString")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public DbSet<Employee> Employee { get; set; }
    }
}