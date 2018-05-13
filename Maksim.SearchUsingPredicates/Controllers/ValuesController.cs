using System.Collections.Generic;

using Maksim.SearchUsingPredicates.Interfaces;
using Maksim.SearchUsingPredicates.Models;

using Microsoft.AspNetCore.Mvc;

namespace Maksim.SearchUsingPredicates.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly INotebookService _notebookService;

        public ValuesController(INotebookService notebookService)
        {
            this._notebookService = notebookService;
        }

        // GET api/values/apple && toshiba
        [HttpGet("{searchString}")]
        public IEnumerable<Notebook> Get(string searchString)
        {
            return this._notebookService.SearchNotebooks(searchString);
        }
    }
}