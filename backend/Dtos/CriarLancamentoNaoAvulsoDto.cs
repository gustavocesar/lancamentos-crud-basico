namespace CrudLancamentos.Dtos;

public class CriarLancamentoNaoAvulsoDto : DtoBase
{
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
}
