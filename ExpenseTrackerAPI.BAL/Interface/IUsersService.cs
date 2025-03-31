using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerAPI.Entity.Common;
using ExpenseTrackerAPI.Entity.DTO;

namespace ExpenseTrackerAPI.BAL.Interface
{
    public interface IUserService
    {
        ResponseData Save(UserDTO vm);
        ResponseData Delete(int id);
        ResponseData<UserDTO> GetById(int id);
        ResponseData<List<UserDTO>> GetList(string name);
    }
}
