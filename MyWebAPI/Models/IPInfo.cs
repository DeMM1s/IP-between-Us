using MyWebAPI.Extensions;
using System.Collections.Generic;
using System.Net;

namespace MyWebAPI.Models
{
	public class IPInfo
	{
		public string StartIP { get; set; }
		public string EndIP { get; set; }
		public string[] IntermediateIP { get; set; }

		public IPInfo(string startIP, string endIP)
		{
			if (IPAddress.Parse(startIP).Compare(IPAddress.Parse(endIP)) == 1)
			{
				string temp = startIP;
				startIP = endIP;
				endIP = temp;
			}
			StartIP = startIP.ToString();
			EndIP = endIP.ToString();
			IntermediateIP = SetIntermediateIP(StartIP, EndIP);
		}
		private string[] SetIntermediateIP(string startIP, string endIP)
		{
			List<string> addresses = new List<string>();
			string[] start = startIP.Split('.');
			string[] end = endIP.Split('.');
			for (int firstOctet = int.Parse(start[0]); firstOctet < 256; firstOctet++)
			{
				for (int secondOctet = int.Parse(start[1]); secondOctet < 256; secondOctet++)
				{
					for (int thirdOctet = int.Parse(start[2]); thirdOctet < 256; thirdOctet++)
					{
						for (int fourthOctet = int.Parse(start[3]); fourthOctet < 256; fourthOctet++)
						{
							string address = firstOctet.ToString() +
													'.' + secondOctet.ToString() +
													'.' + thirdOctet.ToString() +
													'.' + fourthOctet.ToString();
							if (address == endIP.ToString())
							{
								if (addresses.Count > 0)
								{
									addresses.RemoveAt(0);
								}
								return addresses.ToArray();
							}
							addresses.Add(address);
						}
					}
				}
			}
			return addresses.ToArray();
		}
	}
}
