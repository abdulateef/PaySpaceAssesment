using System;
namespace TaxCalculator.Data.Entities
{
	public class BaseEntity
	{
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

    }
}

