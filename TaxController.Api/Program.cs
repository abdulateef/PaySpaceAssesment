using System;
using Microsoft.EntityFrameworkCore;
using TaxCalculator.Core;
using TaxCalculator.Core.Interface;
using TaxCalculator.Core.Interface.Manager;
using TaxCalculator.Core.Interface.Repositories;
using TaxCalculator.Data;
using TaxCalculator.Data.Repositories;
using TaxCalculator.Infrastructure.Manager;
using TaxCalculator.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddTransient<ITaxPostCodeManager, TaxPostCodeManager>();
builder.Services.AddTransient<ITaxRateManager, TaxRateManager>();
builder.Services.AddTransient<ITaxTypeManager, TaxTypeManager>();
builder.Services.AddTransient<ITaxPostCodeRepository, TaxPostCodeRepository>();
builder.Services.AddTransient<ITaxRateRepositories, TaxRateRepositories>();
builder.Services.AddTransient<ITaxTypeRepositories, TaxTypeRepositories>();
builder.Services.AddTransient<ITaxCalculatorService, TaxCalculatorService>();
builder.Services.AddTransient<ICalculatedTaxeRepository, CalculatedTaxeRepository>();
builder.Services.AddDbContext<Context>(opt =>
opt.UseSqlServer(EnvironmentVariables.ConnectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

