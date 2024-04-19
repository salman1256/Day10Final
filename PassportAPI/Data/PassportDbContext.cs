using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PassportAPI.Models;

namespace PassportAPI.Data
{
    public class PassportDbContext : DbContext
    {
        public PassportDbContext (DbContextOptions<PassportDbContext> options)
            : base(options)
        {
        }

        public DbSet<PassportAPI.Models.Passport> Passport { get; set; } = default!;
    }
}
