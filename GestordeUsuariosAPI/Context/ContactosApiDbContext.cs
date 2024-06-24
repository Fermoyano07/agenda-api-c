
using GestordeContactosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestordeContactosApi.Context
{
    public class ContactosApiDbContext : DbContext

    {
        public ContactosApiDbContext(DbContextOptions<ContactosApiDbContext> options) : base(options)
        {

        }
            
        public DbSet<Contacto> Contacto { get; set; }
    }
}
