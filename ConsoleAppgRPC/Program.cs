// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using WeatherService;


var channel = GrpcChannel.ForAddress("https://localhost:7179");
var client = new GrpcWeatherService.GrpcWeatherServiceClient(channel);

string location = null!;

bool shouldExit = false;

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("Welcome to the Cloud Weather app!");
Console.WriteLine("Enter location or type 'exit' to quit");
Console.ResetColor();

do
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("\nEnter location: ");
    Console.ResetColor();

    location = Console.ReadLine()!;

    if (string.IsNullOrEmpty(location))
    {
        Console.WriteLine("Location cannot be null or emppty. Please enter a valid location.");
        continue;
    }

    if (location.ToLower() == "exit")
    {
        shouldExit = true;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Exiting...");
        Console.ResetColor();

        break;
    }

    var response = await client.GetWeatherAsync(new Request
    {
        Location = location,
    });

    var data = JsonConvert.DeserializeObject(response.Data);

    // Console.WriteLine("From server: " + response.Data);

    Weather weatherData = JsonConvert.DeserializeObject<Weather>(response.Data)!;

    DisplayWeatherData(weatherData);
}
while (!shouldExit);

static void DisplayWeatherData(Weather data)
{
    Console.WriteLine($"Location: {data.ResolvedAddress}");
    Console.WriteLine($"Coordinates: {data.Latitude}, {data.Longitude}");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"Timezone: {data.TimeZone} (UTC Offset: {data.TimeZoneOffset})");
    Console.WriteLine(new string('-', 50));
    Console.ResetColor();

    Console.WriteLine("Current Conditions:");
    Console.WriteLine($"- Temperature: {data.CurrentConditions!.Temp} °C");
    Console.WriteLine($"- Feels Like: {data.CurrentConditions.FeelsLike} °C");
    Console.WriteLine($"- Humidity: {data.CurrentConditions.Humidity}%");
    Console.WriteLine($"- Conditions: {data.CurrentConditions.Conditions}");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(new string('-', 50));
    Console.ResetColor();

    Console.WriteLine("Daily Forecast:");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}", "Date", "Max Temp", "Min Temp", "Humidity", "Conditions", "Precip");
    Console.WriteLine(new string('-', 70));
    Console.ResetColor();

    foreach (var day in data.Days!)
    {
        Console.WriteLine("{0,-12} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}",
            day.DateTime.ToString("yyyy-MM-dd"),
            day.TempMax,
            day.TempMin,
            day.Humidity,
            day.Conditions,
            day.Precip);
    }
}

/*public class WeatherData
{
    public int QueryCost { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? ResolvedAddress { get; set; }
    public string? Timezone { get; set; }
    public double TzOffset { get; set; }
    public List<DayForecast>? Days { get; set; }
    public CurrentConditions? CurrentConditions { get; set; }
}

public class DayForecast
{
    public DateTime DateTime { get; set; }
    public double TempMax { get; set; }
    public double TempMin { get; set; }
    public double Humidity { get; set; }
    public string? Conditions { get; set; }
    public double Precip { get; set; }
}

public class CurrentConditions
{
    public string? Datetime { get; set; }
    public double Temp { get; set; }
    public double FeelsLike { get; set; }
    public double Humidity { get; set; }
    public string? Conditions { get; set; }
}*/





public class WeatherData
{
    public int QueryCost { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? ResolvedAddress { get; set; }
    public string? Address { get; set; }
    public string? Timezone { get; set; }
    public double TzOffset { get; set; }
    public List<DayData>? Days { get; set; }
    public List<object>? Alerts { get; set; } // List<object> for flexibility
    public CurrentConditions? CurrentConditions { get; set; }
}


public class CurrentConditions
{
    public DateTime Datetime { get; set; }
    public long DatetimeEpoch { get; set; }
    public double Temp { get; set; }
    public double FeelsLike { get; set; }
    public double Humidity { get; set; }
    public double Dew { get; set; }
    public double Precip { get; set; }
    public double PrecipProb { get; set; }
    public double Snow { get; set; }
    public double SnowDepth { get; set; }
    public string[]? PrecipType { get; set; } // Using object to handle potential null
    public double? WindGust { get; set; }
    public double WindSpeed { get; set; }
    public double WindDir { get; set; }
    public double Pressure { get; set; }
    public double Visibility { get; set; }
    public double CloudCover { get; set; }
    public double SolarRadiation { get; set; }
    public double SolarEnergy { get; set; }
    public double UVIndex { get; set; }
    public double SevereRisk { get; set; }
    public string? Conditions { get; set; }
    public string? Icon { get; set; }
    public List<object>? Stations { get; set; } // Using List<object> to handle empty array
    public string? Source { get; set; }
    public string? Sunrise { get; set; }
    public long SunriseEpoch { get; set; }
    public string? Sunset { get; set; }
    public long SunsetEpoch { get; set; }
    public double MoonPhase { get; set; }
}


public class DayData
{
    public DateTime Datetime { get; set; }
    public long DatetimeEpoch { get; set; }
    public double TempMax { get; set; }
    public double TempMin { get; set; }
    public double Temp { get; set; }
    public double FeelsLikeMax { get; set; }
    public double FeelsLikeMin { get; set; }
    public double FeelsLike { get; set; }
    public double Dew { get; set; }
    public double Humidity { get; set; }
    public double Precip { get; set; }
    public double PrecipProb { get; set; }
    public double PrecipCover { get; set; }
    public string? PrecipType { get; set; }
    public double Snow { get; set; }
    public double SnowDepth { get; set; }
    public double? WindGust { get; set; }
    public double WindSpeed { get; set; }
    public double WindDir { get; set; }
    public double Pressure { get; set; }
    public double CloudCover { get; set; }
    public double Visibility { get; set; }
    public double SolarRadiation { get; set; }
    public double SolarEnergy { get; set; }
    public double UvIndex { get; set; }
    public double SevereRisk { get; set; }
    public string? Sunrise { get; set; }
    public long SunriseEpoch { get; set; }
    public string? Sunset { get; set; }
    public long SunsetEpoch { get; set; }
    public double MoonPhase { get; set; }
    public string? Conditions { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
    public List<string>? Stations { get; set; }
    public string? Source { get; set; }
    public List<HourData>? Hours { get; set; }
}


public class HourData
{
    public DateTime Datetime { get; set; }
    public long DatetimeEpoch { get; set; }
    public double Temp { get; set; }
    public double Feelslike { get; set; }
    public double Humidity { get; set; }
    public double Dew { get; set; }
    public double Precip { get; set; }
    public double PrecipProb { get; set; }
    public double Snow { get; set; }
    public double SnowDepth { get; set; }
    public string? PrecipType { get; set; }
    public double? WindGust { get; set; }
    public double WindSpeed { get; set; }
    public double WindDir { get; set; }
    public double Pressure { get; set; }
    public double Visibility { get; set; }
    public double CloudCover { get; set; }
    public double SolarRadiation { get; set; }
    public double SolarEnergy { get; set; }
    public double UvIndex { get; set; }
    public double SevereRisk { get; set; }
    public string? Conditions { get; set; }
    public string? Icon { get; set; }
    public List<string>? Stations { get; set; }
    public string? Source { get; set; }
}
