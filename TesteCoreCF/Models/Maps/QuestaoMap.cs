using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteCoreCF.Models.Entities;

namespace TesteCoreCF.Models.Maps
{
    public class QuestaoMap : IEntityTypeConfiguration<Questao>
    {
        public void Configure(EntityTypeBuilder<Questao> entity)
        {
            entity.ToTable("Questao", "Academico");

            entity.Property(e => e.Id).HasColumnType("bigint(20)");

            entity.Property(e => e.DataHoraCriacao).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.StatusRegistro).HasColumnType("enum('1','2','3')");

            entity.Property(e => e.Texto).IsUnicode(false);

            entity.Property(e => e.Tipo)
                .HasMaxLength(45)
                .IsUnicode(false);
        }
    }
}
