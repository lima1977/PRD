using Microsoft.EntityFrameworkCore;
using PRD.Data;
using PRD.Intefaces;
using PRD.Model;

namespace PRD.Services
{
    public class BaseLNcsService : IBaseLNcsService
    {
        private readonly DataContext _context;
        private ILogger<BaseLNcsService> _logger;

        public BaseLNcsService(DataContext context, ILogger<BaseLNcsService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AdicionarLoteAsync(List<BaseLNcs> linhas)
        {
            try
            {
                if (linhas is null || linhas.Count == 0)
                    return false;

                await _context.BaseRec.AddRangeAsync(linhas);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar lote de BaseLNcs");
                throw new Exception("Erro ao adicionar lote de BaseLNcs: " + ex.Message);
            }
        }

        public async Task<List<BaseLNcs>> ObterTodosAsync()
        {
            try
            {
                return await _context.BaseRec.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os BaseLNcs");
                throw new Exception("Erro ao obter todos os BaseLNcs: " + ex.Message);
            }
        }


    }




}
