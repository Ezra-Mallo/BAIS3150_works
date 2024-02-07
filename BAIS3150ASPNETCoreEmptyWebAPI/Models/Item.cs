using System.Runtime.CompilerServices;

namespace BAIS3150ASPNETCoreEmptyWebAPI.Models
{
    public class Item
    {
        public int ItemNumber { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal UnitPrice{ get; set; } 
    }
}
