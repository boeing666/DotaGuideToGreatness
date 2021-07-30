using DotaGuideToGreatness.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaGuideToGreatness.DAL
{
    public class DotaDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public DotaDbContext(DbContextOptions<DotaDbContext> options) : base(options) { }

    }
}
