using System;

using Insta.BusinessLogic.Encryption;
using Insta.BusinessLogic.Entities;
using Insta.BusinessLogic.Enums;
using Insta.DataAccess.Records;

namespace Insta.BusinessLogic.Converters
{
    internal static class UsersConverter
    {
        public static UserEntity TonEntity(this UserRecord userRecord, EntityRecord entityRecord)
        {
            if (userRecord == null)
            {
                return null;
            }

            return new UserEntity
            {
                Id = entityRecord.EntityGuid,
                Age = userRecord.Profile.Age,
                Description = userRecord.Profile.Description,
                Email = userRecord.Email,
                FirstName = userRecord.Profile.FirstName,
                LastName = userRecord.Profile.LastName,
                UserName = userRecord.Profile.UserName,
                Gender = (Gender)userRecord.Profile.Gender
            };
        }

        public static UserRecord ToRecord(this UserEntity userEntity, string password)
        {
            return new UserRecord
            {
                Email = userEntity.Email,
                CreatedAt = DateTimeOffset.Now,
                EncryptedPassword = StringEncryptor.Encrypt(password),
                Profile = new ProfileRecord
                {
                    Age = userEntity.Age,
                    Description = userEntity.Description,
                    FirstName = userEntity.FirstName,
                    Gender = (int)userEntity.Gender,
                    LastName = userEntity.LastName,
                    IsVisible = true,
                    UserName = userEntity.UserName
                }
            };
        }
    }
}
