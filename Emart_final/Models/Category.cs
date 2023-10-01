using System.ComponentModel.DataAnnotations;
namespace Emart_final.Models
{
    public class Category
    {
        [Key]
        public int catmasterID { get; set; }

        public string? categoryName { get; set; }

        public bool childflag {  get; set; }

        public int parentCatID { get; set; }
        public string? catImgPath { get; set; }

       public ICollection<Product>? product { get; set; }




    }
}
