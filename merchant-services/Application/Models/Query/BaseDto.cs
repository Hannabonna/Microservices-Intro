using System;

namespace merchant_services.Application.Models.Query
{
    public abstract class BaseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class RequestData<T>
    {
        public Data<T> DataD { get; set; }
    }
    public class Data<T>
    {
        public T Attributes { get; set; }
    }  
}