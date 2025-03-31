using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerAPI.BAL.Interface;
using ExpenseTrackerAPI.DAL.Interface;
using ExpenseTrackerAPI.Entity.Common;
using ExpenseTrackerAPI.Entity.DTO;
using ExpenseTrackerAPI.Entity.Models;

namespace ExpenseTrackerAPI.BAL.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepo _repo;

        public UserService(IUsersRepo repo)
        {
            _repo = repo;
        }

        public ResponseData Save(UserDTO vm)
        {          
            if (vm.ID != 0)
            {
                var oldData = _repo.GetById(vm.ID);

                oldData.Data.FullName = vm.FullName;
                oldData.Data.Email = vm.Email;
                oldData.Data.IsActive = true;


                return _repo.Update(oldData.Data);
            }
            else
            {
                User ci = new User()
                {
                    ID = vm.ID,
                    FullName = vm.FullName,
                    Email = vm.Email,
                    IsActive = true,
                    Password = vm.Password
                };


                return _repo.Save(ci);
            }
        }

        public ResponseData Delete(int id)
        {
            var response = _repo.Delete(id);

            return response;
        }

        public ResponseData<UserDTO> GetById(int id)
        {
            var data = _repo.GetById(id);

            if (data.Data == null)
            {
                return new ResponseData<UserDTO>
                {
                    SuccessStatus = false,
                    Message = "User not found"
                };
            }
            else
            {
                var vm = new UserDTO
                {
                    ID = data.Data.ID,
                    FullName = data.Data.FullName,
                    Email = data.Data.Email,
                    IsActive = data.Data.IsActive
                };

                return new ResponseData<UserDTO>
                {
                    SuccessStatus = true,
                    Data = vm
                };
            }
            

        }

        public ResponseData<List<UserDTO>> GetList(string name)
        {
            var data = _repo.GetAllList(name);
            var vm = data.Data.Select(abc => new UserDTO
            {
                ID = abc.ID,
                FullName = abc.FullName,
                Email = abc.Email,
                IsActive = abc.IsActive
            })
            .ToList();


            return new ResponseData<List<UserDTO>>
            {
                SuccessStatus = true,
                Data = vm
            };
        }

    }
}
