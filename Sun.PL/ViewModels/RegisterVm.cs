using System.ComponentModel.DataAnnotations;
using Sun.PL.Areas.Identity.Pages.Account;
namespace Sun.PL.ViewModels
{
    public class RegisterVm
	{
        [Required(ErrorMessage ="user name is required")]
        public string UserName { get; set; }

		[Required(ErrorMessage = "email is required")]
        [MinLength(5)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

		[Required(ErrorMessage = "password is required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "confirm password is required")]
		[DataType(DataType.Password)]
        [Compare(nameof(Password))]
		public string ConfirmedPassword { get; set; }

		[Required(ErrorMessage = "agree is required")]
		public bool Agree {  get; set; }
    }
}
