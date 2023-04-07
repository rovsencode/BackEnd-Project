using System.ComponentModel.DataAnnotations;

namespace BackEndProject.ViewModels.AccountVM
{
    public class ForgotPasswordVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
