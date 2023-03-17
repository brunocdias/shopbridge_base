using System.ComponentModel.DataAnnotations;

namespace Shopbridge_base.Infrastructure.Models
{
    public class ProductModel
    {
        [Key]
        public int Product_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
