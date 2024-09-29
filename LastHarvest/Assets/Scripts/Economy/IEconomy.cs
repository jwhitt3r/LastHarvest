using Util;

namespace Economy
{
    public interface IEconomy
    {
        /// <summary>
        /// Determines if the economy has sufficient resources to cover the specified material cost.
        /// </summary>
        /// <param name="materialCost">The cost in materials to check affordability for.</param>
        /// <returns>
        /// Returns true if there are enough resources to cover the material cost; otherwise, false.
        /// </returns>
        public bool CanAfford(MaterialCost materialCost);

        /// <summary>
        /// Attempts to process a purchase by deducting the specified resource costs from the economy.
        /// </summary>
        /// <param name="materialCost">The cost in materials that need to be deducted for the purchase.</param>
        /// <returns>
        /// Returns a Result object indicating success or the specific type of TransactionError if the purchase fails.
        /// </returns>
        public Result<TransactionError> Purchase(MaterialCost materialCost);
    }
}