using Domain;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistence;
using Xunit;

namespace Tests;

public partial class RepositoryTests
{
    public class ItemTypePersistenceTests
    {
        private readonly Mock<DbContext> _mockContext;
        private readonly Mock<DbSet<ItemType>> _mockSet;
        private readonly ItemTypePersistence _repository;

        public ItemTypePersistenceTests()
        {
            _mockContext = new Mock<DbContext>();
            _mockSet = new Mock<DbSet<ItemType>>();
            _mockContext.Setup(c => c.Set<ItemType>()).Returns(_mockSet.Object);
            _repository = new ItemTypePersistence(_mockContext.Object);
        }

        [Fact]
        public void GetAll_ReturnsDbSet()
        {
            // Act
            var result = _repository.GetAll();

            // Assert
            Assert.Same(_mockSet.Object, result);
            _mockContext.Verify(c => c.Set<ItemType>(), Times.Once);
        }

        [Fact]
        public void Get_CallsFindOnDbSet()
        {
            // Arrange
            var testId = 1;
            var testItemType = new ItemType(testId, "Test Type", "Test Description");
            _mockSet.Setup(s => s.Find(testId)).Returns(testItemType);

            // Act
            var result = _repository.Get(testId);

            // Assert
            Assert.Same(testItemType, result);
            _mockSet.Verify(s => s.Find(testId), Times.Once);
        }

        [Fact]
        public void Add_AddsItemTypeAndSavesChanges()
        {
            // Arrange
            var itemType = new ItemType(1, "Test Type", "Test Description");

            // Act
            _repository.Add(itemType);

            // Assert
            _mockSet.Verify(s => s.Add(itemType), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        [Fact]
        public void Remove_RemovesItemTypeAndSavesChanges()
        {
            // Arrange
            var itemType = new ItemType(1, "Test Type", "Test Description");

            // Act
            _repository.Remove(itemType);

            // Assert
            _mockSet.Verify(s => s.Remove(itemType), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}