using Insta.BusinessLogic.Entities;

namespace Insta.Web.Models
{
    public class FindResultsViewModel
    {
        public PostEntity[] Posts { get; set; }

        public UserEntity[] Users { get; set; }
    }
}
