using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteCoreCF.Models.Entities;

namespace TesteCoreCF.Models.Maps
{
    public class QuestaoTemaMap : IEntityTypeConfiguration<QuestaoTema>
    {
        public void Configure(EntityTypeBuilder<QuestaoTema> entity)
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

            entity.HasOne(d => d.Questao)
                .WithMany(p => p.QuestaoTema)
                .HasForeignKey(d => d.IdQuestao)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_QuestaoTema_Questao1");

            entity.HasOne(d => d.Tema)
                .WithMany(p => p.QuestaoTema)
                .HasForeignKey(d => d.IdTema)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_QuestaoTema_Tema");
        }
    }
}
