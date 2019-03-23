using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace aspnetmvc.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Column]
        [StringLength(50)]
        [Required]
        public string Title { get; set; }
        [Column]
        public string Author { get; set; }
        [Column]
        public int Price { get; set; }
    }
}