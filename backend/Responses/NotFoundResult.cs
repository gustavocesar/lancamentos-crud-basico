namespace CrudLancamentos.Responses;

public class NotFoundResult : ResultBase
{
    public NotFoundResult(object data) : base(false, "Lançamento não encontrado", data)
    {
    }
}