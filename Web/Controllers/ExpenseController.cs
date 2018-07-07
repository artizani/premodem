using Premodem.Domain;
using Service;

namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    namespace Web.Controllers
    {
        [Route("api/[controller]")]
        public class ExpenseController : Controller
        {
            private IExpenseService _expenseService;
            public ExpenseController(IExpenseService expenseService)
            {
                   _expenseService = expenseService;
            }
            private static string[] Summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            [HttpGet("[action]")]
            public IEnumerable<Expense> WeatherForecasts()
            {
                var rng = new Random();
                return Enumerable.Range(1, 5).Select(index => new Expense
                {
                    Item = rng.Next(10, 20),
                    Amount = rng.Next(-20, 55),
                    Date = DateTime.Today.Date,
                    Description = "des",
                    Labour = rng.Next(-10, 55),
                    Paidfrom = "femi",
                    Personnel = 2,
                    Title = "test",
                    SettledDate = DateTime.Today.Day,
                    
                });
            }

            [HttpGet("[action]")]
            public IEnumerable<Expense> Expense()
            {
                var expenses = _expenseService.GetExpenseAsync(1).Result;
                return Enumerable.Range(1, 2).Select(i => expenses).ToList();
                //return expenses.ToList();
            }
            
            public class WeatherForecast
            {
                public string DateFormatted { get; set; }
                public int TemperatureC { get; set; }
                public string Summary { get; set; }

                public int TemperatureF
                {
                    get { return 32 + (int) (TemperatureC / 0.5556); }
                }
            }
        }
    }
}