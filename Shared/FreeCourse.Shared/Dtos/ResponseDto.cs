using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FreeCourse.Shared.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; private set; }

        [JsonIgnore]
        public int StatusCode { get; private set; }
        
        [JsonIgnore]
        public bool IsSuccess { get; private set; }

        public List<String> Errors { get; set; }

        public static ResponseDto<T> Success(T data, int StatusCode)
        {
            return new ResponseDto<T> { Data = data, StatusCode = StatusCode, IsSuccess = true };
        }

        public static ResponseDto<T> Success(int StatusCode)
        {
            return new ResponseDto<T> { StatusCode = StatusCode, IsSuccess = true };
        }

        public static ResponseDto<T> Fail(List<String> errors,int statusCode)
        {
            return new ResponseDto<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccess = false
            };
        }

        public static ResponseDto<T> Fail(String errors, int statusCode)
        {
            return new ResponseDto<T> { Errors = new List<String>() { errors },StatusCode= statusCode, IsSuccess = false  };
        }


    }
}
