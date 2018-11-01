using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TesteCoreCF.Models.Entities;
using TesteCoreCF.Models.Maps;

namespace TesteCoreCF.Models.Entities
{
    public partial class AcademicoContextCF : DbContext
    {
        public AcademicoContextCF()
        {
        }

        public AcademicoContextCF(DbContextOptions<AcademicoContextCF> options)
            : base(options)
        {
        }

        public virtual DbSet<Alternativa> Alternativa { get; set; }
        public virtual DbSet<MultiplaEscolha> MultiplaEscolha { get; set; }
        public virtual DbSet<Questao> Questao { get; set; }
        public virtual DbSet<QuestaoTema> QuestaoTema { get; set; }
        public virtual DbSet<Tema> Tema { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alternativa>(new AlternativaMap().Configure);

            modelBuilder.Entity<MultiplaEscolha>(new MultiplaEscolhaMap().Configure);

            modelBuilder.Entity<Questao>(new QuestaoMap().Configure);

            modelBuilder.Entity<QuestaoTema>(new QuestaoTemaMap().Configure);

            modelBuilder.Entity<Tema>(new TemaMap().Configure);
        }
    }
}
