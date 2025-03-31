using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerAPI.Entity.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string FullName { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
