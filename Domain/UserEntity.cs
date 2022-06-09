using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserEntity : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Image { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public bool MailingList { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastEmail { get; set; }
        public UserRoleEntity UserRole { get; set; }
        public ICollection<RatingEntity> Ratings { get; set; } = new HashSet<RatingEntity>();
        public ICollection<CommentEntity> Comments { get; set; } = new HashSet<CommentEntity>();
        public ICollection<WatchlistEntity> Watchlists { get; set; } = new HashSet<WatchlistEntity>();
    }
}
