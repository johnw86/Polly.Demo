using Moq;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace Polly.Demo.Tests
{
    [TestFixture]
    public class ProfileServiceTests
    {
        private MockRepository _mockRepository;

        private Mock<IHttpClientFactory> _mockHttpClientFactory;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            _mockHttpClientFactory = _mockRepository.Create<IHttpClientFactory>();

            _mockHttpClientFactory.Setup(x=>x.CreateClient(It.IsAny<string>())).Returns(new )
        }

        private ProfileService CreateService()
        {
            return new ProfileService(
                _mockHttpClientFactory.Object);
        }

        [Test]
        public async Task GetProfileAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string username = null;

            // Act
            await service.GetProfileAsync(
                username);

            // Assert
            Assert.Fail();
            this._mockRepository.VerifyAll();
        }
    }
}
