using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TaxCalculator.Core;

namespace TaxCalculator.Data
{
	public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
		
        public Context CreateDbContext(string[] args)
        {
            string connectionString = string.IsNullOrEmpty(EnvironmentVariables.ConnectionString) ? "test" : EnvironmentVariables.ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer(connectionString);

            return new Context(optionsBuilder.Options);
        }
    }
}

