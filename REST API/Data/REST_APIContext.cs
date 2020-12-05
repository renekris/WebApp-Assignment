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

        public DbSet<REST_API.Models.Shipment> Shipment { get; set; } = null!;

        public DbSet<REST_API.Models.ShipmentBags> ShipmentBags { get; set; } = null!;

        public DbSet<REST_API.Models.BagParcels> BagParcels { get; set; } = null!;

        public DbSet<REST_API.Models.BagLetters> BagLetters { get; set; } = null!;

        public DbSet<REST_API.Models.Parcel> Parcel { get; set; } = null!;
    }
}
