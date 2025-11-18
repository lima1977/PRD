using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRD.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseFiscalDoca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseDocaFiscal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Armazem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusSenha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BOSS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAgenda = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlacaVeiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataChegada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraChegada = table.Column<TimeSpan>(type: "time", nullable: true),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraLancamento = table.Column<TimeSpan>(type: "time", nullable: true),
                    DataEnvioBOSS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraEnvioBOSS = table.Column<TimeSpan>(type: "time", nullable: true),
                    DataChamada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraChamada = table.Column<TimeSpan>(type: "time", nullable: true),
                    DataAprovacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraAprovacao = table.Column<TimeSpan>(type: "time", nullable: true),
                    Pedido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Linha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CnpjPnExpedidor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Companhia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemSKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdAgendada = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QtdRecebida = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NotaFiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Serie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localizador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemessaArmazem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecFisico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecFiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transportadora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKUOnline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EanTributario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Multicanalidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaPlano = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diretoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdutoXD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorAgenda = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorComEstornoLN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorComEstornoBI = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DataRecAgenda = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraRecAgenda = table.Column<TimeSpan>(type: "time", nullable: true),
                    Devolucao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoShow = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoTransportadora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoIdentificadorFiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CnpjTransportadora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeTransportadora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoCompra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDeposito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocaDescarga = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseDocaFiscal", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseDocaFiscal");
        }
    }
}
