using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerAPI.Entity.Common;
using ExpenseTrackerAPI.Entity.Models;

namespace ExpenseTrackerAPI.DAL.Interface
{
    public interface IStatusRepo
    {
        ResponseData Save(Status vm);
        ResponseData Update(Status vm);
        ResponseData Delete(int id);
        ResponseData<Status> GetById(int id);
        ResponseData<List<Status>> GetAllList(string name, string code);
    }
}
