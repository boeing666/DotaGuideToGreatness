using DotaGuideToGreatness.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaGuideToGreatness.Domain
{
    public class Result<T>
    {
        public StatusCodes StatusCode { get; set; }
        public string Message { get; set; }
        public bool Succeed => StatusCode == StatusCodes.Success;
        public T Payload { get; set; }

        
        public static Result<T> Success(T data)
        {
            return new Result<T> { StatusCode = StatusCodes.Success, Payload = data };
        }

        public static Result<T> Failed(StatusCodes statusCode, string message)
        {
            return new Result<T> { StatusCode = statusCode, Message = message };
        }

        public static Result<T> Exception(Exception ex)
        {
            return new Result<T> { StatusCode = StatusCodes.ServerException, Message = ex.Message };
        }

        public static Result<T> Failed(StatusCodes statusCode)
        {
            return new Result<T> { StatusCode = statusCode, Message = statusCode.ToString() };
        }
    }

    public class Result
    {
        public StatusCodes StatusCode { get; set; }
        public string Message { get; set; }
        public bool Succeed => StatusCode == StatusCodes.Success;


        public static Result Success()
        {
            return new Result { StatusCode = StatusCodes.Success };
        }

        public static Result Failed(StatusCodes statusCode, string message)
        {
            return new Result { StatusCode = statusCode, Message = message };
        }

        public static Result Failed(StatusCodes statusCode)
        {
            return new Result { StatusCode = statusCode, Message = statusCode.ToString() };
        }
    }
}
