using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseAppAPI.Model
{
    public class Expense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Username { get; set; }
        public int? ChangeRequestID { get; set; }
        public int? Role { get; set; }
        [MaxLength(200)]
        public string? Notes { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ModifyDate { get; set; }
        [MaxLength(50)]
        public string? ModifiedBy { get; set; }
        [MaxLength(50)]
        public string? CreateBy { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalAmount { get; set; }
        [MaxLength(5)]
        public string? CurrencyType { get; set; }
    }
}
