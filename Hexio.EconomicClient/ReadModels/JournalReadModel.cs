using Hexio.EconomicClient.CreateModels;

namespace Hexio.EconomicClient.ReadModels
{
    public class JournalReadModel
    {
        public Entries Entries { get; set; }
        public AccountingYear AccountingYear { get; set; }
        public long VoucherNumber { get; set; }
    }
}