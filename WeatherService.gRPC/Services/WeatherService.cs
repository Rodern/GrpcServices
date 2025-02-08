using Grpc.Core;
using WeatherService;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace WeatherService.Services
{
    public class WeatherService : GrpcWeatherService.GrpcWeatherServiceBase
    {
        //private readonly ILogger<WeatherService> _logger;
        //public WeatherService(ILogger<WeatherService> logger)
        //{
        //    _logger = logger;
        //}

        public override Task<Reply> GetWeather(Request request, ServerCallContext context)
        {
            string url = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{request.Location}?unitGroup=metric&include=events%2Cdays%2Chours%2Calerts%2Ccurrent&key=BMM7QCVGENJCDCJK3LLMSMYUN&contentType=json";
            var response = Models.Helpers.HttpHelper.GetAsync(url, new HttpClient()).Result;
            return Task.FromResult(new Reply
            {
                Data = response.Data,
            });
        }
    }
}