using CrudLancamentos.Dtos;
using CrudLancamentos.Responses;

namespace CrudLancamentos.Services;

public interface ILancamentoService
{
    Task<ResultBase> Create(CriarLancamentoAvulsoDto lancamentoDto);
    Task<ResultBase> Create(CriarLancamentoNaoAvulsoDto lancamentoDto);
    Task<ResultBase> Retrieve(FiltroLancamentoDto filtro);
    Task<ResultBase> Retrieve(Guid id);
    Task<ResultBase> Update(Guid id, AlterarLancamentoAvulsoDto lancamentoDto);
    Task<ResultBase> Delete(Guid id);
}