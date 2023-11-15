using CrudLancamentos.Entities.Contracts;
using CrudLancamentos.Enums;

namespace CrudLancamentos.Entities;

public class Lancamento : EntityBase
{
    //Lançamento avulso
    public Lancamento(decimal valor, string descricao)
    {
        Valor = valor;
        Descricao = descricao;
        Avulso = true;
        Data = DateTime.Now;

        AddNotifications(new LancamentoContract(this));
    }

    //Lançamento não avulso
    public Lancamento(decimal valor, string descricao, DateTime data)
    {
        Valor = valor;
        Descricao = descricao;
        Avulso = false;
        Data = data;

        AddNotifications(new LancamentoContract(this));
    }

    public string Descricao { get; private set; } = string.Empty;
    public DateTime Data { get; private set; } = DateTime.Now;
    public decimal Valor { get; private set; }
    public bool Avulso { get; private set; }
    public StatusEnum Status { get; private set; } = StatusEnum.Valido;

    public void Cancelar() => Status = StatusEnum.Cancelado;

    public Lancamento AlterarValor(decimal novoValor)
    {
        Valor = novoValor;
        AddNotifications(new ValorContract(this));

        return this;
    }

    public Lancamento AlterarData(DateTime novaData)
    {
        Data = novaData;
        AddNotifications(new DataContract(this));

        return this;
    }
}