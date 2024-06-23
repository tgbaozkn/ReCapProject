using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(bool success, string exp) : this(success)
        {

            Message = exp;
        }
        public Result(bool success)
        {
            Succeeded = success;
        }
        public bool Succeeded { get; }

        public string Message { get; }
    }
}
