using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    
    public class ProductImageRepositoryTest
    {
        [Fact]
        public void CreatePathsTest()
        {
            //Arrange
            var file1 = new Mock<IFormFile>();
            var file2 = new Mock<IFormFile>();

            string picture1 = "pic1";
            string picture2 = "pic2";
            file1.Setup(p => p.FileName).Returns(picture1);
            file2.Setup(p => p.FileName).Returns(picture2);

            var fileMock = new Mock<List<IFormFile>>();

            var hostMockList = new Mock<IHostingEnvironment>();
            string roothPath = "C:\\Users\\barte\\source\\repos\\OnlineShop\\OnlineShop\\wwwroot";
            hostMockList.Setup(n => n.WebRootPath).Returns(roothPath);

            IProductImageRepository repository = new ProductImageRepository(hostMockList.Object);
            //Act
            var returnedPaths = repository.AddPathToPhoto(new List<IFormFile> { file1.Object, file2.Object });
            //Assert
            returnedPaths.Should().NotBeNullOrEmpty();
            returnedPaths.Should().BeOfType(typeof(List<string>));
            returnedPaths.Should().HaveCount(2);
            returnedPaths[0].Should().NotBeEquivalentTo(returnedPaths[1]);
            returnedPaths[0].Should().EndWithEquivalentOf(picture1);
            returnedPaths[1].Should().EndWithEquivalentOf(picture2);
        }
    }
}
