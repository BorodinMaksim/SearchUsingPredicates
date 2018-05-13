using System.Collections.Generic;

using Maksim.SearchUsingPredicates.Models;

using Microsoft.EntityFrameworkCore;

namespace Maksim.SearchUsingPredicates.DAL
{
    public class SearchContext : DbContext
    {
        public SearchContext(DbContextOptions<SearchContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notebook>().ToTable("Notebook");
        }

        public DbSet<Notebook> Notebooks { get; set; }
    }
}