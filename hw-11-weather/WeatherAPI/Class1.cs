using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace WeatherAPI

{

    public class WeatherFromAPI
    {
        public Coord coord { get; set; }
        public Weather[] weather { get; set; }
        public string _base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }

        public static async Task GetWeather(string city)

        {
            HttpClient client = new();

            try
            {
                var response = await client.GetAsync(
            $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=741304b155cd99019326f5e376058f15&units=metric&lang=ru");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var rootobject = JsonConvert.DeserializeObject<WeatherFromAPI>(responseBody);
                Console.WriteLine($"Город: {rootobject.name}, погода: {rootobject.weather[0].description}, температура: {rootobject.main.temp} °C, давление: {rootobject.main.pressure}, скорость ветра: {rootobject.wind.speed} м/с.");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nВозник Exception!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

        }
    }

    public class Coord
    {
        public float lon { get; set; }
        public float lat { get; set; }
    }

    public class Main
    {
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
    }

    public class Wind
    {
        public float speed { get; set; }
        public int deg { get; set; }
        public float gust { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public object main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

}