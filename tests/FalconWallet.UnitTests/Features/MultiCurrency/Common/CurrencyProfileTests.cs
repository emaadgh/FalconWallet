using AutoMapper;
using FalconWallet.API.Features.MultiCurrency.Common;
using FalconWallet.API.Features.MultiCurrency.CreateCurrency;
using FluentAssertions;

namespace FalconWallet.UnitTests.Features.MultiCurrency.Common;
public class CurrencyProfileTests
{
    private readonly IMapper _mapper;

    public CurrencyProfileTests()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<CurrencyProfile>());
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void CurrencyProfile_ShouldHaveValidConfiguration()
    {
        // Arrange & Act
        Action act = () => _mapper.ConfigurationProvider.AssertConfigurationIsValid();

        // Assert
        act.Should().NotThrow();
    }

    [Fact]
    public void CurrencyProfile_ShouldMapCurrencyToCreateCurrencyResponse_WhenValidCurrencyProvided()
    {
        // Arrange
        var currency = Currency.Create("US Dollar", "USD", 1.0m);

        // Act
        var response = _mapper.Map<CreateCurrencyResponse>(currency);

        // Assert
        response.Should().NotBeNull();
        response.Id.Should().Be(currency.Id);
        response.Code.Should().Be(currency.Code);
        response.Name.Should().Be(currency.Name);
    }
}
