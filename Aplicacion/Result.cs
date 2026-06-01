using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace Aplicacion
{
    public static class Result<T>
    {
        public static bool Success { get; set; }
        public static string Message { get; set; }
        public static T Value { get; set; }

        public Result<T>(bool success, string message, T value)
        {
            Success = Success;
            Message = Message;
            Value = Value;
        }

        public static void EjecucionCorrecta(this Result<T> result)
        {
            result.Success = true;
            Message = "Ejecucion Correcta";
            Value = default;
            return result
        }
        public static void Ok(T value)
        {
            Success = true;
            Message = "";
            Value = value;
        }

        public static void Fail(string message)
        {
            Success = false;
            Message = message;
            Value = default;
        }
    }
}
