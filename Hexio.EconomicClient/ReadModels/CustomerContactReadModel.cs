using System.Collections.Generic;
using Hexio.EconomicClient.CreateModels;

namespace Hexio.EconomicClient.ReadModels
{
    public class CustomerContactReadModel
    {
        public int CustomerContactNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Customer Customer { get; set; }
        public List<string> EmailNotifications { get; set; }
    }
}