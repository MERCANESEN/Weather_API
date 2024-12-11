using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather_API.Entities;

namespace Weather_API.Controllers
{

    //asp.net core projelerinde c# kodlarının yazıldığı alan backend tarafı controllerse yazılır
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersControllers : ControllerBase
    {
        WeatherContext context = new WeatherContext();

        //her bir api nin ne işlem yapacağını [] içindeki attiributeler aracılığıyla programa bilgireceğiz
        [HttpGet]

        //asp.net core projelerinde backend kodları bir metot içine yazılır
        public IActionResult WeatherCityList()
        {
            var values = context.Cities.ToList();
            return Ok(values);
        }
        [HttpPost]

        public IActionResult CreateWeatherCity(City city)
        {
            context.Cities.Add(city);
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteWeatherCity(int id)
        {
            var value = context.Cities.Find(id);
            context.Cities.Remove(value);
            context.SaveChanges();
            return Ok();

        }
        [HttpPut]

        public IActionResult UpdateWeatherCity(City city)
        {
            var value = context.Cities.Find(city.CityId);
            value.CityName = city.CityName;
            value.Temp = city.Temp;
            value.Country = city.Country;
            value.Detail = city.Detail;
            context.SaveChanges();
            return Ok();

        }

        [HttpGet("GetIdWeatherCity")]

        public IActionResult GetIdWeatherCity(int id)
        {
            var value = context.Cities.Find(id);
            return Ok(value);

        }
        [HttpGet("TotalCityCount")]
        public IActionResult TotalCityCount()
        {
            var value = context.Cities.Count();
            return Ok(value);
        }
        [HttpGet("MaxTempCityName")]
        public IActionResult MaxTempCityName()
        {
            var value = context.Cities.OrderByDescending(x => x.Temp).Select(y => y.CityName).FirstOrDefault();
            return Ok(value);   
        }
        [HttpGet("MinTempCityName")]
        public IActionResult MinTempCityName()
        {
            var value = context.Cities.OrderBy(x => x.Temp).Select(y => y.CityName).FirstOrDefault();
            return Ok(value);
        }

    } 
}
