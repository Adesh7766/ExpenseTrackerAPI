using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAPI.Entity.DTO
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string FullName { get; set; } = string.Empty;        
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
