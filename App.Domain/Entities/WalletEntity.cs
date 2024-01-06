using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class WalletEntity : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        public UserEntity User { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public bool Default { get; set; }
    }
}