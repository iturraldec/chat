using System.ComponentModel.DataAnnotations;
namespace ChatWeb.Models.ViewModels;

public class RegisterViewModel
{
  [Required]
  [StringLength(50)]
  [Display(Name="Nombre")]
  public string Name {get; set;} = null!;

  [Required]
  [EmailAddress]
  [StringLength(50)]
  [Display(Name="Correo electrónico")]
  public string Email {get; set;} = null!;
  
  [Required]
  [StringLength(20)]
  public string Password {get; set;} = null!;
  
  [Compare("Password")]
  [Display(Name="Confirma password")]
  public string Password2 {get; set;} = null!;
}