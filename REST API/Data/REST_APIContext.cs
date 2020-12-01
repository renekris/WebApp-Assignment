using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using REST_API.Models;

namespace REST_API.Data
{
    public class REST_APIContext : DbContext
    {
        public REST_APIContext (DbContextOptions<REST_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Parcel> Shipments { get; set; }

        public DbSet<REST_API.Models.BagWithLetters> BagWithLetters { get; set; }

        public DbSet<REST_API.Models.BagWithParcels> BagWithParcels { get; set; }

        public DbSet<REST_API.Models.Shipment> Shipment { get; set; }
    }
}
