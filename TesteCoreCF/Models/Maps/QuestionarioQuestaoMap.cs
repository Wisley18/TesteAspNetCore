using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteCoreCF.Models.Entities;

namespace TesteCoreCF.Models.Maps
{
    public class QuestionarioQuestaoMap : IEntityTypeConfiguration<QuestionarioQuestao>
    {
        public void Configure(EntityTypeBuilder<QuestionarioQuestao> entity)
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
        }
    }
}
