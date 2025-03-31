using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerAPI.DAL.Interface;
using ExpenseTrackerAPI.Entity.Common;
using ExpenseTrackerAPI.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.DAL.Repository
{
    public class UsersRepo : IUsersRepo
    {
        private readonly ApplicationDbContext _context;

        public UsersRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResponseData Save(User vm)
        {
            _context.Add(vm);
            _context.SaveChanges();
            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Data Saved Successfully"
            };
        }

        public ResponseData Update(User user)
        {
            _context.SaveChanges();
            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Data Updated Successfully"
            };
        }

        public ResponseData Delete(int id)
        {
            var data = _context.Users
                        .Where(x => x.ID == id && x.IsActive == true)
                        .FirstOrDefault();

            if (data == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "User not found."
                };
            }
            else
            {
                data.IsActive = false;
                _context.SaveChanges();
                return new ResponseData
                {
                    SuccessStatus = true,
                    Message = "User deleted successfully."
                };
            }
        }

        public ResponseData<User> GetById(int id)
        {
            var data = _context.Users
                        .Where(xyz => xyz.IsActive == true
                                && xyz.ID == id)
                        .FirstOrDefault();

            return new ResponseData<User>
            {
                SuccessStatus = true,
                Data = data
            };
        }

        public ResponseData<List<User>> GetAllList(string name)
        {
            var data = _context.Users
                        .Where(x => x.IsActive == true
                            && (string.IsNullOrEmpty(name) || x.FullName.Contains(name))
                        )
                        .ToList();

            return new ResponseData<List<User>>
            {
                SuccessStatus = true,
                Data = data
            };
        }
    }
}
