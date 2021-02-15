using System;
using System.Collections.Generic;
using Hexio.EconomicClient.CreateModels;

namespace Hexio.EconomicClient.ReadModels
{
    public class BookedInvoiceReadModel : IReadModel
    {
        public long BookedInvoiceNumber { get; set; }
        public DateTimeOffset? Date { get; set; }
        public string Currency { get; set; }
        public long? ExchangeRate { get; set; }
        public long? NetAmount { get; set; }
        public long? NetAmountInBaseCurrency { get; set; }
        public long? GrossAmount { get; set; }
        public long? GrossAmountInBaseCurrency { get; set; }
        public long? VatAmount { get; set; }
        public long? RoundingAmount { get; set; }
        public long? Remainder { get; set; }
        public long? RemainderInBaseCurrency { get; set; }
        public DateTimeOffset? DueDate { get; set; }
        public PaymentTerms PaymentTerms { get; set; }
        public Customer Customer { get; set; }
        public Recipient Recipient { get; set; }
        public References References { get; set; }
        public Layout Layout { get; set; }
        public Pdf Pdf { get; set; }
        public List<CreateModels.Line> Lines { get; set; }
        public Uri Sent { get; set; }
        public Uri Self { get; set; }
        public IList<string> FieldsToFilter { get; } = new List<string>
        {
            "bookedinvoicenumber"
        };
    }
}