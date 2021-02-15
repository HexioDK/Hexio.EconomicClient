using System.Collections.Generic;
using Hexio.EconomicClient.ReadModels;

namespace Hexio.EconomicClient.CreateModels
{
    public class CreateQoute
    {
        public string Currency { get; set; } = "DKK";
        public Customer Customer { get; set; }
        public string Date { get; set; }
        public Layout Layout { get; set; }
        public PaymentTerms PaymentTerms { get; set; }
        public string Duedate { get; set; }
        public Recipient Recipient { get; set; }
        public List<Line> Lines { get; set; }
        public Notes Notes { get; set; }
    }
}