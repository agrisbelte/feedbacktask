using System.Net;

namespace Bdp.Core.Models;

public class OperationResult<T>
{
    public bool IsSuccess { get; private set; } = true;
    public T Data { get; set; }
    public int TotalCount { get; set; }
    public string Error { get; private set; }
    public HttpStatusCode StatusCode { get; private set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
    public Exception Exception { get; private set; }
    public void SetError(string errorMessage = "", HttpStatusCode responseStatusCode = HttpStatusCode.InternalServerError)
    {
        Error = string.IsNullOrWhiteSpace(errorMessage) ? "Oops, error occured." : errorMessage;
        StatusCode = responseStatusCode;
        IsSuccess = false;
    }

    public void SetError(Exception exception, HttpStatusCode responseStatusCode = HttpStatusCode.InternalServerError)
    {
        Error = exception.Message;
        Exception = exception;
        StatusCode = responseStatusCode;
        IsSuccess = false;
    }

    public OperationResult<T> SetSuccess(T data, HttpStatusCode responseStatusCode = HttpStatusCode.OK, string message = "")
    {
        if (IsSuccess)
        {
            Data = data;
            StatusCode = responseStatusCode;
            Message = message;
        }

        return this;
    }

    public OperationResult<T> WithNoData()
    {
        SetError("Not found.", HttpStatusCode.NoContent);
        return this;
    }

    public OperationResult<T> WithError(string error = "", HttpStatusCode responseStatusCode = HttpStatusCode.InternalServerError)
    {
        SetError(error, responseStatusCode);
        return this;
    }

    public OperationResult<T> WithNotAuthorisedError(HttpStatusCode responseStatusCode = HttpStatusCode.Forbidden)
    {
        return WithError("Not authorised.", responseStatusCode);
    }
}