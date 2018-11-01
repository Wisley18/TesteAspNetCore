using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteCoreCF.Migrations
{
    public partial class VersaoInicialTeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Academico");

            migrationBuilder.CreateTable(
                name: "Questao",
                schema: "Academico",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Texto = table.Column<string>(unicode: false, nullable: true),
                    Tipo = table.Column<string>(unicode: false, maxLength: 45, nullable: true),
                    StatusRegistro = table.Column<string>(type: "enum('1','2','3')", nullable: true),
                    DataHoraCriacao = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tema",
                schema: "Academico",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Nome = table.Column<string>(unicode: false, maxLength: 70, nullable: true),
                    Descricao = table.Column<string>(unicode: false, nullable: true),
                    StatusRegistro = table.Column<string>(type: "enum('1','2','3')", nullable: true),
                    DataHoraCriacao = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MultiplaEscolha",
                schema: "Academico",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiplaEscolha", x => x.Id);
                    table.ForeignKey(
                        name: "fk_MultiplaEscolha_Questao1",
                        column: x => x.Id,
                        principalSchema: "Academico",
                        principalTable: "Questao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestaoTema",
                schema: "Academico",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    IdTema = table.Column<long>(type: "bigint(20)", nullable: false),
                    IdQuestao = table.Column<long>(type: "bigint(20)", nullable: false),
                    Relevancia = table.Column<string>(type: "enum('1','2','3')", nullable: true),
                    Dificuldade = table.Column<string>(type: "enum('1','2','3')", nullable: true),
                    StatusRegistro = table.Column<string>(type: "enum('1','2','3')", nullable: true),
                    DataHoraCriacao = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestaoTema", x => x.Id);
                    table.ForeignKey(
                        name: "fk_QuestaoTema_Questao1",
                        column: x => x.IdQuestao,
                        principalSchema: "Academico",
                        principalTable: "Questao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_QuestaoTema_Tema",
                        column: x => x.IdTema,
                        principalSchema: "Academico",
                        principalTable: "Tema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alternativa",
                schema: "Academico",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint(20)", nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    IdQuestao = table.Column<long>(type: "bigint(20)", nullable: false),
                    Texto = table.Column<string>(unicode: false, nullable: true),
                    TipoResposta = table.Column<string>(type: "enum('1','2','3')", nullable: true),
                    StatusRegistro = table.Column<string>(type: "enum('1','2','3')", nullable: true),
                    DataHoraCriacao = table.Column<DateTimeOffset>(nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alternativa", x => x.Id);
                    table.ForeignKey(
                        name: "fk_Alternativa_MultiplaEscolha1",
                        column: x => x.IdQuestao,
                        principalSchema: "Academico",
                        principalTable: "MultiplaEscolha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fk_Alternativa_MultiplaEscolha1_idx",
                schema: "Academico",
                table: "Alternativa",
                column: "IdQuestao");

            migrationBuilder.CreateIndex(
                name: "fk_MultiplaEscolha_Questao1_idx",
                schema: "Academico",
                table: "MultiplaEscolha",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_QuestaoTema_Questao1_idx",
                schema: "Academico",
                table: "QuestaoTema",
                column: "IdQuestao");

            migrationBuilder.CreateIndex(
                name: "fk_QuestaoTema_Tema_idx",
                schema: "Academico",
                table: "QuestaoTema",
                column: "IdTema");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alternativa",
                schema: "Academico");

            migrationBuilder.DropTable(
                name: "QuestaoTema",
                schema: "Academico");

            migrationBuilder.DropTable(
                name: "MultiplaEscolha",
                schema: "Academico");

            migrationBuilder.DropTable(
                name: "Tema",
                schema: "Academico");

            migrationBuilder.DropTable(
                name: "Questao",
                schema: "Academico");
        }
    }
}
