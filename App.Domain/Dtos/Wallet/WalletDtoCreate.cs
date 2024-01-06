using System.ComponentModel.DataAnnotations;

namespace App.Domain.Dtos.Wallet
{
    public class WalletDtoCreate
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100, ErrorMessage = "O campo {0} não deve ter mais do que {1} caracteres")]
        public string Description { get; set; }

        public bool Default { get; set; }
    }
}