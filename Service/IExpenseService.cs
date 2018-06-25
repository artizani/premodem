using System.Collections.Generic;
using System.Threading.Tasks;
using Premodem.Domain;

namespace Service
{
    public interface IExpenseService
    {
        Task<List<Expense>> GetExpensesAsync();
        Task<PagingResult<Expense>> GetExpensesPageAsync(int skip, int take);
        Task<Expense> GetExpenseAsync(int id);
        Task<Expense> InsertExpenseAsync(Expense expense);
        Task<bool> UpdateExpenseAsync(Expense expense);
        Task<bool> DeleteExpenseAsync(int id);
    }
}