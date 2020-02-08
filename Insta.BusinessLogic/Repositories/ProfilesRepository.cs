using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Insta.BusinessLogic.Converters;
using Insta.BusinessLogic.Entities;

using Microsoft.Practices.EnterpriseLibrary.Common.Utility;

using System.Threading.Tasks;
using System.Transactions;

using Insta.BusinessLogic.Encryption;
using Insta.DataAccess.Context;
using Insta.DataAccess.Records;

using Microsoft.EntityFrameworkCore;


namespace Insta.BusinessLogic.Repositories
{
    public class ProfilesRepository
    {
        public void UpdateProfile(string userName, string password,ProfileRecord newProfile) {
            var encryptedPass = StringEncryptor.Encrypt(password);
            using
                (var context = new InstaContext())
            {
                ProfileRecord profile = context.ProfileRecords.FirstOrDefault(
                     n => n.UserName == userName && n.User.EncryptedPassword == encryptedPass);
                     if (profile != null)
                {
                    profile.Age = newProfile.Age;
                    profile.Description = newProfile.Description;
                    profile.FirstName = newProfile.FirstName;
                    profile.Gender = newProfile.Gender;
                    profile.IsVisible = newProfile.IsVisible;
                    profile.LastName = newProfile.LastName;
                    context.SaveChanges();


                     }

                
            }


        }
    }
}
