using Domain;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistence;
using Xunit;

namespace Tests;

public partial class RepositoryTests
{
    public class LocationPersistenceTests
    {
        private readonly Mock<DbContext> _mockContext;
        private readonly Mock<DbSet<Location>> _mockSet;
        private readonly LocationPersistence _repository;

        public LocationPersistenceTests()
        {
            _mockContext = new Mock<DbContext>();
            _mockSet = new Mock<DbSet<Location>>();
            _mockContext.Setup(c => c.Set<Location>()).Returns(_mockSet.Object);
            _repository = new LocationPersistence(_mockContext.Object);
        }

        [Fact]
        public void GetAll_ReturnsDbSet()
        {
            // Act
            var result = _repository.GetAll();

            // Assert
            Assert.Same(_mockSet.Object, result);
            _mockContext.Verify(c => c.Set<Location>(), Times.Once);
        }

        [Fact]
        public void Get_CallsFindOnDbSet()
        {
            // Arrange
            var testId = 1;
            var testLocation = new Location(testId, "Test Location");
            _mockSet.Setup(s => s.Find(testId)).Returns(testLocation);

            // Act
            var result = _repository.Get(testId);

            // Assert
            Assert.Same(testLocation, result);
            _mockSet.Verify(s => s.Find(testId), Times.Once);
        }

        [Fact]
        public void Add_AddsLocationAndSavesChanges()
        {
            // Arrange
            var location = new Location(1, "Test Location");

            // Act
            _repository.Add(location);

            // Assert
            _mockSet.Verify(s => s.Add(location), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Fact]
        public void Remove_RemovesLocationAndSavesChanges()
        {
            // Arrange
            var location = new Location(1, "Test Location");

            // Act
            _repository.Remove(location);

            // Assert
            _mockSet.Verify(s => s.Remove(location), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}