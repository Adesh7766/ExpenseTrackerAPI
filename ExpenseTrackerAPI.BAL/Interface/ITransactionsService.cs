using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerAPI.Entity.Common;
using ExpenseTrackerAPI.Entity.DTO;

namespace ExpenseTrackerAPI.BAL.Interface
{
    public interface ITransactionsService
    {
        ResponseData Save(TransactionDTO vm);
        ResponseData Delete(int id);
        ResponseData<TransactionDTO> GetById(int id);
        ResponseData<List<TransactionDTO>> GetList(string user, string statusCode, string categoryCode);
    }
}
