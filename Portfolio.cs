using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace CryptoCurrencie
{
	public class Portfolio : INotifyPropertyChanged
	{
		private ObservableCollection<PortfolioPosition> positions;
		public ObservableCollection<PortfolioPosition> Positions
		{
			get { return positions; }
			set
			{
				if (positions != value)
				{
					positions = value;
					UpdateChartValues();
					OnPropertyChanged(nameof(Positions));
					OnPropertyChanged(nameof(CalculateTotalInvestment));
					OnPropertyChanged(nameof(CalculateCurrentValue));
					OnPropertyChanged(nameof(IsPortfolioRisky));
					OnPropertyChanged(nameof(CaclulateTotalProfits));
					OnPropertyChanged(nameof(CaclulateTotalAssets));
					OnPropertyChanged(nameof(SeriesCollection));
				}
			}
		}

		private SeriesCollection seriesCollection;
		public SeriesCollection SeriesCollection
		{
			get { return seriesCollection; }
			set
			{
				if (seriesCollection != value)
				{
					seriesCollection = value;
					OnPropertyChanged(nameof(SeriesCollection));
				}
			}
		}

		public Portfolio()
		{
			positions = new ObservableCollection<PortfolioPosition>();
			positions.CollectionChanged += (sender, e) => UpdateChartValues();

			seriesCollection = new SeriesCollection
			{
				new ColumnSeries
				{
					Title = "Investments",
					Values = new ChartValues<double>(positions.Select(position => position.PurchasePrice))
				}
			};
		}

		public void AddPosition(PortfolioPosition position)
		{
			positions.Add(position);
			OnPropertyChanged(nameof(Positions));
			OnPropertyChanged(nameof(CalculateTotalInvestment));
			OnPropertyChanged(nameof(CalculateCurrentValue));
			OnPropertyChanged(nameof(IsPortfolioRisky));
			OnPropertyChanged(nameof(CaclulateTotalProfits));
			OnPropertyChanged(nameof(CaclulateTotalAssets));
			OnPropertyChanged(nameof(SeriesCollection));
		}

		private void UpdateChartValues()
		{
			Application.Current.Dispatcher.Invoke(() =>
			{
				// Mettez à jour la SeriesCollection
				SeriesCollection[0].Values = new ChartValues<double>(Positions.Select(position => position.PurchasePrice * position.Quantity));
			});
		}

		public double CalculateTotalInvestment
		{
			get { return positions.Sum(position => position.PurchasePrice * position.Quantity); }
		}

		public double CalculateCurrentValue
		{
			get { return positions.Sum(position => position.CurrentPrice); }
		}

		public double CaclulateTotalAssets
		{
			get { return positions.Sum(position => position.Quantity); }
		}

		public double CaclulateTotalProfits
		{
			get { return positions.Sum(position => position.ProfitLoss); }
		}

		public bool IsPortfolioRisky
		{
			get { return CalculateCurrentValue < CalculateTotalInvestment; }
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
