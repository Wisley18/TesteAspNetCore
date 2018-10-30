using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TesteCoreCF.Models.Entities;
using TesteCoreCF.Models.Maps;

namespace TesteCoreCF.Models.Entities
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
        public virtual DbSet<MultiplaEscolha> MultiplaEscolha { get; set; }
        public virtual DbSet<Questao> Questao { get; set; }
        public virtual DbSet<QuestaoTema> QuestaoTema { get; set; }
        public virtual DbSet<Questionario> Questionario { get; set; }
        public virtual DbSet<QuestionarioQuestao> QuestionarioQuestao { get; set; }
        public virtual DbSet<QuestionarioQuestaoAlternativa> QuestionarioQuestaoAlternativa { get; set; }
        public virtual DbSet<Tema> Tema { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySQL("server=192.168.1.56;port=3306;user=root;password=123456789;database=Academico");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alternativa>(new AlternativaMap().Configure);

            modelBuilder.Entity<MultiplaEscolha>(new MultiplaEscolhaMap().Configure);

            modelBuilder.Entity<Questao>(new QuestaoMap().Configure);

            modelBuilder.Entity<QuestaoTema>(new QuestaoTemaMap().Configure);

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

                entity.HasOne(d => d.Tema)
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

                entity.HasOne(d => d.Questao)
                    .WithMany(p => p.QuestionarioQuestao)
                    .HasForeignKey(d => d.IdQuestao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QuestionarioQuestao_Questao1");

                entity.HasOne(d => d.Questionario)
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

                entity.HasOne(d => d.Alternativa)
                    .WithMany(p => p.QuestionarioQuestaoAlternativa)
                    .HasForeignKey(d => d.IdAlternativa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_QuestionarioQuestaoAlternativa_Alternativa1");

                entity.HasOne(d => d.QuestionarioQuestao)
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
