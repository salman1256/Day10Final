using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PassportAPI.Models
{
    [Table("Passport")]
    public class Passport
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string HolderName { get; set; }
        [Required]
        [StringLength(10)]
        public string PassportNumber { get; set; }
        //12/23
        [Required]
        [StringLength(5)]
        public string Expiry { get; set; }
        [Required]
        [StringLength(6)]
        public string POCode { get; set; }
    }
}
