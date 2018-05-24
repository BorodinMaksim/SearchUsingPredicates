using System.Linq;

using Maksim.SearchUsingPredicates.Interfaces;
using Maksim.SearchUsingPredicates.Models;

using Microsoft.EntityFrameworkCore;

namespace Maksim.SearchUsingPredicates.DAL
{
    public class SearchContext : DbContext, IDataAccess
    {
        public SearchContext(DbContextOptions<SearchContext> options)
            : base(options)
        {
        }

        public IQueryable<Notebook> NotebookList => this.Notebooks;

        public DbSet<Notebook> Notebooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notebook>().ToTable("Notebook");
        }
    }
}