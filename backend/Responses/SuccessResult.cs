namespace CrudLancamentos.Responses;

public class SuccessResult : ResultBase
{
    public SuccessResult(object data) : base(true, "Operação realizada com sucesso", data)
    {
    }
}