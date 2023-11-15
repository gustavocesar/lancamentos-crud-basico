namespace CrudLancamentos.Responses;

public class InvalidResult : ResultBase
{
    public InvalidResult(object data) : base(false, "Lançamento inválido", data)
    {
    }
}