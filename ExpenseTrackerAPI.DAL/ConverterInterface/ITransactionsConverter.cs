using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAPI.DAL.ConverterInterface
{
    public interface ITransactionsConverter
    {
        int UserIDConverter(string userName);

        string? UserIDConverterIntoDTO(int userId);

        int StatusIDConverter(string statusCode);

        string? StatusIDConverterIntoDTO(int statusId);

        int CategoryIDConverter(string categoryCode);

        string? CategoryIDConverterIntoDTO(int categoryId);

        DateTime DateConverter(string DateTime);

        public string? DateConverterIntoDTO(DateTime date);
    }
}
