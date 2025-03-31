using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerAPI.Entity.Common;
using ExpenseTrackerAPI.Entity.DTO;

namespace ExpenseTrackerAPI.BAL.Interface
{
    public interface ICategoryService
    {
        ResponseData Save(CategoryDTO vm);
        ResponseData Delete(int id);
        ResponseData<CategoryDTO> GetById(int id);
        ResponseData<List<CategoryDTO>> GetList(string name, string code);
    }
}
