using FalconWallet.API.Common.Persistence;
using FalconWallet.API.Features.Transactions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FalconWallet.API.Features.Transactions.Common;

public class TransactionEfConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable(WalletDbContextSchema.Transaction.TableName);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.WalletId)
            .IsRequired(true);

        builder.Property(x => x.Description)
            .IsRequired(false)
            .IsUnicode(true)
            .HasMaxLength(200);

        builder.Property(x => x.Amount)
            .IsRequired(true)
            .HasColumnType(WalletDbContextSchema.DefaultDecimalColumnType);

        builder.Property(x => x.Type)
            .IsRequired();

        builder.Property(x => x.CreatedOn)
            .IsRequired();
    }
}
