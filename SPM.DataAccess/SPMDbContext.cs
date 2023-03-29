using Microsoft.EntityFrameworkCore;
using SPM.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM.DataAccess
{
    public class SPMDbContext : DbContext
    {
        public SPMDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Park> Parks { get; set; }
        public DbSet<ParkingHistory> ParkingHistorys { get; set; }
        public DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<SpacePrice> SpacePrices { get; set; }
        public DbSet<SpaceType> SpaceTypes { get; set; }
        //public DbSet<Account>? Accounts { get; set; }
    }

}
