#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace ChefNDishes.Models;


public class Chef
{
    [Key]

    public int ChefId { get; set; }

    [Required(ErrorMessage ="is required")]
    [Display(Name ="First Name")]
    public string FirstName { get; set; }

    [Required(ErrorMessage ="is required")]
    [Display(Name ="Last Name")]
    public string LastName { get; set; }

    [Required(ErrorMessage ="is required")]
    [Display(Name ="Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime Age { get; set; } 

    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish> CreatedDishes { get; set; } =  new List<Dish>();



}