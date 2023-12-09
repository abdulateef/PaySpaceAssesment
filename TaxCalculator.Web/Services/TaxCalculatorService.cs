using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using TaxCalculator.Web.Model;

namespace TaxCalculator.Web.Services
{
	public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TaxCalculatorService(IHttpClientFactory httpClientFactory)
		{
            _httpClientFactory = httpClientFactory;
		}

        public async Task<RespponseModel<decimal>> Calculate(string postCode, decimal income)
        {
            try
            {
                using (var client = _httpClientFactory.CreateClient())
                {
                    // Customize the client and request headers as needed
                    // For example, you might set authorization headers or specify content type

                    // Create a dictionary for the request parameters
                    var parameters = new
                    {
                        postCode = postCode,
                        income = income
                    };
                    string url = $"{EnvironmentVariables.apiEndpoint}calculate";
                    // Send a POST request to the API
                    var response = await client.PostAsJsonAsync(url, parameters);

                    // Ensure the request was successful
                    response.EnsureSuccessStatusCode();

                    // Read and return the response content as a string
                    var content =  await response.Content.ReadAsStringAsync();
                    var respponseModel = JsonSerializer.Deserialize<RespponseModel<decimal>>(content);
                    if (respponseModel != null)
                    {
                        return respponseModel;
                    }
                    else
                    {
                        return new RespponseModel<decimal> { };

                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                Console.WriteLine($"Error calling API: {ex.Message}");
                return null;
            }
        }
    }
}

