using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Website.Tests.Repository
{
    [TestClass]
    public class ContentRepositoryTest
    {
        //private WebsiteDbContext _context;
        //private static readonly Guid _websiteGuid = Guid.NewGuid();

        //[TestInitialize]
        //public void Initialize()
        //{
        //    var dataContextOptions = new DbContextOptionsBuilder<WebsiteDbContext>()
        //      .UseInMemoryDatabase(databaseName: "Memory_Database" + DateTime.Now.Ticks)
        //      .Options;

        //    _context = new WebsiteDbContext(dataContextOptions);

        //    var website = A.New<Models.Website>();
        //    website.Id = _websiteGuid;

        //    A.Configure<Page>().Fill(i => i.WebsiteId, () => website.Id);
        //    List<Page> pages = A.ListOf<Page>(5);
        //    pages[3].Id = 50;

        //    A.Configure<TextContent>().Fill(i => i.PageId, () => pages[0].Id);
        //    List<Content> contents = A.ListOf<Content>(10);
        //    contents[7].Id = 100;

        //    pages[0].Content = contents;
        //    website.Page = pages;

        //    _context.Website.Add(website);
        //    _context.SaveChanges();
        //}

        //[TestCleanup]
        //public void Dispose()
        //{
        //    _context = null;
        //}

        //[TestMethod]
        //public void Get_WithExistingKey_ShouldReturn()
        //{
        //    // Arrange
        //    var contentRepository = new ContentRepository(_context);
        //    long expected = 100;

        //    // Act
        //    var result = contentRepository.Get(expected);

        //    // Assert
        //    result.Id.Should().Be(expected);
        //}

        //[TestMethod]
        //public void GetList_WithNothing_ShouldReturn()
        //{
        //    // Arrange
        //    var contentRepository = new ContentRepository(_context);

        //    // Act
        //    var result = contentRepository.GetList();

        //    // Assert
        //    result.Should().NotBeEmpty();
        //}

        //[TestMethod]
        //public void Delete_WithEntity_ShouldBeDeleted()
        //{
        //    // Arrange
        //    var contentRepository = new ContentRepository(_context);
        //    var expected = contentRepository.Get((decimal)100);

        //    // Act
        //    var result = contentRepository.Delete(expected);
        //    contentRepository.Save();

        //    // Assert
        //    result.State.Should().Be(EntityState.Detached);
        //}

        //[TestMethod]
        //public void Update_WithEntity_ShouldUpdated()
        //{
        //    // Arrange
        //    var contentRepository = new ContentRepository(_context);
        //    var expected = contentRepository.Get((decimal)100);
        //    expected.Title = "Updated";
        //    expected.UpdatedDate = null;

        //    // Act
        //    contentRepository.Update(expected);
        //    contentRepository.Save();

        //    // Assert
        //    expected.Title.Should().Be("Updated");
        //    expected.UpdatedDate.Should().NotBeNull();
        //}
    }
}