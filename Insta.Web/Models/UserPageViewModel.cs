using Insta.BusinessLogic.Entities;

namespace Insta.Web.Models
{
    public class UserPageViewModel
    {
        public int Followers { get; set; }

        public int Following { get; set; }

        public Container<PostEntity> Posts { get; set; }

        public UserEntity User { get; set; }

        public bool MyPosts { get; set; }
    }
}
