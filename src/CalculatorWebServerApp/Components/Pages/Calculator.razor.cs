/*using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CalculatorWebServerApp.Components.Pages {

    public partial class Calculator : ComponentBase
    {
        [Inject] private HttpClient Http { get; set; }
        [Inject] private IJSRuntime JsRuntime { get; set; }

        private string Output { get; set; }
        private double _operandA;
        private double operandB;

        protected override async Task OnInitializedAsync()
        {
            // Set the BaseAddress to the root URL of your API
            Http.BaseAddress = new Uri("http://localhost:5167");
        }

        private async Task Calculate(string operation)
        {
            Output = _operandA + " + " + operandB + " = " + operation;
            // Send calculation request to server
            var response = await Http.PostAsJsonAsync("/api/calculator", new
            {
                operandA = _operandA,
                operandB,
                operation
            });

            Output = response.IsSuccessStatusCode + "";
            if (response.IsSuccessStatusCode)
            {
                // Get result from response
                Output = await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Handle error
                // Output = "Error";
            }
            await JsRuntime.InvokeVoidAsync("console.log", $"Calculate function called with operation: {operation}");
        }
    }
}
*/