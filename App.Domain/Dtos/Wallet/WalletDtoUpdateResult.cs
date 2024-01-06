namespace App.Domain.Dtos.Wallet
{
    public class WalletDtoUpdateResult : BaseUpdateDtoResult
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public bool Default { get; set; }
    }
}