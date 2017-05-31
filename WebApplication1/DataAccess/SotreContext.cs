using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DataAccess
{
    public class SotreContext : DbContext
    {
        public DbSet<Models.StockItem> Items { get; set; }
        public SotreContext() : base("DefaultConnection") { } //Constructor
    }
}