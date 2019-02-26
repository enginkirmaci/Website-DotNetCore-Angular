//using System;
//using AutoMapper;
//using Common.Web.Data;
//using GenFu;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Website.Core.Application.Constants;
//using Website.Core.Repository.Interface;

//namespace Website.Tests.Service
//{
//    [TestClass]
//    public class WebsiteServiceTest
//    {
//        private static readonly Guid WebsiteGuid = Guid.NewGuid();
//        private Models.Website _website;

//        [TestInitialize]
//        public void Initialize()
//        {
//            _website = A.New<Models.Website>();
//            _website.Id = WebsiteGuid;
//        }

//        [TestCleanup]
//        public void Dispose()
//        {
//        }

//        [TestMethod]
//        public void Website_WithCacheNotExists_ShouldRepositoryAndMappingCalledOnce()
//        {
//            // Arrange
//            var cachingEx = Mock.Of<ICachingEx>(i => i.Exists(CacheKeys.WebsitePrefix + WebsiteGuid) == false);
//            var websiteRepository = Mock.Of<IWebsiteRepository>(i => i.Get(WebsiteGuid) == _website);
//            var mapper = Mock.Of<IMapper>(i => i.Map<Common.Dtos.Website>(_website) == new Common.Dtos.Website());

//            var websiteService = getService(websiteRepository, cachingEx, mapper);

//            // Act
//            var result = websiteService.Website;

//            // Assert
//            Mock.Get(cachingEx).Verify(i => i.Exists(CacheKeys.WebsitePrefix + WebsiteGuid), Times.Once);
//            Mock.Get(websiteRepository).Verify(i => i.Get(WebsiteGuid), Times.Once);
//            Mock.Get(mapper).Verify(i => i.Map<Common.Dtos.Website>(_website), Times.Once);
//        }

//        [TestMethod]
//        public void Website_WithCacheExists_ShouldCacheGetCalledOnce()
//        {
//            // Arrange
//            var cachingEx = Mock.Of<ICachingEx>(i =>
//                i.Exists(CacheKeys.WebsitePrefix + WebsiteGuid) == true &&
//                i.Get<Common.Dtos.Website>(CacheKeys.WebsitePrefix + WebsiteGuid) == new Common.Dtos.Website());

//            var websiteService = getService(null, cachingEx, null);

//            // Act
//            var result = websiteService.Website;

//            // Assert
//            Mock.Get(cachingEx).Verify(i => i.Exists(CacheKeys.WebsitePrefix + WebsiteGuid), Times.Once);
//            Mock.Get(cachingEx).Verify(i => i.Get<Common.Dtos.Website>(CacheKeys.WebsitePrefix + WebsiteGuid), Times.Once);
//        }

//        private WebsiteService getService(IWebsiteRepository websiteRepository, ICachingEx cachingEx, IMapper mapper)
//        {
//            var websiteService = new WebsiteService(websiteRepository, null, null, cachingEx, mapper);
//            websiteService.Configure(WebsiteGuid);

//            return websiteService;
//        }
//    }
//}