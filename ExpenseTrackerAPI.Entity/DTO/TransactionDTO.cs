using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAPI.Entity.DTO
{
    public class TransactionDTO
    {
        public int ID { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public string CreatedDate { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;
    }
}
