using System;
using System.Threading.Tasks;

namespace Inventory.Domain
{
    public interface IDistributedLockService
    {
        void Lock(string key, Action action);
        Task LockAsync(string key, Func<Task> action);
    }
}