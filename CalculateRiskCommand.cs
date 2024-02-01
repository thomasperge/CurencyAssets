namespace CryptoCurrencie
{
	public class CalculateRiskCommand : ICommand
	{
		private readonly PortfolioPosition _position;

		public CalculateRiskCommand(PortfolioPosition position)
		{
			_position = position;
		}

		// Calculer le risque
		public void Execute()
		{
			double priceDifferencePercentage = (_position.CurrentPrice - _position.PurchasePrice) / _position.PurchasePrice * 100;

			_position.IsRisky = priceDifferencePercentage >= 9;
		}
	}
}
