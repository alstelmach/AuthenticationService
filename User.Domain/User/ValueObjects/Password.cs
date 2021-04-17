using System.Collections.Generic;
using AsCore.Domain.Abstractions.BuildingBlocks;

namespace User.Domain.User.ValueObjects
{
    public class Password : ValueObject
    {
        public Password(string password) =>
            Content = password;

        public string Content { get; }

        protected override IEnumerable<object> GetEqualityComponents() =>
            new[] { Content };
    }
}
