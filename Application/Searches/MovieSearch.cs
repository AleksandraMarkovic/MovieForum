using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class MovieSearch
    {
        public string Keyword { get; set; }
        public int? Year { get; set; }
        public int? MinDuration { get; set; }
        public int? MaxDuration { get; set; }
    }
}
