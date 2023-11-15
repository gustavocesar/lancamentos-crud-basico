using Flunt.Validations;

namespace CrudLancamentos.Entities.Contracts;

public class LancamentoContract : Contract<Lancamento>
{
    public LancamentoContract(Lancamento lancamento)
    {
        Requires()
            .IsNotNullOrEmpty(lancamento.Descricao, "Descrição", "Descrição não pode ser vazia")
            .Join(
                new DataContract(lancamento),
                new ValorContract(lancamento)
            );
    }
}