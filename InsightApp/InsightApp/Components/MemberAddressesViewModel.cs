using InsightApp.Entities;

namespace InsightApp.Components
{
    public class MemberAddressesViewModel
    {
        public int MemberId { get; set; }
        public bool IsAdressesSame { get; set; }
        public AddressTable MemberAddress { get; set; }
        public AddressTable ShippingAddress { get; set; }
    }
}
