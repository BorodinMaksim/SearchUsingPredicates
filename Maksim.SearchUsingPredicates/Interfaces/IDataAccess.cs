using System.Linq;

using Maksim.SearchUsingPredicates.Models;

namespace Maksim.SearchUsingPredicates.Interfaces
{
    public interface IDataAccess
    {
        IQueryable<Notebook> NotebookList { get; }
    }
}