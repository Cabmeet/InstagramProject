using System;
using System.Collections.Generic;
using System.Text;

namespace Insta.BusinessLogic.Repositories
{
    using System.Linq;

    using Insta.DataAccess.Context;

    class UsersRepository
    {
        public bool FindUser(string login, string password)
        {
            using (var context = new InstaContext())
            {
                var user = context.UserRecords.Where(n => n.Profile.UserName == "" && n.EncryptedPassword == "");
                    .FirstOrDefalt
            }

           
        }


    }
}
