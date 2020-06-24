using System;

namespace Inventory.Domain.SharedKernel
{
    /// <summary>
    /// DDD Entity base class'ı. DDD'de entity'ler property değerleri değil kimlikleriyle karşılaştırılmaktadır.
    /// Bu doğrultuda metodlar override edilmiştir.
    /// </summary>
    public class Entity<TKey> : IEntity<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; }

        protected Entity()
        {
        }

        protected Entity(TKey id) => Id = id;

        protected bool Equals(Entity<TKey> other) => Id.Equals(other.Id);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == this.GetType() && Equals((Entity<TKey>) obj);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}