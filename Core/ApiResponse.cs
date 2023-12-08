namespace Core
{
    public class ApiResponse<T> where T : class
    {
        private const string DEFAULT_ERR_MESSAGE = "ERROR!";

        private readonly ApiResult result;
        private readonly string? errorMessage;
        private readonly T data;

        public ApiResult Result => result;
        public string? ErrorMessage => errorMessage;
        public T Data => data;

        public bool IsSuccess => result == ApiResult.Success;

        private ApiResponse(ApiResult result, T data, string? errorMessage = null)
        {
            if (result == ApiResult.Success)
            {
                if (!string.IsNullOrEmpty(errorMessage))
                    throw new InvalidOperationException("Message cannot exist for successful result");

                if (data == null)
                    throw new InvalidOperationException("Data cannot be null for successful result");
            }
            else
            {
                if (string.IsNullOrEmpty(errorMessage))
                    throw new InvalidOperationException("Message cannot be empty for unsuccessful result");
            }

            this.result = result;
            this.data = data;
            this.errorMessage = errorMessage;
        }

        public static ApiResponse<T> OfSuccess(T data)
        {
            return new ApiResponse<T>(ApiResult.Success, data);
        }

        public static ApiResponse<T> OfFail(ApiResult code, string message)
        {
            return new ApiResponse<T>(code, null, string.IsNullOrWhiteSpace(message) ? DEFAULT_ERR_MESSAGE : message);
        }
    }
}
