using LoveApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LoveApi
{
    public class LoveContext : DbContext
    {
        public LoveContext(DbContextOptions<LoveContext> options) : base(options) { }

        public DbSet<Couple> Couples { get; set; }
    }
}
