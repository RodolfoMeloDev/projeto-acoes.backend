using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class HistoryFixedIncomeEntity : BaseEntity
    {
        [Required]
        public int FixedIncomeId { get; set; }
        public FixedIncomeEntity FixedIncome { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime HistoryDate { get; set; }

        [Required, DataType(DataType.Currency)]
        public double ValueActual { get; set; }
    }
}