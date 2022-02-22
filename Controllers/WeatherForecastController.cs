using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkshopApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	//[Route("[controller]")] // デバッグ実行時は api を抜かないと動作しない
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			Console.WriteLine($"Called {Request.Method} {Request.Host}{Request.Path} by {Request.Headers["X-Forwarded-For"]}");

			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}