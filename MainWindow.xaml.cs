using LiveCharts;
using LiveCharts.Wpf;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace CryptoCurrencie
{
	public partial class MainWindow : Window, IObserver
	{
		public List<Coin> CryptoCurrencies { get; set; }
		public Portfolio UserPortfolio { get; set; }
		public SeriesCollection SeriesCollection { get; private set; }

		public MainWindow()
		{
			InitializeComponent();

			FetchAndDisplayData();

			CryptoCurrencies = new List<Coin>();
			UserPortfolio = new Portfolio();

			// Ajouter une position par default
			PortfolioPosition newPosition = new PortfolioPosition("Voiture Audi", 750, 1750, 1);
			ICommand calculateRiskCommand = new CalculateRiskCommand(newPosition);

			// Calculer le risque de la position via un Command
			calculateRiskCommand.Execute();

			UserPortfolio.AddPosition(newPosition);
			UserPortfolio.Subscribe(this);

			SeriesCollection = new SeriesCollection
			{
				new ColumnSeries
				{
					Title = "Investments",
					Values = new ChartValues<double>(UserPortfolio.Positions.Select(position => position.PurchasePrice * position.Quantity)),
					DataLabels = true
				},
				new ColumnSeries
				{
					Title = "Profits",
					Values = new ChartValues<double>(UserPortfolio.Positions.Select(position => position.ProfitLoss * position.Quantity)),
					DataLabels = true
				}
			};

			SeriesCollection = UserPortfolio.SeriesCollection;

			DataContext = this;
		}

		private async void FetchAndDisplayData()
		{
			List<string> apiUrls = new List<string>
			{
				"https://api.coingecko.com/api/v3/coins/bitcoin",
				"https://api.coingecko.com/api/v3/coins/solana",
			};

			foreach (string apiUrl in apiUrls)
			{
				Coin crypto = await FetchApiAsync(apiUrl);
				if (crypto != null)
				{
					CryptoCurrencies.Add(crypto);
				}
			}
		}

		private async Task<Coin> FetchApiAsync(string apiUrl)
		{
			using (HttpClient client = new HttpClient())
			{
				try
				{
					HttpResponseMessage response = await client.GetAsync(apiUrl);
					response.EnsureSuccessStatusCode();

					string jsonData = await response.Content.ReadAsStringAsync();

					using (JsonDocument document = JsonDocument.Parse(jsonData))
					{
						JsonElement root = document.RootElement;

						// Recupere les données de base
						string id = root.GetProperty("id").GetString();
						string symbol = root.GetProperty("symbol").GetString();
						string name = root.GetProperty("name").GetString();

						JsonElement imageElement = root.GetProperty("image");
						ImageUrls thumbImage = new ThumbImage { Url = imageElement.GetProperty("thumb").GetString() };
						ImageUrls smallImage = new SmallImage { Url = imageElement.GetProperty("small").GetString() };
						ImageUrls largeImage = new LargeImage { Url = imageElement.GetProperty("large").GetString() };

						JsonElement marketDataElemnt = root.GetProperty("market_data");

						JsonElement priceElement = marketDataElemnt.GetProperty("current_price");
						double usd_price = priceElement.GetProperty("usd").GetDouble();

						double change_price_last_day = marketDataElemnt.GetProperty("price_change_24h").GetDouble();
						double change_percent_last_day = marketDataElemnt.GetProperty("price_change_percentage_24h").GetDouble();
						double change_percent_last_week = marketDataElemnt.GetProperty("price_change_percentage_7d").GetDouble();

						// Instancier Coin
						return new Coin(id, symbol, name, Math.Floor(usd_price), Math.Floor(change_price_last_day), Math.Floor(change_percent_last_day), Math.Floor(change_percent_last_week), thumbImage, smallImage, largeImage);
					}
				}
				catch (HttpRequestException e)
				{
					MessageBox.Show($"Une erreur s'est produite lors de la requête HTTP : {e.Message}");
					return null;
				}
			}
		}

		private void OnAddPositionClicked(object sender, RoutedEventArgs e)
		{
			try
			{
				string coinName = txtCoinName.Text;
				double purchasePrice = Convert.ToDouble(txtPurchasePrice.Text);
				double currentPrice = Convert.ToDouble(txtCurrentPrice.Text);
				double quantity = Convert.ToDouble(txtQuantity.Text);

				PortfolioPosition newPosition = new PortfolioPosition(coinName, purchasePrice, currentPrice, quantity);

				ICommand calculateRiskCommand = new CalculateRiskCommand(newPosition);
				calculateRiskCommand.Execute();

				UserPortfolio.AddPosition(newPosition);

				// Reset les champs
				txtCoinName.Text = "";
				txtPurchasePrice.Text = "";
				txtCurrentPrice.Text = "";
				txtQuantity.Text = "";

				MessageBox.Show("Position ajoutée avec succès!", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			catch (FormatException)
			{
				MessageBox.Show("Veuillez entrer des valeurs numériques valides pour le prix d'achat, le prix actuel et la quantité.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void GenerateGraph_Click(object sender, RoutedEventArgs e)
		{
			if (int.TryParse(txtNumberOfPeriods.Text, out int numberOfPeriods) && double.TryParse(txtProfitPercentage.Text, out double profitPercentage))
			{
				var selectedTimePeriod = (cmbTimePeriod.SelectedItem as ComboBoxItem)?.Content.ToString();
				System.Diagnostics.Debug.WriteLine("======> Main NumberOfPeriods: " + numberOfPeriods);
				System.Diagnostics.Debug.WriteLine("======> Main ProfitPercentage: " + profitPercentage);
				System.Diagnostics.Debug.WriteLine("======> Main SelectedTimePeriod: " + selectedTimePeriod);

				GraphProjection projectionWindow = new GraphProjection(numberOfPeriods, profitPercentage, selectedTimePeriod, this);
				projectionWindow.CalculateAndSetNewGraph(UserPortfolio);
				
				projectionWindow.ParentMainWindow = this;
				projectionWindow.Show();
			}
			else
			{
				MessageBox.Show("Invalid input. Please enter valid numbers.");
			}
		}

		public void Update()
		{
			SeriesCollection[0].Values = new ChartValues<double>(UserPortfolio.Positions.Select(position => position.PurchasePrice * position.Quantity));
		}
	}
}