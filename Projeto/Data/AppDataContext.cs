using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Data;
public class AppDataContext : DbContext
{

    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options){

    }

    public DbSet<Aluno> Alunos {get; set;}
    public DbSet<IMC> IMCs {get; set;}
}
