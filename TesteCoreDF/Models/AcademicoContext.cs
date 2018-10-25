using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TesteCoreDF.Models
{
    public partial class AcademicoContext : DbContext
    {
        public AcademicoContext()
        {
        }

        public AcademicoContext(DbContextOptions<AcademicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alternativa> Alternativa { get; set; }
        public virtual DbSet<Multiplaescolha> Multiplaescolha { get; set; }
        public virtual DbSet<Questao> Questao { get; set; }
        public virtual DbSet<Questaotema> Questaotema { get; set; }
        public virtual DbSet<Questionario> Questionario { get; set; }
        public virtual DbSet<Questionarioquestao> Questionarioquestao { get; set; }
        public virtual DbSet<Questionarioquestaoalternativa> Questionarioquestaoalternativa { get; set; }
        public virtual DbSet<Tema> Tema { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("MySqlConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alternativa>(entity =>
            {
                entity.ToTable("alternativa", "academico");

                entity.HasIndex(e => e.IdQuestao)
                    .HasName("fk_Alternativa_MultiplaEscolha1_idx");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.DataHoraCriacao).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IdQuestao).HasColumnType("bigint(20)");

                entity.Property(e => e.StatusRegistro).HasColumnType("enum('1','2','3')");

                entity.Property(e => e.Texto).IsUnicode(false);

                entity.Property(e => e.TipoResposta).HasColumnType("enum('1','2','3')");

                entity.HasOne(d => d.IdQuestaoNavigation)
                    .WithMany(p => p.Alternativa)
                    .HasForeignKey(d => d.IdQuestao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Alternativa_MultiplaEscolha1");
            });

            modelBuilder.Entity<Multiplaescolha>(entity =>
            {
                entity.ToTable("multiplaescolha", "academico");

                entity.HasIndex(e => e.Id)
                    .HasName("fk_MultiplaEscolha_Questao1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Multiplaescolha)
                    .HasForeignKey<Multiplaescolha>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MultiplaEscolha_Questao1");
            });

            modelBuilder.Entity<Questao>(entity =>
            {
                entity.ToTable("questao", "academico");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.DataHoraCriacao).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.StatusRegistro).HasColumnType("enum('1','2','3')");

                entity.Property(e => e.Texto).IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Questaotema>(entity =>
            {
                entity.ToTable("questaotema", "academico");

                entity.HasIndex(e => e.IdQuestao)
                    .HasName("fk_QuestaoTema_Questao1_idx");

                entity.HasIndex(e => e.IdTema)
                    .HasName("fk_QuestaoTema_Tema_idx");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.DataHoraCriacao).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Dificuldade).HasColumnType("enum('1','2','3')");

                entity.Property(e => e.IdQuestao).HasColumnType("bigint(20)");

                entity.Property(e => e.IdTema).HasColumnType("bigint(20)");

                entity.Property(e => e.Relevancia).HasColumnType("enum('1','2','3')");

                entity.Property(e => e.StatusRegistro).HasColumnType("enum('1','2','3')");

                entity.HasOne(d => d.IdQuestaoNavigation)
                    .WithMany(p => p.Questaotema)
                    .HasForeignKey(d => d.IdQuestao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QuestaoTema_Questao1");

                entity.HasOne(d => d.IdTemaNavigation)
                    .WithMany(p => p.Questaotema)
                    .HasForeignKey(d => d.IdTema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QuestaoTema_Tema");
            });

            modelBuilder.Entity<Questionario>(entity =>
            {
                entity.ToTable("questionario", "academico");

                entity.HasIndex(e => e.IdTema)
                    .HasName("fk_Questionario_Tema1_idx");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.IdTema).HasColumnType("bigint(20)");

                entity.Property(e => e.StatusRegistro)
                    .IsRequired()
                    .HasColumnType("enum('1','2','3')");

                entity.Property(e => e.Título)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTemaNavigation)
                    .WithMany(p => p.Questionario)
                    .HasForeignKey(d => d.IdTema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Questionario_Tema1");
            });

            modelBuilder.Entity<Questionarioquestao>(entity =>
            {
                entity.ToTable("questionarioquestao", "academico");

                entity.HasIndex(e => e.IdQuestao)
                    .HasName("fk_QuestionarioQuestao_Questao1_idx");

                entity.HasIndex(e => e.IdQuestionario)
                    .HasName("fk_QuestionarioQuestao_Questionario1_idx");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.IdQuestao).HasColumnType("bigint(20)");

                entity.Property(e => e.IdQuestionario).HasColumnType("bigint(20)");

                entity.HasOne(d => d.IdQuestaoNavigation)
                    .WithMany(p => p.Questionarioquestao)
                    .HasForeignKey(d => d.IdQuestao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QuestionarioQuestao_Questao1");

                entity.HasOne(d => d.IdQuestionarioNavigation)
                    .WithMany(p => p.Questionarioquestao)
                    .HasForeignKey(d => d.IdQuestionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QuestionarioQuestao_Questionario1");
            });

            modelBuilder.Entity<Questionarioquestaoalternativa>(entity =>
            {
                entity.ToTable("questionarioquestaoalternativa", "academico");

                entity.HasIndex(e => e.IdAlternativa)
                    .HasName("fk_QuestionarioQuestaoAlternativa_Alternativa1_idx");

                entity.HasIndex(e => e.IdQuestionarioQuestao)
                    .HasName("fk_QuestionarioQuestaoAlternativa_QuestionarioQuestao1_idx");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.IdAlternativa).HasColumnType("bigint(20)");

                entity.Property(e => e.IdQuestionarioQuestao).HasColumnType("bigint(20)");

                entity.HasOne(d => d.IdAlternativaNavigation)
                    .WithMany(p => p.Questionarioquestaoalternativa)
                    .HasForeignKey(d => d.IdAlternativa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QuestionarioQuestaoAlternativa_Alternativa1");

                entity.HasOne(d => d.IdQuestionarioQuestaoNavigation)
                    .WithMany(p => p.Questionarioquestaoalternativa)
                    .HasForeignKey(d => d.IdQuestionarioQuestao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QuestionarioQuestaoAlternativa_QuestionarioQuestao1");
            });

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.ToTable("tema", "academico");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.DataHoraCriacao).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.StatusRegistro).HasColumnType("enum('1','2','3')");
            });
        }
    }
}
