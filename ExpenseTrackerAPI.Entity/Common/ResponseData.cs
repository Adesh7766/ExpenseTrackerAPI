using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerAPI.Entity.Common
{
    public class ResponseData<T>
    {
        public bool SuccessStatus { get; set; }

        public string Message { get; set; } = string.Empty;

        public T Data { get; set; } 
    }

    public class ResponseData
    {
        public bool SuccessStatus { get; set; }

        public string Message { get; set; } = string.Empty;

        public object Data { get; set; }
    }
}
