namespace BlogBackend.Services
{
    public class Result
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        protected Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public static Result Ok(string message = "İşlem başarılı") => new Result(true, message);

        public static Result Fail(string message) => new Result(false, message);
    }

    public class Result<T> : Result
    {
        public T Data { get; private set; }

        private Result(bool success, string message, T data)
            : base(success, message)
        {
            Data = data;
        }

        public static Result<T> Ok(T data, string message = "İşlem başarılı") => new Result<T>(true, message, data);

        public static Result<T> Fail(string message) => new Result<T>(false, message, default);
    }
}
