using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteCoreCF.Models.Entities;

namespace TesteCoreCF.Models.Maps
{
    public class AlternativaMap : IEntityTypeConfiguration<Alternativa>
    {
        public void Configure(EntityTypeBuilder<Alternativa> entity)
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

            entity.HasOne(d => d.MultiplaEscolha)
                .WithMany(p => p.Alternativa)
                .HasForeignKey(d => d.IdQuestao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Alternativa_MultiplaEscolha1");
        }
    }
}
