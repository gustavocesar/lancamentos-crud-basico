using Flunt.Validations;

namespace CrudLancamentos.Entities.Contracts;

public class DataContract : Contract<Lancamento>
{
    public DataContract(Lancamento lancamento)
    {
        Requires()
            .IsNotNullOrEmpty(lancamento.Data.ToString(), "Data", "Data não pode ser vazia");
    }
}