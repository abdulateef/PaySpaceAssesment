using System;
using Microsoft.EntityFrameworkCore;
using TaxCalculator.Data.Entities;

namespace TaxCalculator.Data
{
	public class Context : DbContext
	{
		public Context()
		{

		}
		public Context(DbContextOptions<Context> options) : base(options)
		{

		}
		public DbSet<TaxPostCode> TaxPostCodes { get; set; }
        public DbSet<TaxRate> TaxRates { get; set; }
        public DbSet<TaxType> TaxTypes { get; set; }
    }
}

