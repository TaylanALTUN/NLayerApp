using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDto<T>
    {
        public T Data{ get; set; }
        
        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<String> Errors { get; set; }


        //Static factory design patern. Nesne oluştyurmayı clientlardan almak amacı ile yapıldı. Nesne oluşturma işlemini kontrol altına alınıyor
        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode};
        }

        //Static factory design patern
        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> {StatusCode = statusCode};
        }

        //Static factory design patern
        public static CustomResponseDto<T> Fail(int statusCode, List<String> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors};
        }

        //Static factory design patern
        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<String> { error } };
        }
    }
}
