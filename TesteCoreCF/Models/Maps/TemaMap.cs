using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteCoreCF.Models.Entities;

namespace TesteCoreCF.Models.Maps
{
    public class TemaMap : IEntityTypeConfiguration<Tema>
    {
        public void Configure(EntityTypeBuilder<Tema> entity)
        {
            entity.ToTable("Tema", "Academico");

            entity.Property(e => e.Id).HasColumnType("bigint(20)");

            entity.Property(e => e.DataHoraCriacao).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(e => e.Descricao).IsUnicode(false);

            entity.Property(e => e.Nome)
                .HasMaxLength(70)
                .IsUnicode(false);

            entity.Property(e => e.StatusRegistro).HasColumnType("enum('1','2','3')");
        }
    }
}
