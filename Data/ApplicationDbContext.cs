using eComMaster.Models.Auth;
using eComMaster.Models.CustomerData;
using eComMaster.Models.MasterData;
using eComMaster.Models.MasterData.ConfigItems;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eComMaster.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // Auth
        public DbSet<AuthUser> AuthUser { get; set; }
        // Master Data
        public DbSet<PcCategory> PcCategory { get; set; }
        public DbSet<PcSeries> PcSeries { get; set; }
        public DbSet<PcModel> PcModel { get; set; }
        // PC Config Items
        public DbSet<ConfigCasing> ConfigCasing { get; set; }
        public DbSet<ConfigDisplay> ConfigDisplay { get; set; }
        public DbSet<ConfigGraphics> ConfigGraphics { get; set; }
        public DbSet<ConfigMemory> ConfigMemory { get; set; }
        public DbSet<ConfigMisc> ConfigMisc { get; set; }
        public DbSet<ConfigPorts> ConfigPorts { get; set; }
        public DbSet<ConfigPower> ConfigPower { get; set; }
        public DbSet<ConfigProcessor> ConfigProcessor { get; set; }
        public DbSet<ConfigStorage> ConfigStorage { get; set; }
        // Customer Data
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<CheckoutModel> CheckoutModel { get; set; }
    }
}