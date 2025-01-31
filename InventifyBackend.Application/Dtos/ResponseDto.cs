namespace InventifyBackend.Application.Dtos
{
    public class ResponseDto<T>
    {
        private ResponseDto(int statusCode, T data, string message)
        {
            StatusCode = statusCode;
            Data = data;
            Message = message;
        }

        public int StatusCode { get; }

        public T Data { get; }

        public string Message { get; }

        public static ResponseDto<T> Success(T value) => new(200, value, null);

        public static ResponseDto<T> Failure(int statusCode, string error) => new(statusCode, default, error);
    }
}
