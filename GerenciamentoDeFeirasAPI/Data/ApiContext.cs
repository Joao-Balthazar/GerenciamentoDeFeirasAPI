using Microsoft.EntityFrameworkCore;
using GerenciamentoDeFeirasAPI.Models;

namespace GerenciamentoDeFeirasAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options){}
        
        public DbSet<Feira> Feiras { get; set; }
    }
}
