using Hexio.EconomicClient.CreateModels;

namespace Hexio.EconomicClient.ReadModels
{
    public class CustomerContactReadModel
    {
        public int CustomerContactNumber { get; set; }
        public string Name { get; set; }
        public Customer Customer { get; set; }
    }
}