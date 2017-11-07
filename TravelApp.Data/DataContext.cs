using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TravelApp.Data.Configuration;
using TravelApp.Entities.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TravelApp.Data
{

    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext()
            : base("name=ModelTravel")
        {
         //  Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
        }

        public static DataContext Create()
        {
            return new DataContext();
        }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
        #region Tables
        public DbSet<Attraction> Attraction { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Favourite> Favourite { get; set; }
        public DbSet<Rank> Rank { get; set; }
        public DbSet<TripPlan> TripPlan { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Image> Image { get; set; }
        #endregion
        public static void Init() { Create().Database.Initialize(true); }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //Configuration foreign keys and validation in separated files
            modelBuilder.Configurations.Add(new AttractionConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new BlogConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration() );
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new FavouriteConfiguration());
            modelBuilder.Configurations.Add(new RankConfiguration());
            modelBuilder.Configurations.Add(new TripPlanConfiguration());
            modelBuilder.Configurations.Add(new UserInfoConfiguration());
            modelBuilder.Configurations.Add(new IdentityRoleConfiguration());
            modelBuilder.Entity<ApplicationUser>().HasMany(p => p.Roles).WithRequired().HasForeignKey(p => p.UserId);
            modelBuilder.Entity<ApplicationRole>().HasMany(p => p.Users).WithRequired().HasForeignKey(p => p.RoleId);
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());

        }
    }
}