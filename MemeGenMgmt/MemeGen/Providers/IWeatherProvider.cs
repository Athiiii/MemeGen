using System.Collections.Generic;
using MemeGen.Models;

namespace MemeGen.Providers
{
    public interface IWeatherProvider
    {
        List<WeatherForecast> GetForecasts();
    }
}
