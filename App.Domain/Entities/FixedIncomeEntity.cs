using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class FixedIncomeEntity : BaseEntity
    {
        [Required]
        public int WalletId { get; set; }

        public WalletEntity Wallet { get; set; }

        [Required, MaxLength(150)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }

        [Required, DataType(DataType.Currency)]
        public double ValueInitial { get; set; }
    }
}