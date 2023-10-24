using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesBasketballStats.Models;

namespace RazorPagesBasketballStats.Data
{
    public class RazorPagesBasketballStatsContext : DbContext
    {
        public RazorPagesBasketballStatsContext (DbContextOptions<RazorPagesBasketballStatsContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesBasketballStats.Models.Player> Player { get; set; } = default!;
    }
}
