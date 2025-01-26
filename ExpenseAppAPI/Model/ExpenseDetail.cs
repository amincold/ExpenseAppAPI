using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ExpenseAppAPI.Model
{
    public class ExpenseDetail
    {
 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public int Expensetype { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        [MaxLength(100)]
        public string? PurposeOfExpense { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ModifyDate { get; set; }
        [MaxLength(50)]
        public string? ModifiedBy { get; set; }
        [MaxLength(50)]
        public string? CreateBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
