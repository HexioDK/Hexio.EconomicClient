using Hexio.EconomicClient.ReadModels;

namespace Hexio.EconomicClient.CreateModels
{
    public class CreateCustomerModel
    {
        public long? CustomerNumber { get; set; }
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string Zip { get; set; } = "";
        public string CorporateIdentificationNumber { get; set; } = "";
        public string Country { get; set; } = "Denmark";
        public string Ean { get; set; }
        public string Email { get; set; } = "";
        public string MobilePhone { get; set; } = "";
        public string Name { get; set; } = "";
        public string TelephoneAndFaxNumber { get; set; } = "";
        public string Currency { get; set; } = "DKK";
        public CustomerGroup CustomerGroup { get; set; } = new CustomerGroup();
        public VatZone VatZone { get; set; } = new VatZone();
        public PaymentTerms PaymentTerms { get; set; } = new PaymentTerms();
    }

    public class CustomerGroup
    {
        public long? CustomerGroupNumber { get; set; } = 1;
    }

    public class PaymentTerms
    {
        public long? PaymentTermsNumber { get; set; } = 1;
        public string Name { get; set; }
    }
}