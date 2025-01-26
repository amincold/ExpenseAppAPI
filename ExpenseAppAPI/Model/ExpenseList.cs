using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseAppAPI.Model
{
    public class ExpenseList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ExpenseName { get; set; }
        
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
