using System.ComponentModel.DataAnnotations;

namespace Bilet10.ViewModels.AppUserViewModel
{
    public class Register
    {
        [Required,StringLength(maximumLength:100)]
        public string UserName { get; set; }
        [Required, StringLength(maximumLength: 100)]
        public string FullName { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required,DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        [Required,Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
