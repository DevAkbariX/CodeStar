using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Application.Common
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new();
        public T Data { get; set; }

       
        public static Result<T> SuccessResult(string message = "")
        {
            return new Result<T> { Success = true, Message = message };
        }

       
        public static Result<T> SuccessResult(T data, string message = "")
        {
            return new Result<T> { Success = true, Data = data, Message = message };
        }

     
        public static Result<T> FailureResult(string message, List<string>? errors = null)
        {
            return new Result<T> { Success = false, Message = message, Errors = errors ?? new() };
        }
    }
}
