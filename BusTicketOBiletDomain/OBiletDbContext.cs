using BusTicketOBiletDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusTicketOBiletDomain
{
    public class OBiletDbContext:DbContext,IOBiletDbContext
    {
        public OBiletDbContext(DbContextOptions<OBiletDbContext> options):base(options)
        {

        }
        public DbSet<Location> Locations { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            return await base.SaveChangesAsync(token);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
