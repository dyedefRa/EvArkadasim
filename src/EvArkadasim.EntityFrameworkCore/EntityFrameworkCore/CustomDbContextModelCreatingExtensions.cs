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
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace EvArkadasim.EntityFrameworkCore
{
    public static class CustomDbContextModelCreatingExtensions
    {
        public static void ConfigureEvArkadasim(this ModelBuilder modelBuilder)
        {
            Check.NotNull(modelBuilder, nameof(modelBuilder));
            var dbTablePrefix = EvArkadasimConsts.DbTablePrefix;


            modelBuilder.Entity<AdvertCityTown>(entity =>
            {
                entity.ToTable(dbTablePrefix + "AdvertCityTowns");

                entity.HasIndex(e => e.AdvertId, "IX_AppAdvertCityTown_AdvertId");
                entity.HasIndex(e => e.CityId, "IX_AppAdvertCityTown_CityId");
                entity.HasIndex(e => e.TownId, "IX_AppAdvertCityTown_TownId");

                entity.HasOne(d => d.Advert)
                    .WithMany(p => p.AdvertCityTowns)
                    .HasForeignKey(d => d.AdvertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppAdvertCityTowns_AppAdverts");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.AdvertCityTowns)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppAdvertCityTowns_AppCities");

                entity.HasOne(d => d.Town)
                    .WithMany(p => p.AdvertCityTowns)
                    .HasForeignKey(d => d.TownId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppAdvertCityTowns_AppTowns");
            });

            modelBuilder.Entity<AdvertFile>(entity =>
            {
                entity.ToTable(dbTablePrefix + "AdvertFiles");

                entity.Property(e => e.AdvertId).HasColumnType("int");
                entity.Property(e => e.FileId).HasColumnType("int");

                entity.HasIndex(e => e.AdvertId, "IX_AppAdvertFile_AdvertId");
                entity.HasIndex(e => e.FileId, "IX_AppAdvertFile_FileId");

                entity.HasOne(d => d.Advert)
                    .WithMany(p => p.AdvertFiles)
                    .HasForeignKey(d => d.AdvertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppAdvertFiles_AppAdverts");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.AdvertFiles)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppAdvertFiles_AppFiles");

            });

            modelBuilder.Entity<Advert>(entity =>
            {
                entity.ToTable(dbTablePrefix + "Adverts");

                entity.HasIndex(e => e.UserId, "IX_AppAdvert_UserId");

                //entity.HasQueryFilter(x => EF.Property<Status>(x, "Status") == Status.Active);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Adverts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppAdverts_AbpUsers");
            });

            modelBuilder.Entity<AdvertUnitPrice>(entity =>
            {
                entity.ToTable(dbTablePrefix + "AdvertUnitPrices");

                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");

                entity.HasIndex(e => e.AdvertId, "IX_AppAdvertUnitPrice_AdvertId");

                entity.HasOne(d => d.Advert)
                    .WithMany(p => p.AdvertUnitPrices)
                    .HasForeignKey(d => d.AdvertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppAdvertUnitPrices_AbpUsers");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable(dbTablePrefix + "Cities");

                entity.Property(e => e.Title).HasMaxLength(255);
                entity.Property(e => e.AreaNumber).HasMaxLength(255);

            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable(dbTablePrefix + "Files");

                entity.Property(e => e.Name).IsRequired(true).HasMaxLength(500);
                entity.Property(e => e.Path).IsRequired(true).HasMaxLength(500);
                entity.Property(e => e.FullPath).IsRequired(true).HasMaxLength(500);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable(dbTablePrefix + "Logs");
            });

            modelBuilder.Entity<MailTemplate>(entity =>
            {
                entity.ToTable(dbTablePrefix + "MailTemplates");

                entity.Property(e => e.Subject).IsRequired(true).HasMaxLength(500);
                entity.Property(e => e.MailKey).IsRequired(true).HasMaxLength(100);
                entity.Property(e => e.MailTemplateValue).IsRequired(true);
            });

            modelBuilder.Entity<MessageContent>(entity =>
            {
                entity.ToTable(EvArkadasimConsts.DbTablePrefix + "MessageContents");

                entity.HasIndex(e => e.MessageId, "IX_AppMessageContent_MessageId");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.MessageContents)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppMessageContents_AppMessages");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable(EvArkadasimConsts.DbTablePrefix + "Messages");

                entity.HasIndex(e => e.SenderId, "IX_AppMessage_SenderId");
                entity.HasIndex(e => e.ReceiverId, "IX_AppMessage_ReceiverId");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.SendedMessages)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppMessageContents_AppSendedMessages");
                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.ReceivedMessages)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppMessageContents_AppReceivedMessages");
            });

            modelBuilder.Entity<SentMail>(entity =>
            {
                entity.ToTable(dbTablePrefix + "SentMail");

                entity.Property(e => e.ToAddress).IsRequired(false).HasMaxLength(500);
                entity.Property(e => e.CcAddress).IsRequired(false).HasMaxLength(500);
                entity.Property(e => e.BccAddress).IsRequired(false).HasMaxLength(500);
                entity.Property(e => e.Subject).IsRequired(true);
                entity.Property(e => e.Body).IsRequired(true);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.ToTable(dbTablePrefix + "Towns");

                entity.Property(e => e.Title).IsRequired(true).HasMaxLength(255);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Towns)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppTowns_AppCities");
            });
        }
    }
}
