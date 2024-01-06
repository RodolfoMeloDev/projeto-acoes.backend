using System.ComponentModel.DataAnnotations;

namespace App.Domain.Dtos.Wallet
{
    public class WalletDtoUpdate
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Description { get; set; }

        public bool? Default { get; set; }
    }
}