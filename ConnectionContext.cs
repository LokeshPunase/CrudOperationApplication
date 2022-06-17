using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrudOperationApplication.Models
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext() : base("DefaultConnection")
        {
        }
        public DbSet<Employee> Employee { get; set; }
    }
}