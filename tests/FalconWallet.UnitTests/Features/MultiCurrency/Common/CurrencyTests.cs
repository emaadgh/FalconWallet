using FalconWallet.API.Features.MultiCurrency.Common;
using FluentAssertions;

namespace FalconWallet.UnitTests.Features.MultiCurrency.Common;
public class CurrencyTests
{
    [Fact]
    public void Create_ShouldInitializeCurrencyProperly_WhenValidParametersProvided()
    {
        // Arrange
        var name = "US Dollar";
        var code = "USD";
        var conversionRate = 1.0m;

        // Act
        var currency = Currency.Create(name, code, conversionRate);

        // Assert
        currency.Name.Should().Be(name);
        currency.Code.Should().Be(code);
        currency.ConversionRate.Should().Be(conversionRate);
        currency.LastModifyOnUtc.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        currency.Wallets.Should().BeNull();
    }

    [Fact]
    public void UpdateConversionRate_ShouldUpdateRateAndTimestamp_WhenNewRateIsProvided()
    {
        // Arrange
        var currency = Currency.Create("Euro", "EUR", 0.85m);
        var newConversionRate = 0.90m;
        var initialModifyTime = currency.LastModifyOnUtc;

        // Act
        currency.UpdateConversionRate(newConversionRate);

        // Assert
        currency.ConversionRate.Should().Be(newConversionRate);
        currency.LastModifyOnUtc.Should().BeAfter(initialModifyTime);
        currency.LastModifyOnUtc.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
    }
}
