namespace CrudLancamentos.Dtos;

public class CriarLancamentoAvulsoDto : DtoBase
{
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
}
