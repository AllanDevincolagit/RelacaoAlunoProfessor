using Microsoft.EntityFrameworkCore;
using RelacaoAlunoProfessor.Entidades;

namespace RelacaoAlunoProfessor
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base(options) { }
        public DbSet<Aluno> ALUNO { get; set; }
        public DbSet<Materia> MATERIA { get; set; }
        public DbSet<Professor> PROFESSOR { get; set; }
    }
}
