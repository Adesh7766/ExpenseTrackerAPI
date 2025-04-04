using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerAPI.Entity.Common;
using ExpenseTrackerAPI.Entity.DTO;
using ExpenseTrackerAPI.Entity.Models;

namespace ExpenseTrackerAPI.DAL.Interface
{
    public interface ITransactionsRepo
    {
        ResponseData Save(Transaction vm);
        ResponseData Update(Transaction vm);
        ResponseData Delete(int id);
        ResponseData<Transaction> GetById(int id);
        ResponseData<List<Transaction>> GetAllList(string user, string statusCode, string categoryCode);
        ResponseData<List<TransactionByCategoryDTO>> GetTransactionByCategory();
        ResponseData<TotalAmountDTO> GetTotalAmount();

    }
}
