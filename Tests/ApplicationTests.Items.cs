using Application;
using Application.Interfaces;
using Application.Items;
using Moq.AutoMock.Resolvers;

namespace Tests;

public partial class ApplicationTests
{

    public class ItemQueryTests
    {
        private readonly IDatabase _database;
        private readonly ItemQueries _queries;

        public ItemQueryTests()
        {
            var mock = new AutoMocker();

            var items = new List<Item>()
            {
                new Item(1, "Item 1", "This or that."),
                new Item(2, "Cat", "A cat."),
                new Item(3, "Item 3", "That or this.")
            };


            mock.GetMock<IRepository<Item>>()
                .Setup(r => r.GetAll())
                .Returns(items.AsQueryable());
            
            mock.GetMock<IRepository<Item>>()
                .Setup(r => r.Get(1))
                .Returns(items.Single(i => i.Id == 1));

            mock.GetMock<IRepository<Item>>()
                .Setup(r => r.Get(4))
                .Returns(value:null!);
            
            mock.GetMock<IDatabase>()
                .Setup(d => d.Items)
                .Returns(mock.GetMock<IRepository<Item>>().Object);

            _database = mock.GetMock<IDatabase>().Object;
            _queries = new ItemQueries(_database);
        }

        [Fact]
        public void TestQueryAllItems()
        {
            var results = _queries.GetItems("");
            Assert.Equal(3, results.Count);
        }

        [Fact]
        public void TestQueryItemFilteredByName()
        {
            var results = _queries.GetItems("Item");
            Assert.Equal(2, results.Count);
        }

        [Fact]
        public void TestQueryItemFilteredByDescription()
        {
            var results = _queries.GetItems("cat");
            Assert.Single(results);
        }

        [Fact]
        public void TestQueryById()
        {
            var result = _queries.GetItem(1);
            Assert.Equal(1, result?.Id);
        }

        [Fact]
        public void TestQueryByIdNotFound()
        {
            var result = _queries.GetItem(4);
            Assert.Null(result);
        }
    }

    public class ItemModelTests
    {
        private readonly ItemModel _model = new(1, "Test Item", "Some Notes about the item.", 1, 1);

        [Fact]
        public void TestChangeName()
        {
            var newName = "New Item";
            _model.Name = newName;
            Assert.Equal(newName, _model.Name);
        }

        [Fact]
        public void TestChangeNotes()
        {
            var newNotes = "Changing the Notes";
            _model.Notes = newNotes;
            Assert.Equal(newNotes, _model.Notes);
        }

        [Fact]
        public void TestChangeLocation()
        {
            var newLocation = 2;
            _model.LocationId = newLocation;
            Assert.Equal(newLocation, _model.LocationId);
        }

        [Fact]
        public void TestChangeItemType()
        {
            var newItemType = 2;
            _model.ItemTypeId = newItemType;
            Assert.Equal(newItemType, _model.ItemTypeId);
        }
    }

    public class ItemCommandTests
    {
        public ItemCommandTests()
        {
            var mock = new AutoMocker();
            
            mock.GetMock<IDatabase>()
                .Setup(d => d.Items)
                .Returns(mock.GetMock<IRepository<Item>>().Object);
            
            _database = mock.GetMock<IDatabase>().Object;
            _commands = new ItemCommands(_database);
        }

        private readonly IDatabase _database;

        private readonly IItemCommands _commands;

        private readonly ItemModel _model = new(1,  "Test Item", "Notes for Test Item.", 1, 1);

        [Fact]
        public void TestAddItemWithNoError()
        {
            _commands.AddItem(_model);
            Assert.True(true);
        }

        [Fact]
        public void TestRemoveItemWithNoError()
        {
            _commands.RemoveItem(_model);
            Assert.True(true);
        }
    }
    
}