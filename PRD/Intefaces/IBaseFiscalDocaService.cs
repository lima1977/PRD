using PRD.Model;

namespace PRD.Intefaces
{
    public interface IBaseFiscalDocaService
    {

        Task<bool> AdicionarFiscalDoca(BaseFiscalDoca fiscalDoca);
        Task<bool> AtualizarFiscalDocaAsync(BaseFiscalDoca fiscalDoca);
        Task<List<BaseFiscalDoca>> ObterFiscalAsync();
        Task<bool> AtualizarDocaAsync(BaseFiscalDoca registro);

        //Task<bool> AtualizarDocaAsync(BaseFiscalDoca registro);
        //Task<bool> AdicionarFiscalDoca(BaseFiscalDoca BsFiscal);

    }
}
