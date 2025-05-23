﻿using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    //Model class mapped to the DB which stores Order Info placed by Users
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Image_url { get; set; }
        [Required]
        public string? Publisher { get; set; }
        [Required]
        public string? Title { get; set; }

        public string? UserId { get; set; }

        public string? RecipeId {  get; set; }  
    }
}
