#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace ChefNDishes.Models;


public class Dish
{

    [Key]
    public int DishId { get; set; }

    [Required(ErrorMessage ="Is required")]
    [Display(Name = "Name's of Dish" )]
    public string Name { get; set; }

    [Required(ErrorMessage ="Is required")]
    [Range(1,int.MaxValue,ErrorMessage ="Calorie mus be at leaste 1")]
    [Display(Name = "# of Calories" )]
    public int Calories { get; set; }

    [Required(ErrorMessage ="Is required")]
    [Display(Name = "Description" )]
    public string Description { get; set; }

    [Required(ErrorMessage ="Is required")]
    [Range(1,5,ErrorMessage ="Tastiness mus be at leaste 1")]
    [Display(Name = "Tastiness" )]
    public int Tastiness { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [Display(Name="Chef Name: ")]
    public int ChefId  { get; set; }

    public Chef? Creator { get; set; }
}