using System.ComponentModel.DataAnnotations;

namespace MicroServicesNet5.Web.Models
{
    public class SignInput
    {
        [Display(Name = "Email adresiniz")]
        public string Email { get; set; }

        [Display(Name = "Şifreniz")]
        public string Password { get; set; }

        [Display(Name = "Beni hatırla")]
        public bool IsRemember { get; set; }
    }
}
