namespace CrudLancamentos.Dtos;

public class AlterarLancamentoAvulsoDto : DtoBase
{
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
}
