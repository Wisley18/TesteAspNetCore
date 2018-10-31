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

            modelBuilder.Entity<Questionario>(new QuestionarioMap().Configure);

            modelBuilder.Entity<QuestionarioQuestao>(new QuestionarioQuestaoMap().Configure);

            modelBuilder.Entity<QuestionarioQuestaoAlternativa>(new QuestionarioQuestaoAlternativaMap().Configure);

            modelBuilder.Entity<Tema>(new TemaMap().Configure);
        }
    }
}
