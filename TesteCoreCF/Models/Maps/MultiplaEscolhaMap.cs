using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteCoreCF.Models.Entities;

namespace TesteCoreCF.Models.Maps
{
    public class MultiplaEscolhaMap : IEntityTypeConfiguration<MultiplaEscolha>
    {
        public void Configure(EntityTypeBuilder<MultiplaEscolha> entity)
        {
            entity.ToTable("MultiplaEscolha", "Academico");

            entity.HasIndex(e => e.Id)
                .HasName("fk_MultiplaEscolha_Questao1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .ValueGeneratedNever();

            entity.HasOne(d => d.Questao)
                .WithOne(p => p.MultiplaEscolha)
                .HasForeignKey<MultiplaEscolha>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MultiplaEscolha_Questao1");
        }
    }
}
