using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;

namespace TopSpot.Controllers
{


	public class TopSpotController : ApiController
	{
		[HttpGet, Route("api/getTopSpot")]
		public IHttpActionResult GetAllTopSpot()
		{
			var TopSpot = File.ReadAllText("C:\\Users\\Stephenprosso\\Documents\\Dev\\TopSpot\\TopSpots.json");
		return Ok(TopSpot);
		}
	}
}
