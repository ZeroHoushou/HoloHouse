using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using HoloHouse.Web.Data.Entities;

namespace HoloHouse.Web.Models
{
    public class PropertyImageViewModel : PropertyImage
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
