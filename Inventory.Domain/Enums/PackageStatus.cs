namespace Inventory.Domain.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public enum PackageStatus
    {
        /// <summary>
        /// 
        /// </summary>
        None,

        /// <summary>
        ///  Will be sent to the supplier
        /// </summary>
        Issue,

        /// <summary>
        /// Damaged package
        /// </summary>
        Damaged,

        /// <summary>
        /// The package is in reserve
        /// </summary>
        Reserved,

        /// <summary>
        /// The package Consign
        /// </summary>
        Consign,
        
        /// <summary>
        /// 
        /// </summary>
        Cross,

        /// <summary>
        /// The package can be sold
        /// </summary>
        Salable,

        /// <summary>
        /// The package is out
        /// </summary>
        Out
    }
}