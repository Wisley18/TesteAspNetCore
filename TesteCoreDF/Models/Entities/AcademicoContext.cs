using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TesteCoreDF.Models.Entities
{
    public partial class AcademicoContextDF : DbContext
    {
        public AcademicoContextDF()
        {
        }

        public AcademicoContextDF(DbContextOptions<AcademicoContextDF> options)
            : base(options)
        {
        }

        public virtual DbSet<Alternativa> Alternativa { get; set; }
        public virtual DbSet<MultiplaEscolha> MultiplaEscolha { get; set; }
        public virtual DbSet<Questao> Questao { get; set; }
        public virtual DbSet<QuestaoTema> QuestaoTema { get; set; }
        public virtual DbSet<Questionario> Questionario { get; set; }
        public virtual DbSet<QuestionarioQuestao> QuestionarioQuestao { get; set; }
        public virtual DbSet<QuestionarioQuestaoAlternativa> QuestionarioQuestaoAlternativa { get; set; }
        public virtual DbSet<Tema> Tema { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=192.168.1.56;port=3306;user=root;password=123456789;database=Academico");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alternativa>(entity =>
            {
                entity.ToTable("Alternativa", "Academico");

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

            modelBuilder.Entity<MultiplaEscolha>(entity =>
            {
                entity.ToTable("MultiplaEscolha", "Academico");

                entity.HasIndex(e => e.Id)
                    .HasName("fk_MultiplaEscolha_Questao1_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.MultiplaEscolha)
                    .HasForeignKey<MultiplaEscolha>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MultiplaEscolha_Questao1");
            });

            modelBuilder.Entity<Questao>(entity =>
            {
                entity.ToTable("Questao", "Academico");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.DataHoraCriacao).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.StatusRegistro).HasColumnType("enum('1','2','3')");

                entity.Property(e => e.Texto).IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuestaoTema>(entity =>
            {
                entity.ToTable("QuestaoTema", "Academico");

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
                    .WithMany(p => p.QuestaoTema)
                    .HasForeignKey(d => d.IdQuestao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QuestaoTema_Questao1");

                entity.HasOne(d => d.IdTemaNavigation)
                    .WithMany(p => p.QuestaoTema)
                    .HasForeignKey(d => d.IdTema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QuestaoTema_Tema");
            });

            modelBuilder.Entity<Questionario>(entity =>
            {
                entity.ToTable("Questionario", "Academico");

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

            modelBuilder.Entity<QuestionarioQuestao>(entity =>
            {
                entity.ToTable("QuestionarioQuestao", "Academico");

                entity.HasIndex(e => e.IdQuestao)
                    .HasName("fk_QuestionarioQuestao_Questao1_idx");

                entity.HasIndex(e => e.IdQuestionario)
                    .HasName("fk_QuestionarioQuestao_Questionario1_idx");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.IdQuestao).HasColumnType("bigint(20)");

                entity.Property(e => e.IdQuestionario).HasColumnType("bigint(20)");

                entity.HasOne(d => d.IdQuestaoNavigation)
                    .WithMany(p => p.QuestionarioQuestao)
                    .HasForeignKey(d => d.IdQuestao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QuestionarioQuestao_Questao1");

                entity.HasOne(d => d.IdQuestionarioNavigation)
                    .WithMany(p => p.QuestionarioQuestao)
                    .HasForeignKey(d => d.IdQuestionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QuestionarioQuestao_Questionario1");
            });

            modelBuilder.Entity<QuestionarioQuestaoAlternativa>(entity =>
            {
                entity.ToTable("QuestionarioQuestaoAlternativa", "Academico");

                entity.HasIndex(e => e.IdAlternativa)
                    .HasName("fk_QuestionarioQuestaoAlternativa_Alternativa1_idx");

                entity.HasIndex(e => e.IdQuestionarioQuestao)
                    .HasName("fk_QuestionarioQuestaoAlternativa_QuestionarioQuestao1_idx");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.IdAlternativa).HasColumnType("bigint(20)");

                entity.Property(e => e.IdQuestionarioQuestao).HasColumnType("bigint(20)");

                entity.HasOne(d => d.IdAlternativaNavigation)
                    .WithMany(p => p.QuestionarioQuestaoAlternativa)
                    .HasForeignKey(d => d.IdAlternativa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QuestionarioQuestaoAlternativa_Alternativa1");

                entity.HasOne(d => d.IdQuestionarioQuestaoNavigation)
                    .WithMany(p => p.QuestionarioQuestaoAlternativa)
                    .HasForeignKey(d => d.IdQuestionarioQuestao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QuestionarioQuestaoAlternativa_QuestionarioQuestao1");
            });

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.ToTable("Tema", "Academico");

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
