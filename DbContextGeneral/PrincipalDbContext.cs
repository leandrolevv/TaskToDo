using CadastroTarefaAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Data;

namespace CadastroTarefaAPI.DbContextGeneral
{
    public class PrincipalDbContext: DbContext
    {
        public PrincipalDbContext(DbContextOptions<PrincipalDbContext> options) : base(options)
        {

        }
        public DbSet<TaskToDo> TasksToDo { get; set; } = null!;
    }
}
