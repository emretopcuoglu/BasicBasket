using System;
using System.Collections.Generic;
using System.Text;

namespace ContactReport.Core
{
    public class ApiResult<T> : ApiResult
    {
        public ApiResult()
        {
        }

        public ApiResult(string message, bool success, int statusCode)
            : base(message, success, statusCode)
        {
        }

        public ApiResult(string message, bool success, int statusCode, T data)
            : base(message, success, statusCode)
        {
            Data = data;
        }

        public T Data { get; set; }
    }

    public class ApiResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public ApiResult()
        {
        }

        public ApiResult(string message, bool success, int statusCode)
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
        }
    }
}
