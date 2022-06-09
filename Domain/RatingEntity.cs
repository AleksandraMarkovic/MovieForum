using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RatingEntity : Entity
    {
        public int RatingValue { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public MovieEntity Movie { get; set; }
        public UserEntity User { get; set; }
    }
}
