﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BulkyWebRazor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "The field Display Order must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
