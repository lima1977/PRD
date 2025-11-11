using PRD.Model;

namespace PRD.Intefaces
{
    public interface IBaseLNcsService
    {
        Task<bool> AdicionarLoteAsync(List<BaseLNcs> produtos);
        Task<List<BaseLNcs>> ObterTodosAsync();

        //----------------------------------

        Task<bool> AtualizarAsync(BaseLNcs registro);
        Task<bool> DeletarAsync(int id);


        Task<List<BaseLNcs>> ObterTodosAsync(int page, int pageSize);
    }
}
