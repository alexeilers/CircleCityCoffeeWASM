using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeStore.Server.Data;
using CoffeeStore.Server.Models;
using CoffeeStore.Shared.Models.Transaction;
using Microsoft.EntityFrameworkCore;

namespace CoffeeStore.Server.Services.Transaction
{
    public class TransactionService
    {
        private readonly ApplicationDbContext _context;
        private string _userId;

        public TransactionService(ApplicationDbContext context)
        {
            _context = context;
        }



        //CREATE
        public async Task<bool> CreateTransactionAsync(TransactionCreate model)
        {
            var transaction = new TransactionEntity
            {
                UserId = _userId,
                OrderTotal = model.OrderTotal,
                DateofTransaction = DateTime.Now
            };

            _context.Transactions.Add(transaction);
            var numberofChanges = await _context.SaveChangesAsync();

            return numberofChanges == 1;
        }



        //GET ALL FOR USER
        public async Task<IEnumerable<TransactionListItem>> GetAllTransactionsAsync()
        {
            var transaction = _context.Transactions
                .Select(t => new TransactionListItem
            {
                Id = t.Id,
                UserId = t.UserId,
                OrderTotal = t.OrderTotal,
                DateOfTransaction = t.DateofTransaction
            });

            return await transaction.ToListAsync();
        }



        //GET ALL
        public async Task<IEnumerable<TransactionListItem>> GetAllTransactionsForUserAsync()
        {
            var transaction = _context.Transactions
                .Where(t => t.UserId == _userId)
                .Select(t => new TransactionListItem
                {
                    Id = t.Id,
                    OrderTotal = t.OrderTotal,
                    DateOfTransaction = t.DateofTransaction
                });

            return await transaction.ToListAsync();
        }



        //GET BY ID
        public async Task<TransactionDetail> GetTransactionByIdAsync(int transactionId)
        {
            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(t => t.Id == transactionId && t.UserId == _userId);

            if (transaction == null) return null;

            var transactionDetail = new TransactionDetail
            {
                Id = transaction.Id,
                OrderTotal = transaction.OrderTotal,
                DateOfTransaction = transaction.DateofTransaction
            };

            return transactionDetail;
        }



        //GET LAST TRANSACTION
        public async Task<TransactionDetail> GetLastTransactionAsync()
        {
            var transaction = _context.Transactions
                .OrderByDescending(t => t.Id).First();

            if (transaction == null) return null;

            var transactionDetail = new TransactionDetail
            {
                Id = transaction.Id,
                OrderTotal = transaction.OrderTotal,
                DateOfTransaction = transaction.DateofTransaction
            };

            return transactionDetail;
        }



        //DELETE
        public async Task<bool> DeleteTransactionAsync(int transactionId)
        {
            var transaction = await _context.Transactions.FindAsync(transactionId);

            _context.Transactions.Remove(transaction);

            return await _context.SaveChangesAsync() == 1;
        }


        public void SetUserId(string userId) => _userId = userId;
    }
}
