using System;

namespace Inventory.Domain.SharedKernel
{
    public interface IEntity
    {
    }

    public interface IEntity<out TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; }
    }
}