using System.ComponentModel.DataAnnotations;

namespace HoloHouse.Web.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
