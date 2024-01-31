using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrencie
{
	public class PortfolioChartViewModel
	{
		public SeriesCollection SeriesCollection { get; set; }

		public PortfolioChartViewModel()
		{
			SeriesCollection = new SeriesCollection();
		}
	}
}
