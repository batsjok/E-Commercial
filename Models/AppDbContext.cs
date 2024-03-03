using System;
using Microsoft.EntityFrameworkCore;

namespace WebApp.web.Models
{
    public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<Product> ProductTBL  { get; set; }

        public DbSet<Visitor> VisitorsTBL { get; set; }
	}
}

