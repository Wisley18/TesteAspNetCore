using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteCoreCF.Models.Entities;

namespace TesteCoreCF.Models.Maps
{
    public class QuestionarioMap : IEntityTypeConfiguration<Questionario>
    {
        public void Configure(EntityTypeBuilder<Questionario> entity)
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
        }
    }
}
