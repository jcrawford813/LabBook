using Domain;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistence;
using Xunit;

namespace Tests;

public partial class RepositoryTests
{
    public class ItemPersistenceTests
    {
        private readonly Mock<DbContext> _mockContext;
        private readonly Mock<DbSet<Item>> _mockSet;
        private readonly ItemPersistence _repository;

        public ItemPersistenceTests()
        {
            _mockContext = new Mock<DbContext>();
            _mockSet = new Mock<DbSet<Item>>();
            _mockContext.Setup(c => c.Set<Item>()).Returns(_mockSet.Object);
            _repository = new ItemPersistence(_mockContext.Object);
        }

        [Fact]
        public void GetAll_ReturnsDbSet()
        {
            // Act
            var result = _repository.GetAll();

            // Assert
            Assert.Same(_mockSet.Object, result);
            _mockContext.Verify(c => c.Set<Item>(), Times.Once);
        }

        [Fact]
        public void Get_CallsFindOnDbSet()
        {
            // Arrange
            var testId = 1;
            var testItem = new Item(testId, "Test Item", "Test Description");
            _mockSet.Setup(s => s.Find(testId)).Returns(testItem);

            // Act
            var result = _repository.Get(testId);

            // Assert
            Assert.Same(testItem, result);
            _mockSet.Verify(s => s.Find(testId), Times.Once);
        }

        [Fact]
        public void Add_AddsItemAndSavesChanges()
        {
            // Arrange
            var item = new Item(1, "Test Item", "Test Description");

            // Act
            _repository.Add(item);

            // Assert
            _mockSet.Verify(s => s.Add(item), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Fact]
        public void Remove_RemovesItemAndSavesChanges()
        {
            // Arrange
            var item = new Item(1, "Test Item", "Test Description");

            // Act
            _repository.Remove(item);

            // Assert
            _mockSet.Verify(s => s.Remove(item), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}