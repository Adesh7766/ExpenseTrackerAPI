using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerAPI.Entity.Common;
using ExpenseTrackerAPI.Entity.DTO;

namespace ExpenseTrackerAPI.BAL.Interface
{
    public interface IStatusService
    {
        ResponseData Save(StatusDTO vm);
        ResponseData Delete(int id);
        ResponseData<StatusDTO> GetById(int id);
        ResponseData<List<StatusDTO>> GetList(string name, string code);
    }
}
