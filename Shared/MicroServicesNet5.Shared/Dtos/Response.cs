using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroServicesNet5.Shared.Dtos
{
    public class Response<T>
    {
        public T Data { get; private set; }

        [JsonIgnore]
        public int Status { get; private set; }

        [JsonIgnore]
        public bool IsSuccess { get; private set; }

        public List<string> Errors { get; private set; }


        // Static Factory Methods
        public static Response<T> Success(T data, int status)
        {
            return new Response<T> { Data = data, Status = status, IsSuccess = true };
        }

        public static Response<T> Success(int status)
        {
            return new Response<T> { Data = default(T), Status = status, IsSuccess = true };
        }

        public static Response<T> Fail(List<string> errors, int status)
        {
            return new Response<T> { Errors = errors,Status = status, IsSuccess = false };
        }

        public static Response<T> Fail(string error, int status)
        {
            return new Response<T> { Errors = new List<string>() { error }, Status = status, IsSuccess = false };
        }
    }
}
