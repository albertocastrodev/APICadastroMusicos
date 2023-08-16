using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCadastroMusicos.Migrations
{
    public partial class CreateDataBase01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DadosMusicais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeituraDeCifra = table.Column<bool>(type: "bit", nullable: false),
                    LeituraDePartitura = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosMusicais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeInstrumentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeInstrumentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoMusicais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantidadeIntegrantes = table.Column<int>(type: "int", nullable: false),
                    DadosMusicaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoMusicais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupoMusicais_DadosMusicais_DadosMusicaisId",
                        column: x => x.DadosMusicaisId,
                        principalTable: "DadosMusicais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SobreNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Idade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false),
                    EnderecoId1 = table.Column<int>(type: "int", nullable: false),
                    DadosMusicaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_DadosMusicais_DadosMusicaisId",
                        column: x => x.DadosMusicaisId,
                        principalTable: "DadosMusicais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoas_Enderecos_EnderecoId1",
                        column: x => x.EnderecoId1,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instrumentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoInstrumentoId = table.Column<int>(type: "int", nullable: false),
                    DadosMusicaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrumentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instrumentos_DadosMusicais_DadosMusicaisId",
                        column: x => x.DadosMusicaisId,
                        principalTable: "DadosMusicais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instrumentos_TipoDeInstrumentos_TipoInstrumentoId",
                        column: x => x.TipoInstrumentoId,
                        principalTable: "TipoDeInstrumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DDD = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefones_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrupoMusicais_DadosMusicaisId",
                table: "GrupoMusicais",
                column: "DadosMusicaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Instrumentos_DadosMusicaisId",
                table: "Instrumentos",
                column: "DadosMusicaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Instrumentos_TipoInstrumentoId",
                table: "Instrumentos",
                column: "TipoInstrumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_DadosMusicaisId",
                table: "Pessoas",
                column: "DadosMusicaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EnderecoId1",
                table: "Pessoas",
                column: "EnderecoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_PessoaId",
                table: "Telefones",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrupoMusicais");

            migrationBuilder.DropTable(
                name: "Instrumentos");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropTable(
                name: "TipoDeInstrumentos");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "DadosMusicais");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
