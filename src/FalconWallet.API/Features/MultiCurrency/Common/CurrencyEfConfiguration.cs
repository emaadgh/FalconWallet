using FalconWallet.API.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FalconWallet.API.Features.MultiCurrency.Common;

public class CurrencyEfConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.ToTable(WalletDbContextSchema.Currency.TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .IsRequired(true)
            .IsUnicode(false)
            .HasMaxLength(10);

        builder.HasIndex(x => x.Code)
            .IsUnique();

        builder.Property(x => x.Name)
            .IsRequired(true)
            .IsUnicode(true)
            .HasMaxLength(25);

        builder.Property(x => x.ConversionRate)
            .IsRequired(true)
            .HasColumnType(WalletDbContextSchema.DefaultDecimalColumnType);

        builder.Property(x => x.LastModifyOnUtc)
            .IsRequired();

        builder.HasMany(x => x.Wallets)
               .WithOne(z => z.Currency)
               .HasForeignKey(z => z.CurrencyId);
    }
}
