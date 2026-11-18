using Microsoft.EntityFrameworkCore;
using PC28168.U20241G031.Openpay.Platform.Settlements.Domain.Model.Aggregates;

using PC28168.U20241G031.OpenPay.Platform.Settlements.Domain.Model.ValueObjects;
using PC28168.U20241G031.OpenPay.Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using PC28168.U20241G031.OpenPay.Platform.Shared.Infrastructure.Persistence.EFC.Interceptors;

namespace PC28168.U20241G031.Openpay.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
/// Application Entity Framework Core database context for the Openpay settlements schema.
/// </summary>
/// <param name="options">The database context options.</param>
/// <remarks>Piero Francisco Montes Chang</remarks>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddInterceptors(new AuditableEntityInterceptor());
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Settlements Bounded Context - DisbursementOrder Fluent API Mapping (Rule 13)
        builder.Entity<DisbursementOrder>().HasKey(d => d.Id);
        builder.Entity<DisbursementOrder>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<DisbursementOrder>()
            .Property(d => d.OrderTrackingCode)
            .HasConversion(vo => vo.Value, v => new OpenpayReference(v))
            .IsRequired();

        // Business Rule 1: Unique OrderTrackingCode
        builder.Entity<DisbursementOrder>()
            .HasIndex(d => d.OrderTrackingCode)
            .IsUnique();

        builder.Entity<DisbursementOrder>()
            .Property(d => d.AffiliateStoreId)
            .HasConversion(vo => vo.Value, v => new StoreIdentifier(v))
            .IsRequired();

        builder.Entity<DisbursementOrder>()
            .OwnsOne(d => d.ExecutionSchedule, schedule =>
            {
                schedule.WithOwner().HasForeignKey("Id");
                schedule.Property(s => s.ScheduledFrom).HasColumnName("ScheduledFrom").IsRequired();
                schedule.Property(s => s.ScheduledTo).HasColumnName("ScheduledTo").IsRequired();
            });
        builder.Entity<DisbursementOrder>().Navigation(d => d.ExecutionSchedule).IsRequired();

        builder.Entity<DisbursementOrder>()
            .OwnsOne(d => d.TransferCap, cap =>
            {
                cap.WithOwner().HasForeignKey("Id");
                cap.Property(c => c.Amount).HasColumnName("TransferCapAmount").HasPrecision(18, 2).IsRequired();
                cap.Property(c => c.CurrencyCode).HasColumnName("TransferCapCurrencyCode").HasMaxLength(10).IsRequired();
            });
        builder.Entity<DisbursementOrder>().Navigation(d => d.TransferCap).IsRequired();

        builder.Entity<DisbursementOrder>()
            .Property(d => d.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Entity<DisbursementOrder>()
            .Property(d => d.User)
            .HasMaxLength(20)
            .IsRequired();

        builder.Entity<DisbursementOrder>()
            .Property(d => d.Remarks)
            .HasMaxLength(85)
            .IsRequired(false);

        builder.UseSnakeCaseNamingConvention();
    }
}