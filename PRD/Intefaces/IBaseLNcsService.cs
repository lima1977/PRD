using PRD.Model;

namespace PRD.Intefaces
{
    public interface IBaseLNcsService
    {
        Task<bool> AdicionarLoteAsync(List<BaseLNcs> produtos);
        Task<List<BaseLNcs>> ObterTodosAsync();


       
    }
}
