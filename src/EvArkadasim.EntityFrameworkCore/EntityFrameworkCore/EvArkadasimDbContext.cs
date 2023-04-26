using EvArkadasim.Entities.AdvertFiles;
using EvArkadasim.Entities.Adverts;
using EvArkadasim.Entities.Cities;
using EvArkadasim.Entities.Files;
using EvArkadasim.Entities.Logs;
using EvArkadasim.Entities.MailTemplates;
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

        #region Entities from the modules

        /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityDbContext and ITenantManagementDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */

        //Identity
        public DbSet<AppUser> Users { get; set; }
        //public DbSet<IdentityRole> Roles { get; set; }
        //public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        //public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        //public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        //public DbSet<IdentityLinkUser> LinkUsers { get; set; }

        //// Tenant Management
        //public DbSet<Tenant> Tenants { get; set; }
        //public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        #endregion

        public DbSet<Advert> Adverts { get; set; }
        public DbSet<AdvertFile> AdvertFiles { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<MailTemplate> MailTemplates { get; set; }
        public DbSet<SentMail> SentMails { get; set; }
        public DbSet<Town> Towns { get; set; }

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
