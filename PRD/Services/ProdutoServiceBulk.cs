using Microsoft.Data.SqlClient;
using PRD.Intefaces;
using PRD.Model;
using System.Data;

namespace PRD.Services
{


    public class ProdutoServiceBulk : IProdutoService
    {
        private readonly string _connectionString;

        public ProdutoServiceBulk(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("LocalConnection");
        }

        public async Task<bool> AdicionarLoteAsync(List<BaseLNcs> produtos)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var transaction = connection.BeginTransaction();

            try
            {
                // PASSO 1: Deleta todos os dados
                using (var deleteCommand = connection.CreateCommand())
                {
                    deleteCommand.Transaction = transaction;
                    deleteCommand.CommandText = "DELETE FROM BaseLN";
                    deleteCommand.CommandTimeout = 300;
                    await deleteCommand.ExecuteNonQueryAsync();
                }

                // PASSO 2: Converte a lista para DataTable
                var dataTable = ConvertToDataTable(produtos);

                // ✅ CORREÇÃO CRÍTICA: Adiciona a transaction no construtor
                using var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction);
                bulkCopy.DestinationTableName = "BaseLN";
                bulkCopy.BatchSize = 10000;
                bulkCopy.BulkCopyTimeout = 300;

                // Mapeia todas as colunas
                bulkCopy.ColumnMappings.Add("Armazem", "Armazem");
                bulkCopy.ColumnMappings.Add("Senha", "Senha");
                bulkCopy.ColumnMappings.Add("StatusSenha", "StatusSenha");
                bulkCopy.ColumnMappings.Add("BOSS", "BOSS");
                bulkCopy.ColumnMappings.Add("Fornecedor", "Fornecedor");
                bulkCopy.ColumnMappings.Add("RazaoSocial", "RazaoSocial");
                bulkCopy.ColumnMappings.Add("Doca", "Doca");
                bulkCopy.ColumnMappings.Add("DataAgenda", "DataAgenda");
                bulkCopy.ColumnMappings.Add("PlacaVeiculo", "PlacaVeiculo");
                bulkCopy.ColumnMappings.Add("DataChegada", "DataChegada");
                bulkCopy.ColumnMappings.Add("HoraChegada", "HoraChegada");
                bulkCopy.ColumnMappings.Add("DataLancamento", "DataLancamento");
                bulkCopy.ColumnMappings.Add("HoraLancamento", "HoraLancamento");
                bulkCopy.ColumnMappings.Add("DataEnvioBOSS", "DataEnvioBOSS");
                bulkCopy.ColumnMappings.Add("HoraEnvioBOSS", "HoraEnvioBOSS");
                bulkCopy.ColumnMappings.Add("DataChamada", "DataChamada");
                bulkCopy.ColumnMappings.Add("HoraChamada", "HoraChamada");
                bulkCopy.ColumnMappings.Add("DataAprovacao", "DataAprovacao");
                bulkCopy.ColumnMappings.Add("HoraAprovacao", "HoraAprovacao");
                bulkCopy.ColumnMappings.Add("Pedido", "Pedido");
                bulkCopy.ColumnMappings.Add("Linha", "Linha");
                bulkCopy.ColumnMappings.Add("CnpjPnExpedidor", "CnpjPnExpedidor");
                bulkCopy.ColumnMappings.Add("Companhia", "Companhia");
                bulkCopy.ColumnMappings.Add("ItemSKU", "ItemSKU");
                bulkCopy.ColumnMappings.Add("DescricaoItem", "DescricaoItem");
                bulkCopy.ColumnMappings.Add("ItemFornecedor", "ItemFornecedor");
                bulkCopy.ColumnMappings.Add("QtdAgendada", "QtdAgendada");
                bulkCopy.ColumnMappings.Add("QtdRecebida", "QtdRecebida");
                bulkCopy.ColumnMappings.Add("Preco", "Preco");
                bulkCopy.ColumnMappings.Add("NotaFiscal", "NotaFiscal");
                bulkCopy.ColumnMappings.Add("Serie", "Serie");
                bulkCopy.ColumnMappings.Add("Localizador", "Localizador");
                bulkCopy.ColumnMappings.Add("RemessaArmazem", "RemessaArmazem");
                bulkCopy.ColumnMappings.Add("RecFisico", "RecFisico");
                bulkCopy.ColumnMappings.Add("RecFiscal", "RecFiscal");
                bulkCopy.ColumnMappings.Add("CodigoEntrega", "CodigoEntrega");
                bulkCopy.ColumnMappings.Add("Transportadora", "Transportadora");
                bulkCopy.ColumnMappings.Add("SKUOnline", "SKUOnline");
                bulkCopy.ColumnMappings.Add("EanTributario", "EanTributario");
                bulkCopy.ColumnMappings.Add("Multicanalidade", "Multicanalidade");
                bulkCopy.ColumnMappings.Add("CategoriaPlano", "CategoriaPlano");
                bulkCopy.ColumnMappings.Add("Diretoria", "Diretoria");
                bulkCopy.ColumnMappings.Add("ProdutoXD", "ProdutoXD");
                bulkCopy.ColumnMappings.Add("ValorAgenda", "ValorAgenda");
                bulkCopy.ColumnMappings.Add("ValorComEstornoLN", "ValorComEstornoLN");
                bulkCopy.ColumnMappings.Add("ValorComEstornoBI", "ValorComEstornoBI");
                bulkCopy.ColumnMappings.Add("DataRecAgenda", "DataRecAgenda");
                bulkCopy.ColumnMappings.Add("HoraRecAgenda", "HoraRecAgenda");
                bulkCopy.ColumnMappings.Add("Devolucao", "Devolucao");
                bulkCopy.ColumnMappings.Add("Status", "Status");
                bulkCopy.ColumnMappings.Add("Login", "Login");
                bulkCopy.ColumnMappings.Add("NoShow", "NoShow");
                bulkCopy.ColumnMappings.Add("CodigoTransportadora", "CodigoTransportadora");
                bulkCopy.ColumnMappings.Add("TipoIdentificadorFiscal", "TipoIdentificadorFiscal");
                bulkCopy.ColumnMappings.Add("CnpjTransportadora", "CnpjTransportadora");
                bulkCopy.ColumnMappings.Add("NomeTransportadora", "NomeTransportadora");
                bulkCopy.ColumnMappings.Add("TipoCompra", "TipoCompra");
                bulkCopy.ColumnMappings.Add("TipoDeposito", "TipoDeposito");
                bulkCopy.ColumnMappings.Add("DocaDescarga", "DocaDescarga");

                await bulkCopy.WriteToServerAsync(dataTable);

                // PASSO 3: Confirma a transação
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Desfaz tudo em caso de erro
                await transaction.RollbackAsync();
                throw; // Re-lança a exceção para o componente capturar
            }
        }

        private DataTable ConvertToDataTable(List<BaseLNcs> produtos)
        {
            var dataTable = new DataTable();

            // Define todas as colunas
            dataTable.Columns.Add("Armazem", typeof(string));
            dataTable.Columns.Add("Senha", typeof(string));
            dataTable.Columns.Add("StatusSenha", typeof(string));
            dataTable.Columns.Add("BOSS", typeof(string));
            dataTable.Columns.Add("Fornecedor", typeof(string));
            dataTable.Columns.Add("RazaoSocial", typeof(string));
            dataTable.Columns.Add("Doca", typeof(string));
            dataTable.Columns.Add("DataAgenda", typeof(DateTime));
            dataTable.Columns.Add("PlacaVeiculo", typeof(string));
            dataTable.Columns.Add("DataChegada", typeof(DateTime));
            dataTable.Columns.Add("HoraChegada", typeof(TimeSpan));
            dataTable.Columns.Add("DataLancamento", typeof(DateTime));
            dataTable.Columns.Add("HoraLancamento", typeof(TimeSpan));
            dataTable.Columns.Add("DataEnvioBOSS", typeof(DateTime));
            dataTable.Columns.Add("HoraEnvioBOSS", typeof(TimeSpan));
            dataTable.Columns.Add("DataChamada", typeof(DateTime));
            dataTable.Columns.Add("HoraChamada", typeof(TimeSpan));
            dataTable.Columns.Add("DataAprovacao", typeof(DateTime));
            dataTable.Columns.Add("HoraAprovacao", typeof(TimeSpan));
            dataTable.Columns.Add("Pedido", typeof(string));
            dataTable.Columns.Add("Linha", typeof(string));
            dataTable.Columns.Add("CnpjPnExpedidor", typeof(string));
            dataTable.Columns.Add("Companhia", typeof(string));
            dataTable.Columns.Add("ItemSKU", typeof(string));
            dataTable.Columns.Add("DescricaoItem", typeof(string));
            dataTable.Columns.Add("ItemFornecedor", typeof(string));
            dataTable.Columns.Add("QtdAgendada", typeof(decimal));
            dataTable.Columns.Add("QtdRecebida", typeof(decimal));
            dataTable.Columns.Add("Preco", typeof(decimal));
            dataTable.Columns.Add("NotaFiscal", typeof(string));
            dataTable.Columns.Add("Serie", typeof(string));
            dataTable.Columns.Add("Localizador", typeof(string));
            dataTable.Columns.Add("RemessaArmazem", typeof(string));
            dataTable.Columns.Add("RecFisico", typeof(string));
            dataTable.Columns.Add("RecFiscal", typeof(string));
            dataTable.Columns.Add("CodigoEntrega", typeof(string));
            dataTable.Columns.Add("Transportadora", typeof(string));
            dataTable.Columns.Add("SKUOnline", typeof(string));
            dataTable.Columns.Add("EanTributario", typeof(string));
            dataTable.Columns.Add("Multicanalidade", typeof(string));
            dataTable.Columns.Add("CategoriaPlano", typeof(string));
            dataTable.Columns.Add("Diretoria", typeof(string));
            dataTable.Columns.Add("ProdutoXD", typeof(string));
            dataTable.Columns.Add("ValorAgenda", typeof(decimal));
            dataTable.Columns.Add("ValorComEstornoLN", typeof(decimal));
            dataTable.Columns.Add("ValorComEstornoBI", typeof(decimal));
            dataTable.Columns.Add("DataRecAgenda", typeof(DateTime));
            dataTable.Columns.Add("HoraRecAgenda", typeof(TimeSpan));
            dataTable.Columns.Add("Devolucao", typeof(string));
            dataTable.Columns.Add("Status", typeof(string));
            dataTable.Columns.Add("Login", typeof(string));
            dataTable.Columns.Add("NoShow", typeof(string));
            dataTable.Columns.Add("CodigoTransportadora", typeof(string));
            dataTable.Columns.Add("TipoIdentificadorFiscal", typeof(string));
            dataTable.Columns.Add("CnpjTransportadora", typeof(string));
            dataTable.Columns.Add("NomeTransportadora", typeof(string));
            dataTable.Columns.Add("TipoCompra", typeof(string));
            dataTable.Columns.Add("TipoDeposito", typeof(string));
            dataTable.Columns.Add("DocaDescarga", typeof(string));

            // Permite valores NULL nas colunas de data, hora e valores
            dataTable.Columns["DataAgenda"].AllowDBNull = true;
            dataTable.Columns["DataChegada"].AllowDBNull = true;
            dataTable.Columns["HoraChegada"].AllowDBNull = true;
            dataTable.Columns["DataLancamento"].AllowDBNull = true;
            dataTable.Columns["HoraLancamento"].AllowDBNull = true;
            dataTable.Columns["DataEnvioBOSS"].AllowDBNull = true;
            dataTable.Columns["HoraEnvioBOSS"].AllowDBNull = true;
            dataTable.Columns["DataChamada"].AllowDBNull = true;
            dataTable.Columns["HoraChamada"].AllowDBNull = true;
            dataTable.Columns["DataAprovacao"].AllowDBNull = true;
            dataTable.Columns["HoraAprovacao"].AllowDBNull = true;
            dataTable.Columns["QtdAgendada"].AllowDBNull = true;
            dataTable.Columns["QtdRecebida"].AllowDBNull = true;
            dataTable.Columns["Preco"].AllowDBNull = true;
            dataTable.Columns["ValorAgenda"].AllowDBNull = true;
            dataTable.Columns["ValorComEstornoLN"].AllowDBNull = true;
            dataTable.Columns["ValorComEstornoBI"].AllowDBNull = true;
            dataTable.Columns["DataRecAgenda"].AllowDBNull = true;
            dataTable.Columns["HoraRecAgenda"].AllowDBNull = true;

            // Popula as linhas tratando valores NULL
            foreach (var produto in produtos)
            {
                dataTable.Rows.Add(
                    produto.Armazem,
                    produto.Senha,
                    produto.StatusSenha,
                    produto.BOSS,
                    produto.Fornecedor,
                    produto.RazaoSocial,
                    produto.Doca,
                    produto.DataAgenda.HasValue ? (object)produto.DataAgenda.Value : DBNull.Value,
                    produto.PlacaVeiculo,
                    produto.DataChegada.HasValue ? (object)produto.DataChegada.Value : DBNull.Value,
                    produto.HoraChegada.HasValue ? (object)produto.HoraChegada.Value : DBNull.Value,
                    produto.DataLancamento.HasValue ? (object)produto.DataLancamento.Value : DBNull.Value,
                    produto.HoraLancamento.HasValue ? (object)produto.HoraLancamento.Value : DBNull.Value,
                    produto.DataEnvioBOSS.HasValue ? (object)produto.DataEnvioBOSS.Value : DBNull.Value,
                    produto.HoraEnvioBOSS.HasValue ? (object)produto.HoraEnvioBOSS.Value : DBNull.Value,
                    produto.DataChamada.HasValue ? (object)produto.DataChamada.Value : DBNull.Value,
                    produto.HoraChamada.HasValue ? (object)produto.HoraChamada.Value : DBNull.Value,
                    produto.DataAprovacao.HasValue ? (object)produto.DataAprovacao.Value : DBNull.Value,
                    produto.HoraAprovacao.HasValue ? (object)produto.HoraAprovacao.Value : DBNull.Value,
                    produto.Pedido,
                    produto.Linha,
                    produto.CnpjPnExpedidor,
                    produto.Companhia,
                    produto.ItemSKU,
                    produto.DescricaoItem,
                    produto.ItemFornecedor,
                    produto.QtdAgendada.HasValue ? (object)produto.QtdAgendada.Value : DBNull.Value,
                    produto.QtdRecebida.HasValue ? (object)produto.QtdRecebida.Value : DBNull.Value,
                    produto.Preco.HasValue ? (object)produto.Preco.Value : DBNull.Value,
                    produto.NotaFiscal,
                    produto.Serie,
                    produto.Localizador,
                    produto.RemessaArmazem,
                    produto.RecFisico,
                    produto.RecFiscal,
                    produto.CodigoEntrega,
                    produto.Transportadora,
                    produto.SKUOnline,
                    produto.EanTributario,
                    produto.Multicanalidade,
                    produto.CategoriaPlano,
                    produto.Diretoria,
                    produto.ProdutoXD,
                    produto.ValorAgenda.HasValue ? (object)produto.ValorAgenda.Value : DBNull.Value,
                    produto.ValorComEstornoLN.HasValue ? (object)produto.ValorComEstornoLN.Value : DBNull.Value,
                    produto.ValorComEstornoBI.HasValue ? (object)produto.ValorComEstornoBI.Value : DBNull.Value,
                    produto.DataRecAgenda.HasValue ? (object)produto.DataRecAgenda.Value : DBNull.Value,
                    produto.HoraRecAgenda.HasValue ? (object)produto.HoraRecAgenda.Value : DBNull.Value,
                    produto.Devolucao,
                    produto.Status,
                    produto.Login,
                    produto.NoShow,
                    produto.CodigoTransportadora,
                    produto.TipoIdentificadorFiscal,
                    produto.CnpjTransportadora,
                    produto.NomeTransportadora,
                    produto.TipoCompra,
                    produto.TipoDeposito,
                    produto.DocaDescarga
                );
            }

            return dataTable;
        }

        public async Task<List<BaseLNcs>> ObterTodosAsync()
        {
            return new List<BaseLNcs>();
        }

        public Task DeletarEInserirComTransacaoAsync(List<BaseLNcs> produtos)
        {
            throw new NotImplementedException();
        }
    }

}
