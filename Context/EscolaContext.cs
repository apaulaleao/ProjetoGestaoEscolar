using Escola.Models;
using Microsoft.EntityFrameworkCore;

namespace Escola.Context
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options)
        {
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Aluno>().ToTable("Aluno");

          //  modelBuilder.Entity<Aluno>()
           //   .HasOne(e => e.Turma) // 1 aluno participa de 1 turma
           //     .WithMany(e => e.Alunos) //1 turma tem varios alunos
          //      .HasForeignKey(e => e.TurmaId); //FK

            modelBuilder.Entity<Turma>().ToTable("Turma");
            //    .HasMany(e => e.Alunos) 
            //   .WithOney(e => e.Turma); 



        }

        public DbSet<Aluno>? Aluno { get; set; }
        public DbSet<Turma>? Turma { get; set; }

    }
}

