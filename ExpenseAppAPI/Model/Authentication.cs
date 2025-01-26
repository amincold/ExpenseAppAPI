using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseAppAPI.Model
{
    public class Authentication
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [MaxLength(100)]
        public required string? Username { get; set; }

        [MaxLength(50)]
        public required string? Password { get; set; }

        [MaxLength(50)]
        public string? Role { get; set; }
        public bool IsAuthenticated { get; set; }
        [MaxLength(50)]
        public string? Manager_Username { get; set; }
        [Column(TypeName ="datetime2")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ModifyDate { get; set;}
        [MaxLength(50)]
        public string? ModifiedBy { get; set; }
        [MaxLength(50)]
        public string? CreateBy {  get; set; }
        public bool IsDeleted { get; set; }
    }
}
