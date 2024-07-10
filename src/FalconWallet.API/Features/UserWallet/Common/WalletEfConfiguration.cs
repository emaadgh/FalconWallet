using FalconWallet.API.Common.Persistence;
using FalconWallet.API.Features.UserWallet.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FalconWallet.API.Features.UserWallet.Common;

public class WalletEfConfiguration : IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.ToTable(WalletDbContextSchema.Wallet.TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x=>x.UserId)
               .IsRequired();

        builder.Property(x => x.Title)
               .IsRequired(false)
               .IsUnicode(true)
               .HasMaxLength(30);

        builder.Property(x => x.Balance)
               .IsRequired(true)
               .HasColumnType(WalletDbContextSchema.DefaultDecimalColumnType);


        builder.Property(x => x.CreatedOn)
               .IsRequired();

        builder.Property(x => x.CurrencyId)
               .IsRequired();

        builder.Property(x => x.Status)
               .IsRequired(true)
               .HasDefaultValue(WalletStatus.None);

        builder.HasMany(x => x.Transactions)
               .WithOne(z => z.Wallet)
               .HasForeignKey(z => z.WalletId);
    }
}
