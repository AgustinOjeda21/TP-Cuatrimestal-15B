using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;


    public class Result<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Value { get; set; }

        public Result(bool success, string message, T value)
        {
            Success = success;
            Message = message;
            Value = value;
            
        }

        public static Result<T> EjecucionCorrecta()
        {
            return new Result<T>(true, "Ejecucion correcta", default);
        }
        public static Result<T> Ok(T value)
        {
            return new Result<T>(true, "", value);
        }

        public static Result<T> Fail(string message)
        {
            return new Result<T>(false,message, default);
        }
    }

