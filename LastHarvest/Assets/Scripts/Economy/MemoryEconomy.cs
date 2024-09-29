using Util;

namespace Economy
{
    /// <summary>
    /// An in memory implementation of IEconomy.
    /// </summary>
    public class MemoryEconomy : IEconomy
    {
        public int Wood { get; private set; } = 500;

        public int Scrap { get; private set; } = 500;
        
        public bool CanAfford(MaterialCost materialCost)
        {
            return materialCost.Wood <= Wood && materialCost.Scrap <= Scrap;
        }

        public Result<TransactionError> Purchase(MaterialCost materialCost)
        {
            if (CanAfford(materialCost))
            {
                Wood -= materialCost.Wood;
                Scrap -= materialCost.Scrap;
                return Result<TransactionError>.Ok();
            }

            if (materialCost.Scrap > Scrap && materialCost.Wood > Wood)
            {
                return TransactionError.InsufficientMaterials;
            }

            return materialCost.Wood > Wood ? TransactionError.InsufficientWood : TransactionError.InsufficientScrap;
        }
    }
}