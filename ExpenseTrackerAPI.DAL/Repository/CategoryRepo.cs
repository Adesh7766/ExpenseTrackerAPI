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
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResponseData Save(Category vm)
        {
            _context.Add(vm);
            _context.SaveChanges();
            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Category Saved Successfully"
            };
        }

        public ResponseData Update(Category category)
        {
            _context.SaveChanges();
            return new ResponseData
            {
                SuccessStatus = true,
                Message = "Category Updated Successfully"
            };
        }

        public ResponseData Delete(int id)
        {
            var data = _context.Category
                        .Where(x => x.ID == id && x.IsActive == true)
                        .FirstOrDefault();

            if (data == null)
            {
                return new ResponseData
                {
                    SuccessStatus = false,
                    Message = "Category not found."
                };
            }
            else
            {
                data.IsActive = false;
                _context.SaveChanges();
                return new ResponseData
                {
                    SuccessStatus = true,
                    Message = "Category deleted successfully."
                };
            }
        }

        public ResponseData<Category> GetById(int id)
        {
            var data = _context.Category
                        .Where(xyz => xyz.IsActive == true
                                && xyz.ID == id)
                        .FirstOrDefault();

            return new ResponseData<Category>
            {
                SuccessStatus = true,
                Data = data
            };
        }

        public ResponseData<List<Category>> GetAllList(string name, string code)
        {
            var data = _context.Category
                        .Where(x => x.IsActive == true
                            && (string.IsNullOrEmpty(name) || x.Name.Contains(name))
                            && (string.IsNullOrEmpty(code) || x.Code.Contains(name))
                        )
                        .ToList();

            return new ResponseData<List<Category>>
            {
                SuccessStatus = true,
                Data = data
            };
        }
    }
}
