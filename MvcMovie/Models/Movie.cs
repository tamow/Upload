using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Display(Name = "タイトル")]
        [Required(ErrorMessage = "タイトルは必須です。")] 
        public string Title { get; set; }
        [Display(Name = "リリース日")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "ジャンル")]
        public string Genre { get; set; }
        [Display(Name = "価格")]
        public decimal Price { get; set; }
        [Display(Name = "評価")]
        public string Rating { get; set; }
    }
}