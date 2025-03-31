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
    public class StatusService : IStatusService
    {
        private readonly IStatusRepo _repo;

        public StatusService(IStatusRepo repo)
        {
            _repo = repo;
        }

        public ResponseData Save(StatusDTO vm)
        {
            if (vm.ID != 0)
            {
                var oldData = _repo.GetById(vm.ID);

                oldData.Data.Name = vm.Name;
                oldData.Data.Code = vm.Code;
                oldData.Data.Description = vm.Description;
                oldData.Data.IsActive = true;


                return _repo.Update(oldData.Data);
            }
            else
            {
                Status ci = new Status()
                {
                    ID = vm.ID,
                    Name = vm.Name,
                    Code = vm.Code,
                    IsActive = true,
                    Description = vm.Description
                };


                return _repo.Save(ci);
            }
        }

        public ResponseData Delete(int id)
        {
            var response = _repo.Delete(id);

            return response;
        }

        public ResponseData<StatusDTO> GetById(int id)
        {
            var data = _repo.GetById(id);

            if (data.Data == null)
            {
                return new ResponseData<StatusDTO>
                {
                    SuccessStatus = false,
                    Message = "Status not found"
                };
            }
            else
            {
                var vm = new StatusDTO
                {
                    ID = data.Data.ID,
                    Name = data.Data.Name,
                    Code = data.Data.Code,
                    IsActive = data.Data.IsActive,
                    Description = data.Data.Description
                };

                return new ResponseData<StatusDTO>
                {
                    SuccessStatus = true,
                    Data = vm
                };
            }


        }

        public ResponseData<List<StatusDTO>> GetList(string name, string code)
        {
            var data = _repo.GetAllList(name, code);
            var vm = data.Data.Select(abc => new StatusDTO
            {
                ID = abc.ID,
                Name = abc.Name,
                Code = abc.Code,
                IsActive = abc.IsActive,
                Description = abc.Description
            })
            .ToList();


            return new ResponseData<List<StatusDTO>>
            {
                SuccessStatus = true,
                Data = vm
            };
        }
    }
}
