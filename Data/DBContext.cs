using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp_22_11_2023.Models;

namespace WebApp_22_11_2023.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<WebApp_22_11_2023.Models.CadClientes> CadClientes { get; set; } = default!;

        public DbSet<WebApp_22_11_2023.Models.CadMaquinas> CadMaquinas { get; set; } = default!;

        public DbSet<WebApp_22_11_2023.Models.Inventario> Inventario { get; set; } = default!;
    }
}
