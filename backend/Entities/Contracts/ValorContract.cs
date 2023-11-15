using Flunt.Validations;

namespace CrudLancamentos.Entities.Contracts;

public class ValorContract : Contract<Lancamento>
{
    public ValorContract(Lancamento lancamento)
    {
        Requires()
            .IsNotBetween(lancamento.Valor, 0, 0, "Valor", "Valor não pode ser zero");
    }
}