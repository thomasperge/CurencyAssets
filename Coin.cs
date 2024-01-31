namespace CryptoCurrencie
{
	public class Coin
	{
		public string id { get; set; }
		public string symbol { get; set; }
		public string name { get; set; }
		public double usd_price { get; set; }
		public double change_price_last_day { get; set; }
		public double change_percent_last_day { get; set; }
		public double change_percent_last_week { get; set; }
		public ImageUrls ThumbImage { get; set; }
		public ImageUrls SmallImage { get; set; }
		public ImageUrls LargeImage { get; set; }

		public Coin(string id, string symbol, string name, double usd_price, double change_price_last_day, double change_percent_last_day, double change_percent_last_week, ImageUrls thumbImage, ImageUrls smallImage, ImageUrls largeImage)
		{
			this.id = id;
			this.symbol = symbol;
			this.name = name;
			this.usd_price = usd_price;
			this.change_price_last_day = change_price_last_day;
			this.change_percent_last_day = change_percent_last_day;
			this.change_percent_last_week = change_percent_last_week;
			ThumbImage = thumbImage;
			SmallImage = smallImage;
			LargeImage = largeImage;
		}

		public Coin() { }
	}
}
