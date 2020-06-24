namespace Inventory.Domain.Enums
{
    /// <summary>
    /// For movement type enum
    /// </summary>
    public enum MovementType
    {
        /// <summary>
        /// Entry into the warehouse
        /// </summary>
        Receipt,
        
        /// <summary>
        /// Exiting the warehouse
        /// </summary>
        Exit,
        
        /// <summary>
        /// In-warehouse transfer
        /// </summary>
        InWarehouseTransfer
    }
}