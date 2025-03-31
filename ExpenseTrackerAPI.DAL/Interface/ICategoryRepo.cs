using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerAPI.Entity.Common;
using ExpenseTrackerAPI.Entity.Models;

namespace ExpenseTrackerAPI.DAL.Interface
{
    public interface ICategoryRepo
    {
        ResponseData Save(Category vm);
        ResponseData Update(Category vm);
        ResponseData Delete(int id);
        ResponseData<Category> GetById(int id);
        ResponseData<List<Category>> GetAllList(string name, string code);
    }
}
