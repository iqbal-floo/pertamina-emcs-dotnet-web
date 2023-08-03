namespace BlazorFullStackCrud.Server.Data
{
    public class TransactionContext : DbContext
    {
        
        public DbSet<TrFile> TrFiles { get; set; }
        public DbSet<TrFileSharing> TrFileSharings { get; set; }
        public DbSet<TrFileSharingVendor> TrFileSharingVendors { get; set; }
        public DbSet<MaterialRequest> MaterialRequests { get; set; }
        public DbSet<Oe> Oes { get; set; }
        public DbSet<OeChartConfig> OeChartConfigs { get; set; }
        public DbSet<OeHsp> OeHsps { get; set; }
        public DbSet<OeHspItem> OeHspItems { get; set; }
        public DbSet<OeHspType> OeHspTypes { get; set; }
        public DbSet<OeJobsType> OeJobsTypes { get; set; }
        public DbSet<OeReviewer> OeReviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrFile>(entity => entity.ToTable("EmcsTrFile"));
            modelBuilder.Entity<TrFileSharing>(entity => entity.ToTable("EmcsTrFileSharing"));
            modelBuilder.Entity<TrFileSharingVendor>(entity => entity.ToTable("EmcsTrFileSharingHsVendor"));
            modelBuilder.Entity<MaterialRequest>(entity => entity.ToTable("EmcsTrMaterialRequest"));
            modelBuilder.Entity<Oe>(entity => entity.ToTable("EmcsTrOe"));
            modelBuilder.Entity<OeChartConfig>(entity => entity.ToTable("EmcsTrOeChartConfig"));
            modelBuilder.Entity<OeHsp>(entity => entity.ToTable("EmcsTrOeHsp"));
            modelBuilder.Entity<OeHspItem>(entity => entity.ToTable("EmcsTrOeHspItem"));
            modelBuilder.Entity<OeHspType>(entity => entity.ToTable("EmcsTrOeHspType"));
            modelBuilder.Entity<OeJobsType>(entity => entity.ToTable("EmcsTrOeJobsType"));
            modelBuilder.Entity<OeReviewer>(entity => entity.ToTable("EmcsTrOeReviewer"));
            
        }
    }
}
