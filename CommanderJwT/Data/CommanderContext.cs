using Microsoft.EntityFrameworkCore;
using Commander.Models;
using Microsoft.Extensions.Configuration;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public CommanderContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("CommanderConnection"));
        }

        public DbSet<Command> Commands { get; set; }
    }
}