using System.Collections.Generic;

using Maksim.SearchUsingPredicates.Models;

namespace Maksim.SearchUsingPredicates.Interfaces
{
    public interface INotebookService
    {
        IEnumerable<Notebook> SearchNotebooks(string searchString);
    }
}