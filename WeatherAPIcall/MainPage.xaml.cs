namespace WeatherAPIcall
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }



        private async void OnGetWeatherBtnClicked(object sender, EventArgs e)
        {
            var location = await Geolocation.Default.GetLocationAsync();
            var lat = location.Latitude;
            var lon = location.Longitude;
            var url = $"https://api.openweathermap.org/data/2.5/weather" +
                      $"?lat={lat}&lon={lon}&units=metric" +
                      $"&appid=adee4d9d26685357054efd2f06359807";

            var myWeather = await WeatherProxy.GetWeather(url);
            CityLbl.Text = myWeather.name;
            TemperatureLbl.Text = myWeather.main.temp.ToString("F0") + " \u00B0C";
            ConditionsLbl.Text = myWeather.weather[0].description.ToUpper();

            string icon =$"http://openweathermap.org/img/wn/{myWeather.weather[0].icon}@2x.png";
            WeatherImg.Source = ImageSource.FromUri(new Uri(icon));
        }
    }

}
