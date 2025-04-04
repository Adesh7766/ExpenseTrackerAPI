using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ExpenseTrackerAPI.DAL.Interface;
using ExpenseTrackerAPI.Entity.Common;
using ExpenseTrackerAPI.Entity.DTO;
using ExpenseTrackerAPI.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.DAL.Repository
{
    public class TransactionsRepo : ITransactionsRepo
    {
        private readonly ApplicationDbContext _context;

        public TransactionsRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResponseData Save(Transaction vm)
        {
            _context.Add(vm);
            _context.SaveChanges();
            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Data Saved Successfully"
            };
        }

        public ResponseData Update(Transaction vm)
        {
            _context.SaveChanges();
            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Data Updated Successfully"
            };
        }

        public ResponseData Delete(int id)
        {
            var data = _context.Transactions
                        .Where(x => x.ID == id && x.IsActive == true)
                        .FirstOrDefault();

            if (data == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Transaction not available."
                };
            }
            else
            {
                data.IsActive = false;
                _context.SaveChanges();
                return new ResponseData
                {
                    SuccessStatus = true,
                    Message = "Transaction deleted successfully."
                };
            }
        }

        public ResponseData<Transaction> GetById(int id)
        {
            var data = _context.Transactions
                        .Where(xyz => xyz.IsActive == true
                                && xyz.ID == id)
                        .FirstOrDefault();

            return new ResponseData<Transaction>
            {
                SuccessStatus = true,
                Data = data
            };
        }

        public ResponseData<List<Transaction>> GetAllList(string user, string statusCode, string categoryCode)
        {
            var data = _context.Transactions
                        .Where(x => x.IsActive == true
                            && (string.IsNullOrEmpty(user) || x.User.FullName.Contains(user))
                            && (string.IsNullOrEmpty(statusCode) || x.Statuses.Code.Contains(statusCode))
                            && (string.IsNullOrEmpty(categoryCode) || x.Category.Code.Contains(categoryCode))
                        )
                        .ToList();

            return new ResponseData<List<Transaction>>
            {
                SuccessStatus = true,
                Data = data
            };
        }

        public ResponseData<List<TransactionByCategoryDTO>> GetTransactionByCategory()
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                string spName = "Get_Amount_By_Category";

                var data = connection.Query<TransactionByCategoryDTO>(
                spName,
                commandType: CommandType.StoredProcedure
                ).ToList();

                return new ResponseData<List<TransactionByCategoryDTO>>
                {
                    SuccessStatus = true,
                    Data = data
                };    
            }                 
        }

        public ResponseData<TotalAmountDTO> GetTotalAmount()
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                string spName = "GetTotalSpending";

                var data = connection.Query<TotalAmountDTO>(
                    spName,
                    commandType: CommandType.StoredProcedure
                ).FirstOrDefault();

                return new ResponseData<TotalAmountDTO>
                {
                    SuccessStatus = true,
                    Data = data
                };
            }           
        }
    }
}
