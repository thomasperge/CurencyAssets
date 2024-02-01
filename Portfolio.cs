using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace CryptoCurrencie
{
	public class Portfolio: INotifyPropertyChanged
	{
		private ObservableCollection<PortfolioPosition> positions;
		private List<IObserver> observers;

		public ObservableCollection<PortfolioPosition> Positions
		{
			get { return positions; }
			set
			{
				if (positions != value)
				{
					positions = value;
					NotifyObservers();
					UpdateCalculatedProperties();
				}
			}
		}

		public SeriesCollection SeriesCollection
		{
			get;
			private set;
		}

		public Portfolio()
		{
			positions = new ObservableCollection<PortfolioPosition>();
			positions.CollectionChanged += (sender, e) => UpdateChartValues();
			observers = new List<IObserver>();

			SeriesCollection = new SeriesCollection
			{
				new ColumnSeries
				{
					Title = "Investments",
					Values = new ChartValues<double>(Positions.Select(position => position.PurchasePrice * position.Quantity)),
					DataLabels = true
				},
				new ColumnSeries
				{
					Title = "Profits",
					Values = new ChartValues<double>(Positions.Select(position => position.ProfitLoss * position.Quantity)),
					DataLabels = true
				}
			};
		}

		public void AddPosition(PortfolioPosition position)
		{
			positions.Add(position);
			NotifyObservers();
			UpdateCalculatedProperties();
		}

		public void Subscribe(IObserver observer)
		{
			observers.Add(observer);
		}

		public void Unsubscribe(IObserver observer)
		{
			observers.Remove(observer);
		}

		public void NotifyObservers()
		{
			foreach (var observer in observers)
			{
				observer.Update();
			}

			// Mettez à jour la SeriesCollection
			SeriesCollection[0].Values = new ChartValues<double>(Positions.Select(position => position.PurchasePrice * position.Quantity));
			SeriesCollection[1].Values = new ChartValues<double>(Positions.Select(position => position.ProfitLoss * position.Quantity));
		}

		private void UpdateChartValues()
		{
			Application.Current.Dispatcher.Invoke(() =>
			{
				// Mettez à jour la SeriesCollection
				SeriesCollection[0].Values = new ChartValues<double>(Positions.Select(position => position.PurchasePrice * position.Quantity));
				SeriesCollection[1].Values = new ChartValues<double>(Positions.Select(position => position.ProfitLoss * position.Quantity));
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

		public double CalculateTotalAssets
		{
			get { return positions.Sum(position => position.Quantity); }
		}

		public double CalculateTotalProfits
		{
			get { return positions.Sum(position => position.ProfitLoss); }
		}

		public bool IsPortfolioRisky
		{
			get { return CalculateCurrentValue < CalculateTotalInvestment; }
		}

		private void UpdateCalculatedProperties()
		{
			OnPropertyChanged(nameof(CalculateTotalInvestment));
			OnPropertyChanged(nameof(CalculateCurrentValue));
			OnPropertyChanged(nameof(CalculateTotalAssets));
			OnPropertyChanged(nameof(CalculateTotalProfits));
			OnPropertyChanged(nameof(IsPortfolioRisky));
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
