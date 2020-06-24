using System;
using System.Threading.Tasks;
using Inventory.Domain;
using Medallion.Threading.Sql;

namespace Inventory.Infrastructure.DistributedLockConfigurations
{
    public class SqlDistributedLockManager : IDistributedLockService
    {
        private readonly string _connectionString;

        public SqlDistributedLockManager(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public void Lock(string key, Action action)
        {
            var locked = new SqlDistributedLock(key, _connectionString);
            using (locked.Acquire())
            {
                action();
            }
        }

        public async Task LockAsync(string key, Func<Task> action)
        {
            var locked = new SqlDistributedLock(key, _connectionString);
            using (await locked.AcquireAsync())
            {
                await action();
            }
        }
    }
}