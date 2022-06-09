using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FinanceEntity : Entity
    {
        public decimal Budget { get; set; }
        public decimal? Earning { get; set; }
        public int MovieId { get; set; }
        public MovieEntity Movie { get; set; }
    }
}
