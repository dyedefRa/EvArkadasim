using EvArkadasim.Entities.AdvertCityTowns;
using EvArkadasim.Entities.AdvertFiles;
using EvArkadasim.Entities.Adverts;
using EvArkadasim.Entities.AdvertUnitPrices;
using EvArkadasim.Entities.Cities;
using EvArkadasim.Entities.Files;
using EvArkadasim.Entities.Logs;
using EvArkadasim.Entities.MailTemplates;
using EvArkadasim.Entities.MessageContents;
using EvArkadasim.Entities.Messages;
using EvArkadasim.Entities.SentMails;
using EvArkadasim.Entities.Towns;
using EvArkadasim.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.Users.EntityFrameworkCore;

namespace EvArkadasim.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class EvArkadasimDbContext :
        AbpDbContext<EvArkadasimDbContext>
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */

        public DbSet<AdvertCityTown> AdvertCityTowns { get; set; }
        public DbSet<AdvertFile> AdvertFiles { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<AdvertUnitPrice> AdvertUnitPrices { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<MailTemplate> MailTemplates { get; set; }
        public DbSet<MessageContent> MessageContents { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SentMail> SentMails { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<AppUser> Users { get; set; }

        public EvArkadasimDbContext(DbContextOptions<EvArkadasimDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(EvArkadasimConsts.DbTablePrefix + "YourEntities", EvArkadasimConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            //TODOO 3
            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users");
                b.ConfigureByConvention();
                b.ConfigureAbpUser();
                b.Property(a => a.UserType).HasColumnName("UserType").HasColumnType("int");
                b.Property(a => a.Gender).HasColumnName("Gender").HasColumnType("int");
                b.Property(a => a.Status).HasColumnName("Status").HasColumnType("int");
                b.Property(a => a.BirthDate).HasColumnName("BirthDate").HasColumnType("datetime");
                b.Property(a => a.ImageId).HasColumnName("ImageId").HasColumnType("int");
                b.HasOne<IdentityUser>().WithOne().HasForeignKey<AppUser>(x => x.Id);
            });

        }
    }
}
