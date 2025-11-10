using PRD.Model;

namespace PRD.Intefaces
{
    public interface IProdutoService
    {
        Task<bool> AdicionarLoteAsync(List<BaseLNcs> produtos);
        Task<List<BaseLNcs>> ObterTodosAsync();


        Task DeletarEInserirComTransacaoAsync(List<BaseLNcs> produtos); // ⭐ MÉTODO PRINCIPAL
    }
}