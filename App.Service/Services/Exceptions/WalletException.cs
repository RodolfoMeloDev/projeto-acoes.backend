namespace App.Service.Services.Exceptions
{
    public class WalletException : ApplicationException
    {
        public WalletException(string? message) : base(message)
        {
        }
    }
}