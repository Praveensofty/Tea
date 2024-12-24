using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Library.Pages;
using Library.Services;
using Library.Models;

namespace YourProjectName.Tests
{
    [TestFixture]
    public class ProductDetailsModelTests
    {
        private Mock<IProductService> _mockProductService;
        private AddTeaModel _pageModel;

        [SetUp]
        public void SetUp()
        {
            _mockProductService = new Mock<IProductService>();
            _pageModel = new AddTeaModel(_mockProductService.Object);
        }

        [Test]
        public async Task OnGetAsync_ReturnsPageResult_WhenProductExists()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Test Product" };
            _mockProductService
                .Setup(s => s.GetProductByIdAsync(1))
                .ReturnsAsync(product);

            // Act
            var result = await _pageModel.OnGetAsync(1);

            // Assert
            Assert.That(result, Is.TypeOf<PageResult>());
            Assert.That(_pageModel.Product, Is.Not.Null);
            Assert.That(_pageModel.Product.Name, Is.EqualTo("Test Product"));
        }

        [Test]
        public async Task OnGetAsync_ReturnsNotFoundResult_WhenProductDoesNotExist()
        {
            // Arrange
            _mockProductService
                .Setup(s => s.GetProductByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Product)null);

            // Act
            var result = await _pageModel.OnGetAsync(99);

            // Assert
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }
    }
}