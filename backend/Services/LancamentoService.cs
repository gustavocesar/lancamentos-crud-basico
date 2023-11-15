using CrudLancamentos.Dtos;
using CrudLancamentos.Entities;
using CrudLancamentos.Responses;
using Microsoft.EntityFrameworkCore;

namespace CrudLancamentos.Services;

public class LancamentoService : ILancamentoService
{
    private readonly Context _context;

    public LancamentoService(Context context)
    {
        _context = context;
    }

    public async Task<ResultBase> Create(CriarLancamentoAvulsoDto lancamentoDto)
    {
        var lancamento = new Lancamento(lancamentoDto.Valor, lancamentoDto.Descricao);
        if (!lancamento.IsValid)
            return new InvalidResult(lancamento.Notifications);

        var novoLancamento = await Insert(lancamento);
        return new SuccessResult(novoLancamento);
    }

    public async Task<ResultBase> Create(CriarLancamentoNaoAvulsoDto lancamentoDto)
    {
        var lancamento = new Lancamento(lancamentoDto.Valor, lancamentoDto.Descricao, lancamentoDto.Data);
        if (!lancamento.IsValid)
            return new InvalidResult(lancamento.Notifications);

        var novoLancamento = await Insert(lancamento);
        return new SuccessResult(novoLancamento);
    }

    public async Task<ResultBase> Retrieve(FiltroLancamentoDto filtro)
    {
        var query = _context.Lancamentos
            .AsNoTracking()
            .AsQueryable();

        if (filtro.DataInicial != DateTime.MinValue)
            query = query.Where(l => l.Data.Date >= filtro.DataInicial.Date);

        if (filtro.DataFinal != DateTime.MinValue)
            query = query.Where(l => l.Data.Date <= filtro.DataFinal.Date);

        var lancamentos = await query.ToListAsync();

        return new SuccessResult(lancamentos);
    }

    public async Task<ResultBase> Retrieve(Guid id)
    {
        var lancamento = await FindLancamento(id);

        if (lancamento is null)
            return new NotFoundResult(lancamento!);

        return new SuccessResult(lancamento);
    }

    public async Task<ResultBase> Update(Guid id, AlterarLancamentoAvulsoDto lancamentoDto)
    {
        var lancamento = await FindLancamento(id);

        if (lancamento is null)
            return new NotFoundResult(lancamento!);

        lancamento.AlterarValor(lancamentoDto.Valor)
            .AlterarData(lancamentoDto.Data);

        if (!lancamento.IsValid)
            return new InvalidResult(lancamento.Notifications);

        var novoLancamento = await Update(lancamento);
        return new SuccessResult(novoLancamento);
    }

    public async Task<ResultBase> Delete(Guid id)
    {
        var lancamento = await FindLancamento(id);

        if (lancamento is null)
            return new NotFoundResult(lancamento!);

        lancamento.Cancelar();

        var novoLancamento = await Update(lancamento);
        return new SuccessResult(novoLancamento);
    }

    private async Task<Lancamento> FindLancamento(Guid id)
    {
        var lancamento = await _context.Lancamentos
            .FirstOrDefaultAsync(l => l.Id == id);

        return lancamento!;
    }

    private async Task<Lancamento> Insert(Lancamento lancamento)
    {
        var novoLancamento = await _context.Lancamentos.AddAsync(lancamento);
        await _context.SaveChangesAsync();

        return novoLancamento!.Entity;
    }

    private async Task<Lancamento> Update(Lancamento lancamento)
    {
        var novoLancamento = _context.Lancamentos.Update(lancamento);
        await _context.SaveChangesAsync();

        return novoLancamento!.Entity;
    }
}