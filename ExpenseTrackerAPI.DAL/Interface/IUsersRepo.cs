using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerAPI.Entity.Common;
using ExpenseTrackerAPI.Entity.DTO;
using ExpenseTrackerAPI.Entity.Models;

namespace ExpenseTrackerAPI.DAL.Interface
{
    public interface IUsersRepo
    {
        ResponseData Save(User vm);
        ResponseData Update(User vm);
        ResponseData Delete(int id);
        ResponseData<User> GetById(int id);
        ResponseData<List<User>> GetAllList(string name);
    }
}
