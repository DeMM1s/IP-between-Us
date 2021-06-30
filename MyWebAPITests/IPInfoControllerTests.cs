using Moq;
using MyWebAPI.Controllers;
using MyWebAPI.Database;
using Xunit;

namespace MyWebAPITests
{
	public class IPInfoControllerTests
	{
		[Fact]
		public void Can_Response_With_Valid_Input()
		{
			Mock<IIPInfoRepository> mock = new Mock<IIPInfoRepository>();
			string start = "192.168.0.1";
			string end = "192.168.0.5";
			string expected = "[\"192.168.0.2\",\"192.168.0.3\",\"192.168.0.4\"]";
			IPInfoController target = new IPInfoController(mock.Object);

			string result = target.Get(start, end);

			Assert.Equal(expected, result);
		}

		[Fact]
		public void Return_Empty_Array_With_Invalid_Input()
		{
			Mock<IIPInfoRepository> mock = new Mock<IIPInfoRepository>();
			string start = "192.168.0.1.1";
			string end = "192.168.0.5";
			string expected = "[]";
			IPInfoController target = new IPInfoController(mock.Object);

			string result = target.Get(start, end);

			Assert.Equal(expected, result);
		}
	}
}
