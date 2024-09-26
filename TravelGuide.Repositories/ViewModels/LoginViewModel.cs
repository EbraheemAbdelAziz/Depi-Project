using System.ComponentModel.DataAnnotations;

namespace TravelGuide.Repositories.ViewModels
{
	public class LoginViewModel
    {
		[Required(ErrorMessage = "Username is reqired")]
		[StringLength(256)]
		[Display(Name = "User Name")]
		public string Username { get; set; }
		[Required(ErrorMessage = "Password is reqired")]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }
		[Display(Name = "Remember me")]
		public bool Remmeberme { get; set; }

    }
}
