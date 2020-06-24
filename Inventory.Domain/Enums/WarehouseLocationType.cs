namespace Inventory.Domain.Enums
{
    public enum WarehouseLocationType
    {
        /// <summary>
        /// To be used for shelf to shelf transport
        /// </summary>
        Shelf,

        /// <summary>
        /// To be used for those who will be taken to the collection area
        /// </summary>
        CollectionArea,

        /// <summary>
        /// In transit
        /// </summary>
        Transportation
    }
}