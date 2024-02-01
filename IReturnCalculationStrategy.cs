using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencie
{
	public interface IReturnCalculationStrategy
	{
		double CalculateReturns(List<PortfolioPosition> positions);
	}
}
