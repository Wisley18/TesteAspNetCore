using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteCoreCF.Models.Entities;

namespace TesteCoreCF.Models.Maps
{
    public class QuestionarioQuestaoAlternativaMap : IEntityTypeConfiguration<QuestionarioQuestaoAlternativa>
    {
        public void Configure(EntityTypeBuilder<QuestionarioQuestaoAlternativa> entity)
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
        }
    }
}
