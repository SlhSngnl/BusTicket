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
    public interface IOBiletDbContext
    {
        DbSet<Session> Sessions
        {
            get;
        }

        DbSet<Location> Locations
        {
            get;
        }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
