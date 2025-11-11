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

        //public async Task<List<BaseLNcs>> ObterTodosAsync()
        //{
        //    try
        //    {
        //        return await _context.BaseRec.ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Erro ao obter todos os BaseLNcs");
        //        throw new Exception("Erro ao obter todos os BaseLNcs: " + ex.Message);
        //    }
        //}

        public async Task<BaseLNcs?> ObterPorIdAsync(int id)
        {
            try
            {
                return await _context.BaseRec.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter BaseLNcs por ID: {Id}", id);
                throw new Exception($"Erro ao obter BaseLNcs ID {id}: " + ex.Message);
            }
        }

        public async Task<bool> AdicionarLoteAsync1(List<BaseLNcs> produtos)
        {
            try
            {
                await _context.BaseRec.AddRangeAsync(produtos);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar lote de BaseLNcs");
                throw new Exception("Erro ao adicionar lote: " + ex.Message);
            }
        }

        public async Task<bool> AtualizarAsync(BaseLNcs registro)
        {
            try
            {
                var existente = await _context.BaseRec.FindAsync(registro.Id);
                if (existente == null)
                {
                    _logger.LogWarning("Registro ID {Id} não encontrado para atualização", registro.Id);
                    return false;
                }

                // Atualizar apenas os campos que podem ser modificados
                existente.QtdRecebida = registro.QtdRecebida;
                existente.Status = registro.Status;
                existente.Senha = registro.Senha;
                existente.StatusSenha = registro.StatusSenha;
                existente.DataLancamento = registro.DataLancamento;
                existente.HoraLancamento = registro.HoraLancamento;
                existente.DataEnvioBOSS = registro.DataEnvioBOSS;
                existente.HoraEnvioBOSS = registro.HoraEnvioBOSS;
                existente.DataChamada = registro.DataChamada;
                existente.HoraChamada = registro.HoraChamada;
                existente.DataAprovacao = registro.DataAprovacao;
                existente.HoraAprovacao = registro.HoraAprovacao;
                existente.PlacaVeiculo = registro.PlacaVeiculo;

                _context.BaseRec.Update(existente);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Registro ID {Id} atualizado com sucesso", registro.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar BaseLNcs ID: {Id}", registro.Id);
                throw new Exception($"Erro ao atualizar registro ID {registro.Id}: " + ex.Message);
            }

        }

        public async Task<bool> DeletarAsync(int id)
        {
            try
            {
                var registro = await _context.BaseRec.FindAsync(id);
                if (registro == null)
                {
                    _logger.LogWarning("Registro ID {Id} não encontrado para exclusão", id);
                    return false;
                }

                _context.BaseRec.Remove(registro);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Registro ID {Id} deletado com sucesso", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar BaseLNcs ID: {Id}", id);
                throw new Exception($"Erro ao deletar registro ID {id}: " + ex.Message);
            }
        }

        public async Task<List<BaseLNcs>> ObterTodosAsync(int page, int pageSize)
        {
            try
            {
                return await _context.BaseRec
                                     .Skip(page * pageSize)  // Pula os itens carregados
                                     .Take(pageSize)         // Limita o número de registros
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter todos os BaseLNcs");
                throw new Exception("Erro ao obter todos os BaseLNcs: " + ex.Message);
            }
        }

    }




}
