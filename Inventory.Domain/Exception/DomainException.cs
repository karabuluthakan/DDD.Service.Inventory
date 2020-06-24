namespace Inventory.Domain.Exception
{
    public class DomainException : System.Exception
    {
        public DomainException(string message, System.Exception exception) : base(message, exception)
        {
        }
    }
}