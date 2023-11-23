namespace Tests;

public class DomainTests
{
    public class ItemTests
    {
        private readonly string _name = "This Item";
        private const int _id = 21;
        private readonly string _notes = "This is an item that I am testing.";

        [Fact]
        public void TestCreateItem()
        {
            var item = new Item(_id, _name, _notes);
            Assert.NotNull(item);
        }

        [Fact]
        public void TestSetName()
        {
            var item = new Item(_id, _name, _notes);
            item.Name = _name;
            Assert.Equal(_name, item.Name);
        }

        [Fact]
        public void TestSetId()
        {
            var item = new Item(_id, _name, _notes);
            Assert.Equal(_id, item.Id);
        }

        [Fact]
        public void TestSetNotes()
        {
            var item = new Item(_id, _name, _notes);
            item.Notes = _notes;
            Assert.Equal(_notes, item.Notes);
        }
    }

    public class ItemTypeTests
    {
        private readonly string _name = "This Type";
        private readonly string _description = "A test item type.";
        private const int _id = 2;

        [Fact]
        public void TestCreateItemType()
        {
            var itemType = new ItemType(_id, _name, _description);
            Assert.NotNull(itemType);
        }

        [Fact]
        public void TestSetName()
        {
            var newName = "Changed Name";
            var itemType = new ItemType(_id, _name, _description);
            itemType.Name = newName;
            Assert.Equal(newName, itemType.Name);
        }

        [Fact]
        public void TestSetDescription()
        {
            var newDescription = "Changed description";
            var itemType = new ItemType(_id, _name, _description);
            itemType.Description = newDescription;
            Assert.Equal(newDescription, itemType.Description);
        }
    }

    public class LocationTests
    {
        private const int _id = 10;
        private readonly string _description = "A Location Here.";
        private readonly Location _parentLocation = new(22, "A shelf in here.");

        [Fact]
        public void TestCreateLocation()
        {
            var location = new Location(_id, _description);
            Assert.NotNull(location);
        }

        [Fact]
        public void TestChangeDescription()
        {
            var newDescription = "That Location";
            var location = new Location(_id, _description);
            location.Description = newDescription;
            Assert.Equal(newDescription, location.Description);
        }

        [Fact]
        public void TestSetParentLocation()
        {
            var location = new Location(_id, _description);
            location.ParentLocation = _parentLocation;
            Assert.Equal(_parentLocation, location.ParentLocation); //Testing reference out of laziness.
        }

        [Fact]
        public void TestRemoveSublocation()
        {
            var location = new Location(_id, _description, _parentLocation);
            location.ParentLocation = null;
            Assert.Null(location.ParentLocation);
        }
    }
}