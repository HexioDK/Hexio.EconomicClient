using System;
using System.Collections.Generic;
using Hexio.EconomicClient.CreateModels;

namespace Hexio.EconomicClient.ReadModels
{
    public class InvoiceReadModel
    {
        public long DraftInvoiceNumber { get; set; }
        public Soap Soap { get; set; }
        public Templates Templates { get; set; }
        public List<Line> Lines { get; set; }
        public DateTimeOffset? Date { get; set; }
        public string Currency { get; set; }
        public long? ExchangeRate { get; set; }
        public long? NetAmount { get; set; }
        public long? NetAmountInBaseCurrency { get; set; }
        public long? GrossAmount { get; set; }
        public long? GrossAmountInBaseCurrency { get; set; }
        public long? MarginInBaseCurrency { get; set; }
        public long? MarginPercentage { get; set; }
        public long? VatAmount { get; set; }
        public long? RoundingAmount { get; set; }
        public long? CostPriceInBaseCurrency { get; set; }
        public DateTimeOffset? DueDate { get; set; }
        public CreateModels.PaymentTerms PaymentTerms { get; set; }
        public Customer Customer { get; set; }
        public Recipient Recipient { get; set; }
        public References References { get; set; }
        public Layout Layout { get; set; }
        public Pdf Pdf { get; set; }
        public Uri Self { get; set; }
    }

    public class Layout
    {
        public long? LayoutNumber { get; set; }
        public Uri Self { get; set; }
    }

    public class Line
    {
        public long? LineNumber { get; set; }
        public long? SortKey { get; set; }
        public Unit Unit { get; set; }
        public Product Product { get; set; }
        public long? Quantity { get; set; }
        public long? UnitNetPrice { get; set; }
        public long? DiscountPercentage { get; set; }
        public long? UnitCostPrice { get; set; }
        public long? TotalNetAmount { get; set; }
        public long? MarginInBaseCurrency { get; set; }
        public long? MarginPercentage { get; set; }
    }

    public class Product
    {
        public string ProductNumber { get; set; }
        public Uri Self { get; set; }
    }

    public class Unit
    {
        public long? UnitNumber { get; set; }
        public string Name { get; set; }
        public Uri Products { get; set; }
        public Uri Self { get; set; }
    }

    public class Pdf
    {
        public Uri Download { get; set; }
    }

    public class Recipient
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public VatZone VatZone { get; set; }
        public Attention Attention { get; set; }
        public string Ean { get; set; }
    }

    public class Delivery
    {
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
    }

    public class Attention
    {
        public Attention(long customerContactNumber)
        {
            CustomerContactNumber = customerContactNumber;
        }
        
        public long CustomerContactNumber { get; set; }
    }

    public class References
    {
        public string Other { get; set; }
    }

    public class Soap
    {
        public CurrentInvoiceHandle CurrentInvoiceHandle { get; set; }
    }

    public class CurrentInvoiceHandle
    {
        public long? Id { get; set; }
    }
}