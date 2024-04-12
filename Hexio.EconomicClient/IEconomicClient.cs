using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Hexio.EconomicClient.CreateModels;
using Hexio.EconomicClient.ReadModels;
using RestEase;
using PaymentTerms = Hexio.EconomicClient.CreateModels.PaymentTerms;

namespace Hexio.EconomicClient
{
    public interface IEconomicClient
    {
        [Header("X-AppSecretToken")]
        string AppSecretToken { get; set; }
        
        [Header("X-AgreementGrantToken")]
        string AgreementGrantToken { get; set; }

        [Get("self")]
        Task<SelfReadModel> Self();

        [Get("accounting-years")]
        Task<ResponseCollection<AccountingYearReadModel>> GetAccountingYears();

        [Get("customers")]
        Task<ResponseCollection<CustomerReadModel>> ListCustomers([RawQueryString] QueryFilter<CustomerReadModel> filter = null);

        [Get("customers/{customerNumber}")]
        Task<CustomerReadModel> GetCustomerByCustomerNumber([Path] long customerNumber);

        [Post("customers")]
        Task<CustomerReadModel> CreateCustomer([Body] CreateCustomerModel createCustomerModel);
        
        [Put("customers/{customerNumber}")]
        Task<CustomerReadModel> UpdateCustomer([Path] long customerNumber, [Body] CreateCustomerModel createCustomerModel);

        [Delete("customers/{customerNumber}")]
        Task DeleteCustomer([Path] long customerNumber);

        [Get("customers/{customerNumber}/contacts")]
        Task<ResponseCollection<CustomerContactReadModel>> GetCustomerContacts([Path] long customerNumber);
        
        [Post("customers/{customerNumber}/contacts")]
        Task<CustomerContactReadModel> CreateCustomerContact([Path] long customerNumber, [Body] CreateCustomerContact createCustomerContactModel);
        
        [Put("customers/{customerNumber}/contacts/{contactNumber}")]
        Task<CustomerContactReadModel> UpdateCustomerContact([Path] long customerNumber, [Path] long contactNumber, [Body] CreateCustomerContact model);
        
        [Get("suppliers")]
        Task<ResponseCollection<SupplierReadModel>> ListSuppliers([RawQueryString] QueryFilter<SupplierReadModel> filter = null);
        
        [Get("suppliers/{supplierNumber}")]
        [AllowAnyStatusCode]
        Task<Response<SupplierReadModel>> GetSupplierByNumber([Path] long supplierNumber);
        
        [Post("suppliers")]
        Task<SupplierReadModel> CreateSupplier([Body] CreateSupplierModel createSupplierModel);

        [Get("invoices/{invoiceStatus}")]
        Task<ResponseCollection<BookedInvoiceReadModel>> ListBookedInvoices([Path] InvoiceStatus invoiceStatus,
            [RawQueryString] QueryFilter<BookedInvoiceReadModel> queryFilter = null); 

        [Post("invoices/drafts")]
        Task<InvoiceReadModel> CreateInvoice([Body] CreateInvoiceModel createInvoiceModel);

        [Post("invoices/booked")]
        Task<BookedInvoiceReadModel> BookInvoice([Body] BookInvoiceModel bookInvoiceModel);

        [Get("{url}")]
        Task<Stream> GetPdf([Path(UrlEncode = false)] string url); 

        [Post("journals-experimental/{journalNumber}/vouchers")]
        Task<List<JournalReadModel>> CreateJournal([Path] int? journalNumber, [Body] CreateJournalModel model);

        [Post("journals-experimental/{journalNumber}/vouchers/{accountingYear}-{voucherNumber}/attachment/file")]
        Task UploadFileToJorunal([Path] long journalNumber, [Path] string accountingYear, [Path] long voucherNumber, [Body] HttpContent content);
            
        [Delete("invoices/drafts/{draftInvoiceNumber}")]
        Task DeleteInvoiceDraft([Path] long draftInvoiceNumber);

        /*
        [Post("quotes/drafts")]
        Task<QuoteReadModel> CreateQoute([Body] CreateQoute model);

        [Post("quotes/sent")]
        Task<QuoteReadModel> MarkQuoteAsSend([Body] MarkQuoteAsSendModel model);
        */

        [Get("products")]
        Task<ResponseCollection<ProductReadModel>> GetProducts([RawQueryString] QueryFilter<ProductReadModel> filter = null);

        [Get("products/{productNumber}")]
        Task<ProductReadModel> GetProduct([Path] string productNumber);
        
        [Get("layouts")]
        Task<ResponseCollection<LayoutModel>> GetLayouts();
        
        [Get("payment-terms")]
        Task<ResponseCollection<PaymentTerms>> GetPaymentTerms();
    }
    
    public static class EconomicClientExtensions
    {
        public static async Task SetAuthenticationHeadersAndTestLogin(this IEconomicClient client, string agreementGrantToken)
        {
            client.AgreementGrantToken = agreementGrantToken;
            
            await client.Self();
        }

        public static async Task UploadFile(this IEconomicClient client, Stream stream, string fileName, long journalNumber, string accountingYear, long voucherNumner)
        {
            var content = new MultipartFormDataContent();

            if (stream.CanSeek)
            {
                stream.Seek(0, SeekOrigin.Begin);
            }

            var fileContent = new StreamContent(stream);
            
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = fileName,
                FileName = fileName,
            };
            
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            
            content.Add(fileContent);

            await client.UploadFileToJorunal(journalNumber, accountingYear, voucherNumner, content);
        }
    }
}