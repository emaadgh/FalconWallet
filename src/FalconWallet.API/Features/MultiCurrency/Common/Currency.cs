namespace FalconWallet.API.Features.MultiCurrency.Common;

public class Currency
{
    public int Id { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal ConversionRate { get; set; }
    public DateTime LastModifyOnUtc { get; set; }

    public void UpdateConversionRate(decimal conversionRate)
    {
        ConversionRate = conversionRate;
        LastModifyOnUtc = DateTime.UtcNow;
    }
}
