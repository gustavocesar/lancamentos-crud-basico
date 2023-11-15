using CrudLancamentos.Entities;
using CrudLancamentos.Enums;

namespace CrudLancamentosTests.Entities;

public class LancamentoTest
{
    [Fact]
    public void DeveCriarLancamentoAvulsoValido()
    {
        var lancamento1 = new Lancamento(500, "Teste");
        Assert.True(lancamento1.IsValid);
        
        var lancamento2 = new Lancamento(-50, "Teste");
        Assert.True(lancamento2.IsValid);
    }

    [Fact]
    public void DeveCriarLancamentoNaoAvulsoValido()
    {
        var lancamento1 = new Lancamento(500, "Teste", DateTime.Now);
        Assert.True(lancamento1.IsValid);

        var lancamento2 = new Lancamento(-50, "Teste", DateTime.Now);
        Assert.True(lancamento2.IsValid);
    }

    [Fact]
    public void DeveAlterarValorLancamentoAvulsoValido()
    {
        var lancamento = new Lancamento(500, "Teste");
        lancamento.AlterarValor(1000);

        Assert.Equal(1000, lancamento.Valor);
        Assert.True(lancamento.IsValid);
    }

    [Fact]
    public void DeveAlterarDataLancamentoNaoAvulsoValido()
    {
        var lancamento = new Lancamento(500, "Teste", DateTime.Now.AddDays(-1));
        var hoje = DateTime.Now;
        lancamento.AlterarData(hoje);

        Assert.Equal(hoje, lancamento.Data);
        Assert.True(lancamento.IsValid);
    }

    [Fact]
    public void NaoDeveCriarLancamentoAvulsoInvalido()
    {
        var lancamento = new Lancamento(0, "");
        Assert.False(lancamento.IsValid);
    }

    [Fact]
    public void DeveCancelarLancamentoAvulso()
    {
        var lancamento = new Lancamento(50, "Teste");
        lancamento.Cancelar();

        Assert.Equal(StatusEnum.Cancelado, lancamento.Status);
        Assert.True(lancamento.IsValid);
    }
}