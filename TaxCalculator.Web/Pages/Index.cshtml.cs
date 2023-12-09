using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxCalculator.Web.Model;
using TaxCalculator.Web.Services;

namespace TaxCalculator.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ITaxCalculatorService _taxCalculator;
    public IndexModel(ILogger<IndexModel> logger, ITaxCalculatorService taxCalculator)
    {
        _logger = logger;
        _taxCalculator = taxCalculator;
    }
    [TempData]
    public string Message { get; set; }
    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPost()
    {
        // Handle the form submission (POST request)
        // Access the form values using Request.Form["Input1"] and Request.Form["Input2"]

        // Example: Log the values to the console
        var postCode = Request.Form["Input1"].ToString();
        decimal income = Convert.ToDecimal(Request.Form["Input2"]);
        var response = await _taxCalculator.Calculate(postCode, income);
        if (response?.Message != null)
        {
            // Access properties of the result object as needed
            var message = response.ResponseData;

            // Store the message in TempData to pass it to the view
            Message = message.ToString();

            // Perform further processing with the deserialized data...
        }
        return RedirectToPage("/index");
    }
}

