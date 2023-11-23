using Application.Interfaces;
using Application.ItemTypes;

namespace Tests;

public partial class ApplicationTests
{
    public class ItemTypeQueryTests
    {
        public ItemTypeQueryTests()
        {
            var mock = new AutoMocker();

            var itemTypes = new List<ItemType>()
            {
                new(1, "Item Type 1", "An initial item type."),
                new(2, "Another Type", "The second item type."),
                new(3, "Item Type 3", "The last one.")
            };

            mock.GetMock<IRepository<ItemType>>()
                .Setup(r => r.GetAll())
                .Returns(itemTypes.AsQueryable());

            mock.GetMock<IRepository<ItemType>>()
                .Setup(r => r.Get(1))
                .Returns(itemTypes.Single(i => i.Id == 1));
            
            mock.GetMock<IRepository<ItemType>>()
                .Setup(r => r.Get(4))
                .Returns(value:null);
            
            mock.GetMock<IDatabase>()
                .Setup(d => d.ItemTypes)
                .Returns(mock.GetMock<IRepository<ItemType>>().Object);
            
            _queries = new(mock.GetMock<IDatabase>().Object);
        }

        private readonly ItemTypeQueries _queries;

        [Fact]
        public void TestGetAll()
        {
            var filter = String.Empty;
            var result = _queries.GetItemTypes(filter);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void TestGetWithFilterOnName()
        {
            var filter = "Another";
            var result = _queries.GetItemTypes(filter);
            Assert.Single(result);
        }

        [Fact]
        public void TestGetWithFilterOnDescription()
        {
            var filter = "initial";
            var result = _queries.GetItemTypes(filter);
            Assert.Single(result);
        }

        [Fact]
        public void TestGetWithId()
        {
            var id = 1;
            var result = _queries.GetItemType(id);
            Assert.Equal(id, result?.Id);
        }

        [Fact]
        public void TestGetWithInvalidId()
        {
            var id = 4;
            var result = _queries.GetItemType(id);
            Assert.Null(result);
        }
    }

    public class ItemTypeModelTests
    {
        private readonly ItemTypeModel _model = new(1, "This Model Type.", "A special model type for testing.");

        [Fact]
        public void TestSetId()
        {
            Assert.Equal(1, _model.Id);
        }

        [Fact]
        public void TestChangeName()
        {
            var newName = "The Other Type.";
            _model.Name = newName;
            Assert.Equal(newName, _model.Name);
        }

        [Fact]
        public void TestChangeDescription()
        {
            var newDescription = "Another model type.";
            _model.Description = newDescription;
            Assert.Equal(newDescription, _model.Description);
        }
    }

    public class ItemTypeCommandTests
    {
        
    }
    
}