using System.ComponentModel.DataAnnotations;

namespace HoloHouse.Common.Models
{
    public class EmailRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}