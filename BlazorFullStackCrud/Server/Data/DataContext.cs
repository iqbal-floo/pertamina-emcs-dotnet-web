namespace BlazorFullStackCrud.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UnitBisnis>(entity =>
                {
                    entity.ToTable("ms_unit_bisnis");

                    entity.Property(e => e.id)
                    .HasColumnName("unit_bisnis_id")
                    .HasMaxLength(36)
                    .ValueGeneratedOnAdd();

                    entity.Property(e => e.kode)
                    .HasColumnName("unit_bisnis_kode")
                    .HasMaxLength(36);

                    entity.Property(e => e.name)
                    .HasColumnName("unit_bisnis_name")
                    .HasMaxLength(36);

                    //entity.Property(e => e.isActive)
                    //.HasColumnName("is_active")
                    //.HasMaxLength(36);

                    entity.Property(e => e.notes)
                    .HasColumnName("notes")
                    .HasMaxLength(36);

                }
            );

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

        public DbSet<UnitBisnis> UnitBisnis { get; set; }

        public DbSet<SuperHero> SuperHeroes { get; set; }

        public DbSet<Comic> Comics { get; set; }
    }
}
