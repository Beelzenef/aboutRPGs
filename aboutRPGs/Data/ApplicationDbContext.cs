using System;
using System.Collections.Generic;
using System.Text;
using aboutRPGs.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace aboutRPGs.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Adventure> Adventures { get; set; }
        public DbSet<TodoItem> Items { get; set; }
    }
}
