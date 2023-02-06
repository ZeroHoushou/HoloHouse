using HoloHouse.Web.Data.Entities;

namespace HoloHouse.Web.Data.Entities
{
    public class Manager
    {
        public int Id { get; set; }

        public User User { get; set; }
    }
}
