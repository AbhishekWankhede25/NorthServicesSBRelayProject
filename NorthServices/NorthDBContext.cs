using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace NorthServices
{
    public class NorthDBContext: DbContext
    {
        public NorthDBContext() : base("NorthConnection") { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
