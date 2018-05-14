using System.Collections.Generic;
using System.Linq;

using Maksim.SearchUsingPredicates.Common;
using Maksim.SearchUsingPredicates.DAL;
using Maksim.SearchUsingPredicates.Interfaces;
using Maksim.SearchUsingPredicates.Models;

namespace Maksim.SearchUsingPredicates.Services
{
    public class NotebookService : INotebookService
    {
        private SearchContext _context;

        private IPredicateParser _predicateParser;

        public NotebookService(IPredicateParser predicateParser, SearchContext context)
        {
            this._predicateParser = predicateParser;
            this._context = context;
        }

        public IEnumerable<Notebook> SearchNotebooks(string searchString)
        {
            ParsedSearchString parsedSearchString = this._predicateParser.Parse(searchString);
            return this._context
                .Notebooks
                .Where(QueryObject.GetExpression<Notebook>(parsedSearchString, nameof(Notebook.Name)));
        }
    }
}