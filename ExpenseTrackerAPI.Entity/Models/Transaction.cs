using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAPI.Entity.Models
{
    public class Transaction
    {
        [Key]
        public int ID { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Status { get; set; }

        public string Description { get; set; } = string.Empty;

        public int Category { get; set; }
    }
}
