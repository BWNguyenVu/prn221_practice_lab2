using Microsoft.AspNetCore.Identity;

namespace BusinessObject
{
    public class Account : IdentityUser<string>
    {
        public string Name { get; set; }

        public ICollection<Flower> Flowers { get; set; } = new List<Flower>();
    }
}
