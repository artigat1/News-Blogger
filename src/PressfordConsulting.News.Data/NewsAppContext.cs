namespace PressfordConsulting.News.Data
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using Resources;

    public class NewsAppContext : DbContext
    {
        public NewsAppContext()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<NewsAppContext>());
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleLike> ArticleLikes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasKey(a => a.ArticleId);
            modelBuilder.Entity<Article>()
                .Property(a => a.ArticleId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<ArticleLike>().HasKey(a => a.LikeId);
            modelBuilder.Entity<ArticleLike>()
                .Property(a => a.LikeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Article>()
                .HasMany<ArticleLike>(a => a.Likes)
                .WithRequired(a => a.Article)
                .HasForeignKey(a => a.ArticleId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
