using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;
using System.Linq;

namespace MyWebAPI.Database
{
	public class EFIPInfoRepository : IIPInfoRepository
	{
		private ApplicationDbContext _context;

		public EFIPInfoRepository(ApplicationDbContext context)
		{
			_context = context;
			_context.Database.Migrate();
		}

		public IQueryable<IPInfo> IPInfos => _context.IPInfos;

		public void SaveIPInfo(IPInfo iPInfo)
		{
			_context.IPInfos.Add(iPInfo);
			_context.SaveChanges();
		}

		public IPInfo FindByStartAndEndIP(string startIP, string endIP)
		{
			return _context.IPInfos.FirstOrDefault(i => i.StartIP == startIP.ToString() && i.EndIP == endIP.ToString());
		}
	}
}
