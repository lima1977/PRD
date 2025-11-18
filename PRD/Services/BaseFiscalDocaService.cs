using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.EntityFrameworkCore;
using PRD.Data;
using PRD.Intefaces;
using PRD.Model;
namespace PRD.Services
{
   

        public class BaseFiscalDocaService : IBaseFiscalDocaService
        {
            private readonly DataContext _context;
            private readonly ILogger<BaseFiscalDocaService> _logger;

            public BaseFiscalDocaService(DataContext context, ILogger<BaseFiscalDocaService> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<bool> AdicionarFiscalDoca(BaseFiscalDoca fiscalDoca)
            {
                try
                {
                    fiscalDoca.Id = 0; // O Id será gerado automaticamente pelo banco de dados
                    _context.BaseFiscDoc.Add(fiscalDoca);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao adicionar BaseFiscalDoca");
                    throw new Exception("Erro ao adicionar BaseFiscalDoca", ex);
                }
            }

            public async Task<bool> AtualizarFiscalDocaAsync(BaseFiscalDoca fiscalDoca)
            {
                try
                {
                    _context.BaseFiscDoc.Update(fiscalDoca);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao atualizar BaseFiscalDoca");
                    throw new Exception("Erro ao atualizar BaseFiscalDoca", ex);
                }
            }
            public async Task<List<BaseFiscalDoca>> ObterFiscalAsync()
            {
                try
                {
                    return await _context.BaseFiscDoc.OrderByDescending(x => x.Id).ToListAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao obter BaseFiscalDoca");
                    throw new Exception("Erro ao obter BaseFiscalDoca", ex);
                }
            }
            public async Task<bool> AtualizarDocaAsync(BaseFiscalDoca registro)
            {
                try
                {
                    var existente = await _context.BaseFiscDoc.FindAsync(registro.Id);
                    if (existente == null)
                    {
                        _logger.LogWarning("Registro ID {Id} não encontrado para atualização", registro.Id);
                        return false;
                    }

                    // Atualizar os campos
                    existente.QtdRecebida = registro.QtdRecebida;
                    existente.Status = registro.Status;
                    existente.Senha = registro.Senha;
                    existente.StatusSenha = registro.StatusSenha;
                    // Outros campos para atualização

                    _context.BaseFiscDoc.Update(existente);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao atualizar BaseFiscalDoca");
                    throw new Exception("Erro ao atualizar BaseFiscalDoca", ex);
                }
            }
        }


    
}
