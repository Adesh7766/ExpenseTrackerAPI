using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAPI.Entity.DTO
{
    public class TransactionByCategoryDTO
    {
        public long AmountSpent { get; set; }

        public string Category { get; set; } = String.Empty;
    }
}
