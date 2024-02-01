using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencie
{
	public class AnnualReturnStrategy : IReturnCalculationStrategy
	{
		public double CalculateReturns(List<PortfolioPosition> positions)
		{
			return 0.2;
		}
	}
}
