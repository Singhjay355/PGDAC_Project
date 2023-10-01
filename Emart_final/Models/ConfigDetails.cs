using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emart_final.Models
{
    public class ConfigDetails
    {
        [Key]
        public int configDetailsID { get; set; }

        [Required]
        public int configID { get; set; }

        [Required]
        public string? configDetails { get; set; }

        [Required]
        public int prodID { get; set; }

        
        [ForeignKey("configID")]
        public Config? config { get; set; }

        [ForeignKey("prodID")]
        public Product? product { get; set; }
    }
}
