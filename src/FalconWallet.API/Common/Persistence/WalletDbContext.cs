using FalconWallet.API.Features.MultiCurrency.Common;
using FalconWallet.API.Features.UserWallet.Domain;
using Microsoft.EntityFrameworkCore;

namespace FalconWallet.API.Common.Persistence;

public class WalletDbContext : DbContext
{
    public WalletDbContext(DbContextOptions<WalletDbContext> dbContextOptions)
        : base(dbContextOptions)
    {

    }

    public DbSet<Wallet> Wallets => Set<Wallet>();
    public DbSet<Currency> Currencies => Set<Currency>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var assembly = typeof(IAssemblyMarker).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }
}
