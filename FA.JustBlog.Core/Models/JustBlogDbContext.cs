using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Models
{
	public class JustBlogDbContext : DbContext
    {
        public JustBlogDbContext()
        {

        }

        public JustBlogDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostTagMap> PostTags { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PostTagMap>().HasKey(x => new
            {
                x.PostId,
                x.TagId
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.;database=JustBlogDb2;Trusted_connection=True;" +
               "TrustServerCertificate=True");
            }
        }

        //public override int SaveChanges()
        //{
        //    BeforeSaveChanges();
        //    return base.SaveChanges();
        //}

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    BeforeSaveChanges();
        //    return base.SaveChangesAsync(cancellationToken);
        //}

        //private void BeforeSaveChanges()
        //{
        //    var entities = ChangeTracker.Entries();
        //    foreach (var entry in entities)
        //    {
        //        if (entry.Entity is IBaseEntity entityBase)
        //        {
        //            var now = DateTime.Now;
        //            switch (entry.State)
        //            {
        //                case EntityState.Modified:
        //                    entityBase.UpdatedAt = now;
        //                    break;

        //                case EntityState.Added:
        //                    entityBase.InsertedAt = DateTime.Now;
        //                    entityBase.UpdatedAt = now;
        //                    break;
        //            }
        //        }
        //    }
        //}
    }
}
