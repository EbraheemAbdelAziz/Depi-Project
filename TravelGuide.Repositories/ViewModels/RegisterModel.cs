using System.ComponentModel.DataAnnotations;

namespace TravelGuide.Repositories.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Username is reqired")]
        [StringLength(256)]
        [Display(Name ="User Name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email is reqired")]
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is reqired")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
		[Required(ErrorMessage = "Confirm Password is reqired")]
		[Compare("Password",ErrorMessage = "Dosen't match the password")]
        public string ConfirmPassword { get; set; }


    }
}
