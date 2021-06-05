using Dotnet5.RazorPage.EF.CRUD.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.RazorPage.EF.CRUD.Data
{
    public class MyWorldDbContext : DbContext
    {
        public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options) : base(options)
        {

        }
        public DbSet<Gadgets> Gadgets { get; set; }
    }
}