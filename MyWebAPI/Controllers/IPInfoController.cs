using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Database;
using MyWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MyWebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class IPInfoController : ControllerBase
	{
		private IIPInfoRepository _repository;

		public IPInfoController(IIPInfoRepository repository)
		{
			_repository = repository;
		}

		[HttpGet("{from}&{to}")]
		public string Get(string from, string to)
		{
			if (!IPAddress.TryParse(from, out IPAddress startIP) || !IPAddress.TryParse(to, out IPAddress endIP))
			{
				return JsonConvert.SerializeObject(Array.Empty<IPAddress>());
			}
			var dbEntry = _repository.FindByStartAndEndIP(startIP.ToString(), endIP.ToString());
			if (dbEntry == null)
			{
				IPInfo result = new IPInfo(startIP.ToString(), endIP.ToString());
				_repository.SaveIPInfo(result);
				return JsonConvert.SerializeObject(result.IntermediateIP);
			}
			else
			{
				return JsonConvert.SerializeObject(dbEntry.IntermediateIP);
			}
		}
	}
}
