using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ExpenseTrackerAPI.DAL.ConverterInterface;
using ExpenseTrackerAPI.Entity.Common;
using ExpenseTrackerAPI.Entity.DTO;

namespace ExpenseTrackerAPI.DAL.Converter
{
    public class TransactionConverter : ITransactionsConverter
    {
        private readonly ApplicationDbContext _context;

        public TransactionConverter(ApplicationDbContext context)
        {
            _context = context;
        }

        public int UserIDConverter(string userName)
        {
            int id = _context.Users.Where(x => x.FullName.Contains(userName))
                                           .Select(x => x.ID).FirstOrDefault();

            return id;
        }

        public string? UserIDConverterIntoDTO(int userId)
        {
            string? userName = _context.Users.Where(x => x.ID == userId)
                                           .Select(x => x.FullName).FirstOrDefault();

            return userName;
        }

        public int StatusIDConverter(string statusCode)
        {
            int id = _context.Statuses.Where(x => x.Code.Contains(statusCode))
                                           .Select(x => x.ID).FirstOrDefault();

            return id;
        }

        public string? StatusIDConverterIntoDTO(int statusId)
        {
            string? statusCode = _context.Statuses.Where(x => x.ID == statusId)
                                           .Select(x => x.Code).FirstOrDefault();

            return statusCode;
        }

        public int CategoryIDConverter(string categoryCode)
        {
            int id = _context.Category.Where(x => x.Code.Contains(categoryCode))
                                           .Select(x => x.ID).FirstOrDefault();

            return id;
        }

        public string? CategoryIDConverterIntoDTO(int categoryId)
        {
            string? categoryCode = _context.Category.Where(x => x.ID == categoryId)
                                           .Select(x => x.Code).FirstOrDefault();

            return categoryCode;
        }

        public DateTime DateConverter(string dateTime)
        {

            DateTime datetime;
            bool isValid = DateTime.TryParse(dateTime, out datetime);

            if (isValid)
            {
                return datetime;
            }
            else
            {
                return DateTime.Now;
            }
        }

        public string? DateConverterIntoDTO(DateTime date)
        {
            string? dateString = date.ToString();

            return dateString;
        }
    }
}
