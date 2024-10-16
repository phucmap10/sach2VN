using System.ComponentModel.DataAnnotations;

namespace WebdotNet.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; } //if we set this as the 'classname'+'entity' this will be treated as primary key\
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}