using System;
using AutoMapper;
using FluentAssertions;
using GenFu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Website.Core.Common.Dtos;
using Website.Core.Repository.Interface;
using Website.Core.System.Services;

namespace Website.Tests.Website.Core.System.Services
{
    [TestClass]
    public class SystemServiceTest
    {
        private static readonly Guid WebsiteGuid = Guid.NewGuid();
        private WebsiteDto _websiteDto;
        private global::Website.Core.Models.Website _website;

        [TestInitialize]
        public void Initialize()
        {
            _website = A.New<global::Website.Core.Models.Website>();
            _website.Id = WebsiteGuid;

            _websiteDto = new WebsiteDto
            {
                Id = _website.Id
            };
        }

        [TestMethod]
        public void WebsiteDto_WithCacheNotExists_ShouldRepositoryAndMappingCalled()
        {
            // Arrange
            var cacheService = Mock.Of<ICacheService>(service => service.Exists<WebsiteDto>(WebsiteGuid.ToString()) == false);
            var websiteRepository = Mock.Of<IWebsiteRepository>(i => i.Get(WebsiteGuid) == _website);
            var mapper = Mock.Of<IMapper>(i => i.Map<WebsiteDto>(_website) == _websiteDto);
            var configurationService = Mock.Of<IConfigurationService>(service => service.WebsiteGuid == WebsiteGuid);

            var systemService = new SystemService(null, websiteRepository, null, null, null, configurationService, cacheService, mapper);

            // Act
            var result = systemService.Website;

            // Assert
            result.Id.Should().Be(WebsiteGuid);
            Mock.Get(cacheService).Verify(i => i.Exists<WebsiteDto>(WebsiteGuid.ToString()), Times.Once);
            Mock.Get(websiteRepository).Verify(i => i.Get(WebsiteGuid), Times.Once);
            Mock.Get(mapper).Verify(i => i.Map<WebsiteDto>(_website), Times.Once);
        }
    }
}