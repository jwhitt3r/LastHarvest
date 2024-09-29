using Util;

namespace Economy
{
    public interface IEconomy
    {
        public bool CanAfford(MaterialCost materialCost);
        
        public Result<TransactionError> Purchase(MaterialCost materialCost);
    }
}