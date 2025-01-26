using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExpenseAppAPI.Model
{
    public class CDNPerson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Username { get; set; }

        [MaxLength(50)]
        public string? Email { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? PhoneNumber { get; set; }

        public int? archieve { get; set; }
    }
}
