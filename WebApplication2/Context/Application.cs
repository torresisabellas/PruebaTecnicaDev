using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Context
{
    public class Application : DbContext
    {
        public DbSet<STUDENT> student { get; set; }

        public Application(DbContextOptions<Application> options)
        : base(options)
        {
        }
    }
}
