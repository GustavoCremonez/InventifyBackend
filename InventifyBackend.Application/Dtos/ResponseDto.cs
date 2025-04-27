using System.Text.Json;

namespace InventifyBackend.Application.Dtos
{
    public class ResponseDto<T>
    {
        private ResponseDto(int statusCode, T data, string message, string? trace)
        {
            StatusCode = statusCode;
            Data = data;
            Message = message;
            Trace = trace;
        }

        public int StatusCode { get; }

        public T Data { get; }

        public string Message { get; }

        public string? Trace { get; }

        public static ResponseDto<T> Success(T value) => new(200, value, null, null);

        public static ResponseDto<T> Failure(int statusCode, string error, string? trace = null) => new(statusCode, default, error, trace);

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
