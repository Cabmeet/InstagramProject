using System;
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
    public sealed class UsersRepository
    {
        public bool FindUser(string userName, string password)
        {
            var encryptedPass = StringEncryptor.Encrypt(password);
            using (var context = new InstaContext())
            {
                return context.UserRecords.Any(
                    n => n.Profile.UserName == userName && n.EncryptedPassword == encryptedPass);
          


            }


        }
        public UserRecord GetUser(string userName,string password) {
            var encryptedPass = StringEncryptor.Encrypt(password);
            using (var context = new InstaContext()) 
            { return context.UserRecords.FirstOrDefault(
                n => n.Profile.UserName == userName && n.EncryptedPassword == encryptedPass); } }

        public void DeleteUser(string userName, string password) {
            var encryptedPass = StringEncryptor.Encrypt(password);
            using (var context = new InstaContext()) {
                UserRecord user = context.UserRecords.FirstOrDefault(
                    n => n.Profile.UserName == userName && n.EncryptedPassword == encryptedPass);
                    if ( user!= null)
                {
                  
                    context.UserRecords.Remove(user);
                    context.SaveChanges();

                       
                }
                
            }
        }
       

    }
}
