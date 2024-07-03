using FalconWallet.API.Features.MultiCurrency.Common;
using FalconWallet.API.Features.UserWallet.Domain;
using Microsoft.EntityFrameworkCore;

namespace FalconWallet.API.Common.Persistence;

public static class WalletDbContextSchema
{
    public const string DefaultSchema = "wallet";
    public const string DefaultConnectionStringName = "WalletDbContextConnection";
    public const string DefaultDecimalColumnType = "decimal(18,6)";

    public static class Currency
    {
        public const string TableName = "Currencies";
    }

    public static class Wallet
    {
        public const string TableName = "Wallets";
    }
}
