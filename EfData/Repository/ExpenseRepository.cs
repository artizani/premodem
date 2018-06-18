using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Premodem.Domain;

namespace EfData.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        
        private readonly PremodemContext _context;
        private readonly ILogger _logger;

        public ExpenseRepository(PremodemContext context, ILoggerFactory loggerFactory) {
          _context = context;
          _logger = loggerFactory.CreateLogger("Premodem Repository");
        }

        public async Task<List<PremodemExpense>> GetExpensesAsync()
        {
            return await _context.PremodemExpense.OrderBy(c => c.Date)
                                 .Include(c => c.Title).ToListAsync();
        }

        public async Task<PagingResult<PremodemExpense>> GetExpensesPageAsync(int skip, int take)
        {
            var totalRecords = await _context.PremodemExpense.CountAsync();
            var expenses = await _context.PremodemExpense
                                 .OrderBy(c => c.Date)
                                 .Include(c => c.Id)
                                 .Include(c => c.Id)
                                 .Skip(skip)
                                 .Take(take)
                                 .ToListAsync();
            return new PagingResult<PremodemExpense>(expenses, totalRecords);
        }

        public async Task<PremodemExpense> GetExpenseAsync(int id)
        {
            return await _context.PremodemExpense
                                 .Include(c => c.Date)
                                 .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<PremodemExpense> InsertExpenseAsync(PremodemExpense customer)
        {
            _context.Add(customer);
            try
            {
              await _context.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
               _logger.LogError($"Error in {nameof(InsertExpenseAsync)}: " + exp.Message);
            }

            return customer;
        }

        public async Task<bool> UpdateExpenseAsync(PremodemExpense customer)
        {
            //Will update all properties of the Customer
            _context.PremodemExpense.Attach(customer);
            _context.Entry(customer).State = EntityState.Modified;
            try
            {
              return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
               _logger.LogError($"Error in {nameof(UpdateExpenseAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<bool> DeleteExpenseAsync(int id)
        {
            //Extra hop to the database but keeps it nice and simple for this demo
            //Including orders since there's a foreign-key constraint and we need
            //to remove the orders in addition to the customer
            var customer = await _context.PremodemExpense
                                .Include(c => c.Date)
                                .SingleOrDefaultAsync(c => c.Id == id);
            _context.Remove(customer);
            try
            {
              return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (System.Exception exp)
            {
               _logger.LogError($"Error in {nameof(DeleteExpenseAsync)}: " + exp.Message);
            }
            return false;
        }

    }
    }
