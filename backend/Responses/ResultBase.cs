namespace CrudLancamentos.Responses;

public abstract class ResultBase
{
    public ResultBase(bool success, string message, object data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public bool Success { get; protected set; }
    public string Message { get; protected set; }
    public object Data { get; protected set; }
}