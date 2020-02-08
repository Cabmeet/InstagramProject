using System;
using System.Collections.Generic;
using System.Text;

namespace Insta.BusinessLogic.Repositories
{
    using System.Linq;

    using Insta.DataAccess.Context;

    public class UniqueTagsRepository
    {
        public bool FindUniqueTags(string tag)
        {
            using (var context = new InstaContext())
            { 
                var uniqueTag = context.UniqueTagRecords.FirstOrDefault(u => u.Text == tag);
                if (uniqueTag != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
    }
}
