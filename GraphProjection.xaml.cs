using LiveCharts;
using LiveCharts.Wpf;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace CryptoCurrencie
{
	public partial class GraphProjection : Window, INotifyPropertyChanged
	{
		public MainWindow ParentMainWindow { get; set; }
		public int NumberOfPeriods { get; set; }
		public double ProfitPercentage { get; set; }
		public String SelectedTimePeriod { get; set; }
		public SeriesCollection SeriesCollectionProjection { get; set; }


		public GraphProjection(int numberOfPeriods, double profitPercentage, string selectedTimePeriod, MainWindow parentMainWindow)
		{
			InitializeComponent();

			NumberOfPeriods = numberOfPeriods;
			ProfitPercentage = profitPercentage;
			SelectedTimePeriod = selectedTimePeriod;
			ParentMainWindow = parentMainWindow;

			DataContext = this;
		}


		public void CalculateAndSetNewGraph(Portfolio userPortfolio)
		{
			System.Diagnostics.Debug.WriteLine("======> Main SelectedTimePeriod: " + ProfitPercentage);

			SeriesCollectionProjection = new SeriesCollection
			{
				new ColumnSeries
				{
					Title = "Investments",
					Values = new ChartValues<double>(),
					DataLabels = true
				},
				new ColumnSeries
				{
					Title = "Profits",
					Values = new ChartValues<double>(),
					DataLabels = true
				}
			};

			if (SelectedTimePeriod == "Months")
			{
				for (int i = 0; i < NumberOfPeriods; i++)
				{
					double totalInvestment = userPortfolio.CalculateTotalInvestment;

					// Calcul Profit
					double totalProfits;
					ChartValues<double> values = (ChartValues<double>)SeriesCollectionProjection[1].Values;
					int lastIndex = values.Count - 1;
					if (lastIndex >= 0)
					{
						totalProfits = (double)values[lastIndex] * ((ProfitPercentage / 100) + 1);
					} else
					{
						totalProfits = userPortfolio.CalculateTotalProfits;
					}

					// Ajouter les valeurs à la série
					SeriesCollectionProjection[0].Values.Add(totalInvestment);
					SeriesCollectionProjection[1].Values.Add(totalProfits);
				}
			}
			else if (SelectedTimePeriod == "Years")
			{
				for (int i = 0; i < NumberOfPeriods; i++)
				{
					double totalInvestment = userPortfolio.CalculateTotalInvestment;

					// Calcul Profit
					double totalProfits;
					ChartValues<double> values = (ChartValues<double>)SeriesCollectionProjection[1].Values;
					int lastIndex = values.Count - 1;
					if (lastIndex >= 0)
					{
						totalProfits = (double)values[lastIndex] * ((ProfitPercentage / 100) + 1);
					}
					else
					{
						totalProfits = userPortfolio.CalculateTotalProfits;
					}

					// Ajouter les valeurs à la série
					SeriesCollectionProjection[0].Values.Add(totalInvestment);
					SeriesCollectionProjection[1].Values.Add(totalProfits);
				}
			}
			OnPropertyChanged(nameof(SeriesCollectionProjection));
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
