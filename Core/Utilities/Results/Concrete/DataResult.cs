using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {

        public T Data { get; set; }
        public DataResult(T data, bool success, string message) : base(success, message)
        {

        }
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
    
    }
}
