using System.Collections.Generic;
using System.IO;
using System.Linq;

using Maksim.SearchUsingPredicates.Interfaces;
using Maksim.SearchUsingPredicates.Models;

using Newtonsoft.Json;

namespace Maksim.SearchUsingPredicates.Dal
{
    public class SearchFromJsonContext : IDataAccess
    {
        private JsonReader _reader;

        public SearchFromJsonContext()
        {
            StreamReader re = new StreamReader("Notebooks.json");
            JsonTextReader reader = new JsonTextReader(re);
            JsonSerializer se = new JsonSerializer();
            List<Notebook> parsedData = se.Deserialize<List<Notebook>>(reader);
            this.NotebookList = parsedData.AsQueryable();
        }

        public IQueryable<Notebook> NotebookList { get; }
    }
}