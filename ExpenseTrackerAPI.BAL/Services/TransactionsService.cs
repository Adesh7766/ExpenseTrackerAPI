using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerAPI.BAL.Interface;
using ExpenseTrackerAPI.DAL;
using ExpenseTrackerAPI.DAL.Converter;
using ExpenseTrackerAPI.DAL.ConverterInterface;
using ExpenseTrackerAPI.DAL.Interface;
using ExpenseTrackerAPI.Entity.Common;
using ExpenseTrackerAPI.Entity.DTO;
using ExpenseTrackerAPI.Entity.Models;

namespace ExpenseTrackerAPI.BAL.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepo _repo;
        private readonly ITransactionsConverter _converter;

        public TransactionsService(ITransactionsRepo repo, ITransactionsConverter converter)
        {
            _repo = repo;
            _converter = converter; 
        }

        public ResponseData Save(TransactionDTO vm)
        {
            if (vm.ID != 0)
            {
                var oldData = _repo.GetById(vm.ID);

                oldData.Data.UserId = _converter.UserIDConverter(vm.CreatedBy);
                oldData.Data.CreatedDate = _converter.DateConverter(vm.CreatedDate).Date;
                oldData.Data.StatusId = _converter.StatusIDConverter(vm.Status);
                oldData.Data.Description = vm.Description;
                oldData.Data.Amount = vm.Amount;
                oldData.Data.CategoryId = _converter.CategoryIDConverter(vm.Category);
                oldData.Data.IsActive = true;

                return _repo.Update(oldData.Data);
            }
            else
            {
                Transaction ci = new Transaction()
                {
                    ID = vm.ID,
                    UserId = _converter.UserIDConverter(vm.CreatedBy),
                    CreatedDate = DateTime.Now.Date,
                    StatusId = _converter.StatusIDConverter(vm.Status),
                    Description = vm.Description,
                    Amount = vm.Amount,
                    CategoryId = _converter.CategoryIDConverter(vm.Category),
                    IsActive = true
                };

                return _repo.Save(ci);
            }
        }

        public ResponseData Delete(int id)
        {
            var response = _repo.Delete(id);

            return response;
        }

        public ResponseData<TransactionDTO> GetById(int id)
        {
            var data = _repo.GetById(id);

            if(data.Data == null)
            {
                return new ResponseData<TransactionDTO>
                {
                    SuccessStatus = false,
                    Message = "Transaction not found"
                };
            }
            else
            {
                var vm = new TransactionDTO()
                {
                    ID = data.Data.ID,
                    CreatedBy = _converter.UserIDConverterIntoDTO(data.Data.UserId),
                    CreatedDate = _converter.DateConverterIntoDTO(data.Data.CreatedDate),
                    Status = _converter.StatusIDConverterIntoDTO(data.Data.StatusId),
                    Description = data.Data.Description,
                    Amount = data.Data.Amount,
                    Category = _converter.CategoryIDConverterIntoDTO(data.Data.CategoryId),
                    IsActive = data.Data.IsActive
                };

                return new ResponseData<TransactionDTO>
                {
                    SuccessStatus = true,
                    Data = vm
                };
            }

        }

        public ResponseData<List<TransactionDTO>> GetList(string user, string statusCode, string categoryCode)
        {
            var data = _repo.GetAllList(user, statusCode, categoryCode);
            var vm = data.Data.Select(abc => new TransactionDTO
            {
                ID = abc.ID,
                CreatedBy = _converter.UserIDConverterIntoDTO(abc.UserId),
                CreatedDate = _converter.DateConverterIntoDTO(abc.CreatedDate),
                Status = _converter.StatusIDConverterIntoDTO(abc.StatusId),
                Description = abc.Description,
                Amount = abc.Amount,
                Category = _converter.CategoryIDConverterIntoDTO(abc.CategoryId),
                IsActive = abc.IsActive
            })
            .ToList();


            return new ResponseData<List<TransactionDTO>>
            {
                SuccessStatus = true,
                Data = vm
            };
        }
    }
}
