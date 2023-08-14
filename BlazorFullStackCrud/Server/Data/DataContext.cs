namespace BlazorFullStackCrud.Server.Data
{
    public class DataContext : DbContext
    {
        
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<HsNonVendor> HsNonVendors { get; set; }
        public DbSet<HsNonVendorCity> HsNonVendorCities { get; set; }
        public DbSet<Hsp> Hsps { get; set; }
        public DbSet<HspItem> HspItems { get; set; }
        public DbSet<HspType> HspTypes { get; set; }
        public DbSet<HsSewa> HsSewas { get; set; }
        public DbSet<HsTransport> HsTransports { get; set; }
        public DbSet<HsUpah> HsUpahs { get; set; }
        public DbSet<HsVendor> HsVendors { get; set; }
        public DbSet<HsVendorQuot> HsVendorQuots { get; set; }
        public DbSet<MaterialCategory> MaterialCategories { get; set; }
        public DbSet<RiskAndProfit> RiskAndProfits { get; set; }
        public DbSet<RiskAndProfitMat> RiskAndProfitMats { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Vendor> Vendors { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessUnit>(entity => entity.ToTable("EmcsMsBusinessUnit"));
            modelBuilder.Entity<City>(entity => entity.ToTable("EmcsMsCity"));
            modelBuilder.Entity<HsNonVendor>(entity => entity.ToTable("EmcsMsHsNonVendor"));
            modelBuilder.Entity<HsNonVendorCity>(entity => entity.ToTable("EmcsMsHsNonVendorCity"));
            modelBuilder.Entity<Hsp>(entity => entity.ToTable("EmcsMsHsp"));
            modelBuilder.Entity<HspItem>(entity => entity.ToTable("EmcsMsHspItem"));
            modelBuilder.Entity<HspType>(entity => entity.ToTable("EmcsMsHspType"));
            modelBuilder.Entity<HsSewa>(entity => entity.ToTable("EmcsMsHsSewa"));
            modelBuilder.Entity<HsTransport>(entity => entity.ToTable("EmcsMsHsTransport"));
            modelBuilder.Entity<HsUpah>(entity => entity.ToTable("EmcsMsHsUpah"));
            modelBuilder.Entity<HsVendor>(entity => entity.ToTable("EmcsMsHsVendor"));
            modelBuilder.Entity<HsVendorQuot>(entity => entity.ToTable("EmcsMsHsVendorQuot"));
            modelBuilder.Entity<MaterialCategory>(entity => entity.ToTable("EmcsMsMaterialCategory"));
            modelBuilder.Entity<RiskAndProfit>(entity => entity.ToTable("EmcsMsRiskAndProfit"));
            modelBuilder.Entity<RiskAndProfitMat>(entity => entity.ToTable("EmcsMsRiskAndProfitMat"));
            modelBuilder.Entity<Setting>(entity => entity.ToTable("EmcsMsSetting"));
            modelBuilder.Entity<Vendor>(entity => entity.ToTable("EmcsMsVendor"));

            modelBuilder.Entity<Comic>().HasData(
                new Comic { Id = 1, Name = "Marvel" },
                new Comic { Id = 2, Name = "DC" }
            );

            modelBuilder.Entity<SuperHero>().HasData(
                new SuperHero
                {
                    Id = 1,
                    FirstName = "Peter",
                    LastName = "Parker",
                    HeroName = "Spiderman",
                    ComicId = 1,
                },
                new SuperHero
                {
                    Id = 2,
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    HeroName = "Batman",
                    ComicId = 2
                }
            );
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }

        public DbSet<Comic> Comics { get; set; }
    }
}
