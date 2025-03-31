using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAPI.Entity.Models
{
    public class Transaction
    {
        [Key]
        public int ID { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int StatusId { get; set; }

        public string Description { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Statuses { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
