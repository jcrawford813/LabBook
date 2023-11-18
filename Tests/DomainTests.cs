namespace Tests;

using System.Reflection.Metadata.Ecma335;
using LabBook.Domain;

public class DomainTests
{
    public class ItemTests
    {
        private readonly string _name = "This Item";
        private const int _id = 21;
        private readonly string _notes = "This is an item that I am testing.";

        [Fact]
        public void TestItemCreation()
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
}