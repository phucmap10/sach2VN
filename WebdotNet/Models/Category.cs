using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebdotNet.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; } //if we set this as the 'classname'+'entity' this will be treated as primary key\
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public required string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage ="The DisplayOrder must between 1 and 100")]
        public int DisplayOrder { get; set; }
    }
}