using System.ComponentModel.DataAnnotations.Schema;

namespace PRD.Model
{
    [Table("BaseLN")]
    public class BaseLNcs
    {
        public int Id { get; set; }

        public string? Armazem { get; set; }
        public string? Senha { get; set; }
        public string? StatusSenha { get; set; }
        public string? BOSS { get; set; }
        public string? Fornecedor { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Doca { get; set; }
        public DateTime? DataAgenda { get; set; }
        public string PlacaVeiculo { get; set; }
        public DateTime? DataChegada { get; set; }
        public TimeSpan? HoraChegada { get; set; }
        public DateTime? DataLancamento { get; set; }
        public TimeSpan? HoraLancamento { get; set; }
        public DateTime? DataEnvioBOSS { get; set; }
        public TimeSpan? HoraEnvioBOSS { get; set; }
        public DateTime? DataChamada { get; set; }
        public TimeSpan? HoraChamada { get; set; }
        public DateTime? DataAprovacao { get; set; }
        public TimeSpan? HoraAprovacao { get; set; }
        public string? Pedido { get; set; }
        public string? Linha { get; set; }
        public string? CnpjPnExpedidor { get; set; }
        public string? Companhia { get; set; }
        public string? ItemSKU { get; set; }
        public string? DescricaoItem { get; set; }
        public string? ItemFornecedor { get; set; }
        public decimal? QtdAgendada { get; set; }
        public decimal? QtdRecebida { get; set; }
        public decimal? Preco { get; set; }
        public string? NotaFiscal { get; set; }
        public string? Serie { get; set; }
        public string? Localizador { get; set; }
        public string? RemessaArmazem { get; set; }
        public string? RecFisico { get; set; }
        public string? RecFiscal { get; set; }
        public string? CodigoEntrega { get; set; }
        public string? Transportadora { get; set; }
        public string? SKUOnline { get; set; }
        public string? EanTributario { get; set; }
        public string? Multicanalidade { get; set; }
        public string? CategoriaPlano { get; set; }
        public string? Diretoria { get; set; }
        public string?   ProdutoXD { get; set; }
        public decimal? ValorAgenda { get; set; }
        public decimal? ValorComEstornoLN { get; set; }
        public decimal? ValorComEstornoBI { get; set; }
        public DateTime? DataRecAgenda { get; set; }
        public TimeSpan? HoraRecAgenda { get; set; }
        public string? Devolucao { get; set; }
        public string? Status { get; set; }
        public string? Login { get; set; }
        public string? NoShow { get; set; }
        public string? CodigoTransportadora { get; set; }
        public string? TipoIdentificadorFiscal { get; set; }
        public string? CnpjTransportadora { get; set; }
        public string? NomeTransportadora { get; set; }
        public string? TipoCompra { get; set; }
        public string? TipoDeposito { get; set; }
        public string? DocaDescarga { get; set; }


    }
}
