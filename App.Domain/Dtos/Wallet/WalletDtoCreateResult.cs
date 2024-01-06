namespace App.Domain.Dtos.Wallet
{
    public class WalletDtoCreateResult : BaseCreateDtoResult
    {
        public int UserID { get; set; }
        public string Description { get; set; }
        public bool Default { get; set; }
    }
}