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

        var postCode = Request.Form["Input1"].ToString();
        decimal income = Convert.ToDecimal(Request.Form["Input2"]);
        var response = await _taxCalculator.Calculate(postCode, income);
        if (response?.message != null)
        {
            // Access properties of the result object as needed
            var message = response.responseData;

            // Store the message in TempData to pass it to the view
            Message = message.ToString();

        }
        return RedirectToPage("/index");
    }
}

