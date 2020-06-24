using System;
using System.Collections.Generic;
using Inventory.Domain.Exception;
using Inventory.Domain.SharedKernel;

namespace Inventory.Domain.ValueObjects
{
    public class UserSummary : ValueObject<UserSummary>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        private UserSummary()
        {
        }

        public UserSummary(Guid id, string name, string email)
        {
            if (id == Guid.Empty)
            {
                throw new DomainException($"{nameof(UserSummary)}-{nameof(id)}", new ArgumentNullException());
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new DomainException($"{nameof(UserSummary)}-{nameof(name)}", new ArgumentNullException());
            }

            if (string.IsNullOrEmpty(email))
            {
                throw new DomainException($"{nameof(UserSummary)}-{nameof(email)}", new ArgumentNullException());
            }

            this.Id = id;
            this.Name = name;
            this.Email = email;
        }

        protected override IEnumerable<object> PropertiesToCheckForEquality() => new object[] {Id, Name, Email};
    }
}