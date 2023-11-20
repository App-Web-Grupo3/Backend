namespace Domain;

public class ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public string ErrorMessage { get; set; }

    public static ApiResponse<T> Success(T data)
    {
        return new ApiResponse<T> { IsSuccess = true, Data = data };
    }

    public static ApiResponse<T> Error(string errorMessage)
    {
        return new ApiResponse<T> { IsSuccess = false, ErrorMessage = errorMessage };
    }
}