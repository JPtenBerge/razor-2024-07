using DemoShared.Entities;
using DemoProject.Pages;
using DemoProject.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;

namespace DemoProject.Tests
{
    [TestClass]
    public class IndexModelTests
    {
        List<Car> _cars = default!;
        List<CarType> _carTypes = default!;

        Mock<ICarRepository> _carRepositoryMock = default!;
        Mock<ICarTypeRepository> _carTypeRepositoryMock = default!;

        IndexModel _sut = default!;

        [ClassInitialize]
        public void OneTimeInit()
        {

        }


        [TestInitialize]
        public void Init()
        {
            _carTypes = new List<CarType>
            {
                new() { Id = 4, Name = "Electrisch", Cars = new List<Car>() },
                new() { Id = 8, Name = "Diesel", Cars = new List<Car>() },
                new() { Id = 15, Name = "Benzine", Cars = new List<Car>() }
            };
            _cars = new List<Car>
            {
                new Car {Make = "Q1", Model = "W4", PhotoUrl = "https://bla.com/ding.jpg", Type = _carTypes[0], TypeId = _carTypes[0].Id, Year = 1996 },
                new Car {Make = "Q2", Model = "W5", PhotoUrl = "https://bla.com/ding.jpg", Type = _carTypes[1], TypeId = _carTypes[1].Id, Year = 1996 },
                new Car {Make = "Q3", Model = "W6", PhotoUrl = "https://bla.com/ding.jpg", Type = _carTypes[0], TypeId = _carTypes[0].Id, Year = 1996 },
                new Car {Make = "Q4", Model = "W7", PhotoUrl = "https://bla.com/ding.jpg", Type = _carTypes[0], TypeId = _carTypes[0].Id, Year = 1996 }
            };

            _carRepositoryMock = new Mock<ICarRepository>();
            _carTypeRepositoryMock = new Mock<ICarTypeRepository>();
            _carRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(_cars);
            _carTypeRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(_carTypes);

            _sut = new IndexModel(_carRepositoryMock.Object, _carTypeRepositoryMock.Object);
        }


        [TestMethod]
        public async Task OnGet_CallReposAndStoresValuesInProperties()
        {
            // Arrange: dingen klaarzetten/voorbereiden

            // Act: doen
            await _sut.OnGet();

            // Assert: toetsen
            _carRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once());
            _carTypeRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once());
            _sut.Cars.Should().BeEquivalentTo(_cars);
            _sut.CarTypes.Should().BeEquivalentTo(_carTypes);
        }

        [TestMethod]
        public async Task OnPost_ValidModel_AddsUsingRepoAndRedirects()
        {
            // Arrange: dingen klaarzetten/voorbereiden

            // Act: doen
            var result = await _sut.OnPost();

            // Assert: toetsen
            _carRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Car>()), Times.Once());
            _carRepositoryMock.Verify(x => x.GetAllAsync(), Times.Never());
            _carTypeRepositoryMock.Verify(x => x.GetAllAsync(), Times.Never());
            result.Should().BeOfType<RedirectToPageResult>();
        }

        [TestMethod]
        public async Task OnPost_InvalidModel_NotAddUsingRepoAndReturnsPageWithValidationErrors()
        {
            // Arrange: dingen klaarzetten/voorbereiden
            _sut.ModelState.AddModelError("q", "w");

            // Act: doen
            var result = await _sut.OnPost();

            // Assert: toetsen
            _carRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Car>()), Times.Never());
            _carRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once());
            _carTypeRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once());
            result.Should().BeOfType<PageResult>();
        }
    }

    //class NepCarRepository : ICarRepository
    //{
    //    public Task<Car> AddAsync(Car newCar)
    //    {

    //    }

    //    public Task<IEnumerable<Car>> GetAllAsync()
    //    {

    //    }
    //}
}