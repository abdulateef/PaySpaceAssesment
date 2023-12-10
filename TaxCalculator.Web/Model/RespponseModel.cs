using System;
namespace TaxCalculator.Web.Model
{
    public class RespponseModel
    {
        public string? message { get; set; }
        public decimal responseData { get; set; }
        public bool requestStatus { get; set; }
        public string? responseCode { get; set; }
    }
}

