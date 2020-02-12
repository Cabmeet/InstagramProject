using System.Linq;

using Insta.BusinessLogic.Entities;
using Insta.DataAccess.Records;

namespace Insta.BusinessLogic.Converters
{
    public static class PostConverters
    {
        public static PostEntity ToEntity(this PostRecord record)
        {
            return new PostEntity
            {
                Id = record.PostId,
                CreatedAt = record.CreatedAt,
                UserId = record.UserId,
                UserName = record.User.Profile.UserName,
                Description = record.Description.Text,
                Location = record.Geolocation,
                Tags = record.Tags.Select(x => x.UniqueTag).Select(x => x.Text).ToArray()
            };
        }
    }
}
