using Application.Interfaces;
using Application.Locations;

namespace Tests;

public partial class ApplicationTests
{
    public class LocationQueryTests
    {
        public LocationQueryTests()
        {
            var mock = new AutoMocker();

            var locations = new List<Location>()
            {
                new(1, "This Location"),
                new(2, "That Location", new(1, "This Location")),
                new(3, "One Last Place.")
            };

            mock.GetMock<IRepository<Location>>()
                .Setup(l => l.GetAll())
                .Returns(locations.AsQueryable());
            
            mock.GetMock<IRepository<Location>>()
                .Setup(l => l.Get(1))
                .Returns(locations.SingleOrDefault(l => l.Id == 1));

            mock.GetMock<IRepository<Location>>()
                .Setup(l => l.Get(4))
                .Returns(value:null);
            
            mock.GetMock<IDatabase>()
                .Setup(d => d.Locations)
                .Returns(mock.GetMock<IRepository<Location>>().Object);

            _queries = new LocationQueries(mock.GetMock<IDatabase>().Object);
        }
        public readonly ILocationQueries _queries;

        [Fact]
        public void TestGetAllLocations()
        {
            var filter = String.Empty;
            var results = _queries.GetLocations(filter);
            Assert.Equal(3, results.Count);
        }

        [Fact]
        public void TestGetAllLocationsFilterByDescription()
        {
            var filter = "Location";
            var results = _queries.GetLocations(filter);
            Assert.Equal(2, results.Count);
        }

        [Fact]
        public void TestGetLocationById()
        {
            var id = 1;
            var result = _queries.GetLocation(id);
            Assert.Equal(id, result?.Id);
        }

        [Fact]
        public void TestGetLocationByInvalidId()
        {
            var result = _queries.GetLocation(4);
            Assert.Null(result);
        }
    }

    public class LocationModelTests
    {
        private readonly Location _model = new(1, "This Location");

        [Fact]
        public void TestUpdateDescription()
        {
            var newDescription = "Another location.";
            _model.Description = newDescription;
            Assert.Equal(newDescription, _model.Description);
        }

        [Fact]
        public void TestAddParent()
        {
            Location newParent = new(2, "Parent Location.");
            _model.ParentLocation = newParent;
            Assert.Equal(2, _model.ParentLocation.Id);
        }

    }

    public class LocationCommandTests
    {
        public LocationCommandTests()
        {
            var mock = new AutoMocker();

            var locations = new List<Location>()
            {
                new(1, "This Location"),
                new(2, "That Location", new(1, "This Location")),
                new(3, "One Last Place.")
            };

            mock.GetMock<IRepository<Location>>()
                .Setup(l => l.GetAll())
                .Returns(locations.AsQueryable());

            mock.GetMock<IRepository<Location>>()
                .Setup(l => l.Get(1))
                .Returns(locations.SingleOrDefault(l => l.Id == 1));

            mock.GetMock<IRepository<Location>>()
                .Setup(l => l.Get(4))
                .Returns(value:null);

            mock.GetMock<IDatabase>()
                .Setup(d => d.Locations)
                .Returns(mock.GetMock<IRepository<Location>>().Object);

            _commands = new LocationCommands(mock.GetMock<IDatabase>().Object);
        }

        public readonly ILocationCommands _commands;

        [Fact]
        public void TestAddLocationWithNoError()
        {
            var location = new LocationModel(4, "New Location");
            _commands.AddLocation(location);
            Assert.True(true);
        }

        [Fact]
        public void TestRemoveLocationWithNoError()
        {
            var location = new LocationModel(1, "This Location");
            _commands.RemoveLocation(location);
            Assert.True(true);
        }

    }

}