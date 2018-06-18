using System.Collections.Generic;
using System.Threading.Tasks;
using Premodem.Domain;

namespace EfData.Repository
{
    public interface IExpenseRepository
    {
        Task<List<PremodemExpense>> GetExpensesAsync();
        Task<PagingResult<PremodemExpense>> GetExpensesPageAsync(int skip, int take);
        Task<PremodemExpense> GetExpenseAsync(int id);
        Task<PremodemExpense> InsertExpenseAsync(PremodemExpense expense);
        Task<bool> UpdateExpenseAsync(PremodemExpense expense);
        Task<bool> DeleteExpenseAsync(int id);
    }
}