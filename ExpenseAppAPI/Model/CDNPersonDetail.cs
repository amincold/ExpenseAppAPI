using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExpenseAppAPI.Model
{
    public class CDNPersonDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int cdnpersonid { get; set; }
        [MaxLength(200)]
        public string? SkillSet { get; set; }
        [MaxLength(200)]
        public string? hobbies { get; set; }
    }
}
