using System.ComponentModel.DataAnnotations;
namespace ChatWeb.Models.ViewModels;

public class UserAccessViewModel
{
  [Required]
  [EmailAddress]
  [StringLength(50)]
  [Display(Name="Correo electrónico")]
  public string Email {get; set;} = null!;
  
  [Required]
  [StringLength(20)]
  public string Password {get; set;} = null!;
}