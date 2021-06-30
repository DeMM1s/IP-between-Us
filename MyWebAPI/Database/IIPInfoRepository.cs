using MyWebAPI.Models;
using System.Linq;
using System.Net;

namespace MyWebAPI.Database
{
	public interface IIPInfoRepository
	{
		IQueryable<IPInfo> IPInfos { get; }
		void SaveIPInfo(IPInfo iPInfo);
		IPInfo FindByStartAndEndIP(string startIP, string endIP);
	}
}
