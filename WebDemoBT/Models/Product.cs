using System.ComponentModel.DataAnnotations;

namespace WebDemoBT.Models
{
    public class Product
    {
        [Display(Name ="Mã sản phẩm")]
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Loại sản phẩm")]
        public string Description { get; set; }

        [Display(Name = "Giá sản phẩm")]
        public decimal Price { get; set; }
    }
}
