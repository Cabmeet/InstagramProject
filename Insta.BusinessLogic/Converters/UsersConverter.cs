using Insta.BusinessLogic.Entities;
using Insta.BusinessLogic.Enums;
using Insta.DataAccess.Records;

namespace Insta.BusinessLogic.Converters
{
    internal static class UsersConverter
    {
        public static UserEntity ToEntity(this UserRecord userEntity)
        {
            return new UserEntity
            {
                Id = userEntity.UserId,
                Email = userEntity.Email,
                Age = userEntity.Profile.Age,
                Description = userEntity.Profile.Description,
                FirstName = userEntity.Profile.FirstName,
                Gender = (Gender)userEntity.Profile.Gender,
                LastName = userEntity.Profile.LastName,
                IsVisible = userEntity.Profile.IsVisible,
                UserName = userEntity.Profile.UserName,
                CanSubscribe = true,
                ProfileImageCloudUrl = userEntity.Profile.ImageCloudUrl
            };
        }
    }
}
