using System;

using Insta.BusinessLogic.Enums;

namespace Insta.BusinessLogic.Entities
{
    public sealed class UserEntity
    {
        public int Age { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public Gender Gender { get; set; }

        public Guid Id { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
    }
}