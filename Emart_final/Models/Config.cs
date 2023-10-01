using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emart_final.Models
{
    public class Config
    {
        [Key]
        public int ConfigID { get; set; }

        [Required]
        public string? configname { get; set; }

        public ICollection<ConfigDetails>? configDetails { get; set;}



    }
}
