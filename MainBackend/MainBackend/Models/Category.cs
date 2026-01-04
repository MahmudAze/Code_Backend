using System.ComponentModel.DataAnnotations;

namespace MainBackend.Models
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage ="Bosh ola bilmez")]
        public string Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
