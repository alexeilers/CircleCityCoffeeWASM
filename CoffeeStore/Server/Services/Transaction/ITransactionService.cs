using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeStore.Shared.Models.Transaction;

namespace CoffeeStore.Server.Services.Transaction
{
    public interface ITransactionService
    {
        Task<bool> CreateTransactionAsync(TransactionCreate model);
        Task<IEnumerable<TransactionListItem>> GetAllTransactionsAsync();
        Task<IEnumerable<TransactionListItem>> GetAllTransactionsForUserAsync();
        Task<TransactionDetail> GetTransactionByIdAsync(int transactionId);
        Task<TransactionDetail> GetLastTransactionAsync();
        Task<bool> DeleteTransactionAsync(int transactionId);

        void SetUserId(string userId);
    }
}
