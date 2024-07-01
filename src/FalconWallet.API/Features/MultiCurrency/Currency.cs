namespace FalconWallet.API.Features.MultiCurrency;

public class Currency
{
    public int Id { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public bool IsBase { get; set; }
    public decimal ConversionRate { get; set; }
    public DateTime LastModifyOnUtc { get; set; }
}
