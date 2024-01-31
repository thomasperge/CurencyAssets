using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencie
{
	public class RiskyPosition : PortfolioPosition, IRisk
	{
		public RiskyPosition(string name, double purchasePrice, double currentPrice, double quantity) : base(name, purchasePrice, currentPrice, quantity) { }

		public bool IsRisky
		{
			get { return CurrentPrice < PurchasePrice; }
		}
	}
}
