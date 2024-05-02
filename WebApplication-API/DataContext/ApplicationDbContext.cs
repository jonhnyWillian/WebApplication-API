using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication_API.Models;

namespace WebApplication_API.DataContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
