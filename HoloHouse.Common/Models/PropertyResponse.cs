using HoloHouse.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace HoloHouse.Common.Models
{
    public class PropertyResponse
    {
        public int Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Neighborhood { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public decimal Price { get; set; }

        public int SquareMeters { get; set; }

        public int Rooms { get; set; }

        public int Stratum { get; set; }

        public bool HasParkingLot { get; set; }

        public bool IsAvailable { get; set; }

        public string Remarks { get; set; }

        public string PropertyType { get; set; }

        public ICollection<PropertyImageResponse> PropertyImages { get; set; }

        public ICollection<ContractResponse> Contracts { get; set; }
        public string FirstImage
        {
            get
            {
                if (PropertyImages == null || PropertyImages.Count == 0)
                {
                    return "https://upload.wikimedia.org/wikipedia/commons/6/65/No-Image-Placeholder.svg";
                }

                return PropertyImages.FirstOrDefault().ImageUrl;
            }
        }
    }
}