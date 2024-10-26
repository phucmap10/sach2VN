using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebdotNet.Models
{
    public class Products
    {
        [Key]
        public int ID { get; set; } //if we set this as the 'classname'+'entity' this will be treated as primary key\
        [Required]
        [DisplayName("Book Title")]
        [MaxLength(30)]
        public required string Title { get; set; }
        public string Description { get; set; }
        [DisplayName("Author")]
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        [Display(Name = "List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }
        [Required]
        [Display(Name = "Category Name")]

        public string Category { get; set; }

        

    }   
}
