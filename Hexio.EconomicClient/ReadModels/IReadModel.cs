using System.Collections.Generic;

namespace Hexio.EconomicClient.ReadModels
{
    public interface IReadModel
    {
        IList<string> FieldsToFilter { get; }
    }
}