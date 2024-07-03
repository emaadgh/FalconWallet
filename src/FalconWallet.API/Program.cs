using FalconWallet.API.Common.Persistence;
using FalconWallet.API.Features.MultiCurrency.Common;
using FalconWallet.API.Features.MultiCurrency.CreateCurrency;
using FalconWallet.API.Features.MultiCurrency.UpdateConversionRate;
using FalconWallet.API.Features.UserWallet.Common;
using FalconWallet.API.Features.UserWallet.CreateWallet;
using FalconWallet.API.Features.UserWallet.UpdateTitle;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<WalletDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(WalletDbContextSchema.DefaultConnectionStringName)));

builder.Services.AddScoped<CurrencyService>();
builder.Services.AddScoped<WalletService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddCreateCurrencyEndPoint();
app.AddUpdateConversionRateEndPoint();
app.AddCreateWalletEndPoint();
app.AddUpdateTitleEndPoint();

app.Run();