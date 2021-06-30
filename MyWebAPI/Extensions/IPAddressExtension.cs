using System.Net;

namespace MyWebAPI.Extensions
{
	public static class IPAddressExtension
	{
		public static int Compare(this IPAddress address, IPAddress other)
		{
			string[] adr = address.ToString().Split('.');
			string[] othr = other.ToString().Split('.');
			for (int i = 0; i < adr.Length - 1; i++)
			{
				if (int.Parse(adr[i]) > int.Parse(othr[i]))
				{
					return 1;
				}
			}
			if (int.Parse(adr[3]) > int.Parse(othr[3]))
			{
				return 1;
			}
			else if (int.Parse(adr[3]) < int.Parse(othr[3]))
			{
				return -1;
			}
			else
			{
				return 0;
			}
		}
	}
}
