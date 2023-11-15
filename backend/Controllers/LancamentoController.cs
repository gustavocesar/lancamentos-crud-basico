using CrudLancamentos.Dtos;
using CrudLancamentos.Entities;
using CrudLancamentos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudLancamentos.Controllers;

[Route("api/lancamentos")]
public class LancamentoController : BaseController
{
    private readonly ILancamentoService _lancamentoService;

    public LancamentoController(ILancamentoService lancamentoService)
    {
        _lancamentoService = lancamentoService;
    }

    [HttpPost]
    public async Task<ActionResult<Lancamento>> Create([FromBody] CriarLancamentoAvulsoDto lancamentoDto)
    {
        var lancamento = await _lancamentoService.Create(lancamentoDto);
        return CustomResponse(lancamento);
    }

    [HttpPost("nao-avulso")]
    public async Task<ActionResult<Lancamento>> Create([FromBody] CriarLancamentoNaoAvulsoDto lancamentoDto)
    {
        var lancamento = await _lancamentoService.Create(lancamentoDto);
        return CustomResponse(lancamento);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Lancamento>>> Retrieve([FromQuery] FiltroLancamentoDto filtro)
    {
        return CustomResponse(await _lancamentoService.Retrieve(filtro));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Lancamento>> Retrieve(Guid id)
    {
        var lancamento = await _lancamentoService.Retrieve(id);
        return CustomResponse(lancamento);
    }

    
    [HttpPut("{id}")]
    public async Task<ActionResult<Lancamento>> Update(Guid id, [FromBody] AlterarLancamentoAvulsoDto lancamentoDto)
    {
        var lancamento = await _lancamentoService.Update(id, lancamentoDto);
        return CustomResponse(lancamento);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Lancamento>> Delete(Guid id)
    {
        return CustomResponse(await _lancamentoService.Delete(id));
    }
}
