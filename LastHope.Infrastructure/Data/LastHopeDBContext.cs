using LastHope.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastHope.Infrastructure.Data
{
    public class LastHopeDBContext : DbContext
    {
        public LastHopeDBContext(DbContextOptions<LastHopeDBContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
