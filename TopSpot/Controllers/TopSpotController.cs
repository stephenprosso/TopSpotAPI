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
		private string JsonUrl = "C:\\Users\\Stephenprosso\\Documents\\Dev\\TopSpot\\TopSpots.json";
		[HttpGet, Route("api/getTopSpot")]
		public IHttpActionResult GetAllTopSpot()
		{
			string TopSpots = File.ReadAllText(JsonUrl);

			Models.TopSpot[] topSpotsArray = JsonConvert.DeserializeObject<Models.TopSpot[]>(TopSpots);

			return Ok(topSpotsArray);
		}

		[HttpPost, Route("api/getTopSpot")]
		public IHttpActionResult PostTopSpot(Models.TopSpot topSpot)
		{
			string TopSpotsFile = File.ReadAllText(JsonUrl);

			List<Models.TopSpot> topSpotsList = JsonConvert.DeserializeObject<List<Models.TopSpot>>(TopSpotsFile);
			topSpotsList.Add(topSpot);
			
			// reserialize the array
			TopSpotsFile = JsonConvert.SerializeObject(topSpotsList);
			File.WriteAllText(JsonUrl, TopSpotsFile);

			return Ok(topSpotsList);
		}
	}
}
