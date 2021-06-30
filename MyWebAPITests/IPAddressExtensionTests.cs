using MyWebAPI.Extensions;
using System.Net;
using Xunit;

namespace MyWebAPITests
{
	public class IPAddressExtensionTests
	{
		[Fact]
		public void Can_Compare()
		{
			IPAddress greater = new IPAddress(new byte[] { 255, 255, 255, 255 });
			IPAddress lesser = new IPAddress(new byte[] { 0, 0, 0, 0 });

			int less = lesser.Compare(greater);
			int more = greater.Compare(lesser);
			int equal = lesser.Compare(lesser);

			Assert.Equal(-1, less);
			Assert.Equal(1, more);
			Assert.Equal(0, equal);
		}
	}
}
