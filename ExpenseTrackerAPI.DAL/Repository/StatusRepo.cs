using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerAPI.DAL.Interface;
using ExpenseTrackerAPI.Entity.Common;
using ExpenseTrackerAPI.Entity.Models;

namespace ExpenseTrackerAPI.DAL.Repository
{
    public class StatusRepo : IStatusRepo
    {
        private readonly ApplicationDbContext _context;

        public StatusRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResponseData Save(Status vm)
        {
            _context.Add(vm);
            _context.SaveChanges();
            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Status Saved Successfully"
            };
        }

        public ResponseData Update(Status status)
        {
            _context.SaveChanges();
            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Status Updated Successfully"
            };
        }

        public ResponseData Delete(int id)
        {
            var data = _context.Statuses
                        .Where(x => x.ID == id && x.IsActive == true)
                        .FirstOrDefault();

            if (data == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Status not found."
                };
            }
            else
            {
                data.IsActive = false;
                _context.SaveChanges();
                return new ResponseData
                {
                    SuccessStatus = true,
                    Message = "Status deleted successfully."
                };
            }
        }

        public ResponseData<Status> GetById(int id)
        {
            var data = _context.Statuses
                        .Where(xyz => xyz.IsActive == true
                                && xyz.ID == id)
                        .FirstOrDefault();

            return new ResponseData<Status>
            {
                SuccessStatus = true,
                Data = data
            };
        }

        public ResponseData<List<Status>> GetAllList(string name, string code)
        {
            var data = _context.Statuses
                        .Where(x => x.IsActive == true
                            && (string.IsNullOrEmpty(name) || x.Name.Contains(name))
                            && (string.IsNullOrEmpty(code) || x.Code.Contains(name))
                        )
                        .ToList();

            return new ResponseData<List<Status>>
            {
                SuccessStatus = true,
                Data = data
            };
        }
    }
}
