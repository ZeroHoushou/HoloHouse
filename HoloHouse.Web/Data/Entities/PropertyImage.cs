using System.ComponentModel.DataAnnotations;

namespace HoloHouse.Web.Data.Entities
{
    public class PropertyImage
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        // TODO: Change the path when publish
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? null
            //: $"https://myleasing.azurewebsites.net{ImageUrl.Substring(1)}";
            : $"https://www.svgrepo.com/show/904/photo-camera.svg";
        public Property Property { get; set; }
    }
}