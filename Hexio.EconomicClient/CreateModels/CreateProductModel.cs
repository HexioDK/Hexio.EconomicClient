using Hexio.EconomicClient.ReadModels;

namespace Hexio.EconomicClient.CreateModels
{
    public class CreateProductModel
    {
        public string ProductNumber { get; set; }
        public string Name { get; set; }
        public bool Barred { get; set; }
        public ProductGroupReadModel ProductGroup { get; set; }
    }
}