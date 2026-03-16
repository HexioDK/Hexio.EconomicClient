namespace Hexio.EconomicClient.CreateModels
{
    public class CreateCustomerContact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class UpdateCustomerContact : CreateCustomerContact
    {
        public int CustomerContactNumber { get; set; }
    }
}