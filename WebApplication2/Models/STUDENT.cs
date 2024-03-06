using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class STUDENT
    {
        [Key]
        public int COD_STUDENT { get; set; }

        [Required]
        [MaxLength(20)]
        public string IDENTIFICATION { get; set; }

        public string GENDER { get; set; }

        [Required]
        [MaxLength(50)]
        public string NAME { get; set; }

        [Required]
        [MaxLength(50)]
        public string LASTNAME { get; set; }

        public int COURSE { get; set; }
    }
}
