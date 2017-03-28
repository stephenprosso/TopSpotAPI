using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using TopSpot.Models;
using Newtonsoft.Json;

namespace TopSpot.Controllers
{


	public class TopSpotController : ApiController
	{
		[HttpGet, Route("api/getTopSpot")]
		public IHttpActionResult GetAllTopSpot()
		{
			string TopSpots = File.ReadAllText("C:\\Users\\Stephenprosso\\Documents\\Dev\\TopSpot\\TopSpots.json");

			Models.TopSpot[] topSpotsArray = JsonConvert.DeserializeObject<Models.TopSpot[]>(TopSpots);

			return Ok(topSpotsArray);
		}
		[HttpPost]

		public IHttpActionResult PostTopSpot(Models.TopSpot topSpot)
		{
			string TopSpotsFile = File.ReadAllText("C:\\Users\\Stephenprosso\\Documents\\Dev\\TopSpot\\TopSpots.json");

			Models.TopSpot[] topSpotsArray = JsonConvert.DeserializeObject<Models.TopSpot[]>(TopSpotsFile);


			TopSpotsFile = JsonConvert.SerializeObject(topSpotsArray);


			// how to add top Spot to the topspots array

			File.WriteAllText("C:\\Users\\Stephenprosso\\Documents\\Dev\\TopSpot\\TopSpots.json", TopSpotsFile);

			return Ok();
		}
	}
}
