using System;
using App.Modules.Core.Common.Tests.Attributes;
using App.Modules.Core.Infrastructure.Tests;
using Microsoft.AspNetCore.Http;
using Xunit;
using FluentAssertions;
using App.Modules.Core.Infrastructure.DependencyResolution;

namespace App.Modules.Core.AppFacade.Tests
{
    public class UnitTest1 : TestClassBase
    {
        /// <summary>
        /// Determines whether
        /// the fake/factoried HttpContext
        /// is retrieved.
        /// </summary>
        [SelfNamingFact()]
        public void CanDependencyServiceRetrieveFakeHttpContextAccessor()
        {
            var service =
                DependencyLocator.Current.GetInstance<IHttpContextAccessor>();
            Assert.NotNull(service);
            
        }
        [SelfNamingFact()]
        public void CanDependencyServiceRetrieveFakeHttpContext()
        {
            var service =
                DependencyLocator.Current.GetInstance<IHttpContextAccessor>();


            Assert.NotNull(service.HttpContext);

        }
        [SelfNamingFact()]
        public void CanDependencyServiceRetrieveFakeHttpContextItems()
        {
            var service =
                DependencyLocator.Current.GetInstance<IHttpContextAccessor>();

            service.HttpContext.Items["Foo"] = "Bar";
            Assert.Equal("Bar", service.HttpContext.Items["Foo"]);

        }
        [SelfNamingFact()]
        public void CanDependencyServiceRetrievesSameFakeHttpContextAccessorEveryTime()
        {
            var service1 =
                DependencyLocator.Current.GetInstance<IHttpContextAccessor>();

            var service2 =
                DependencyLocator.Current.GetInstance<IHttpContextAccessor>();

            Assert.Equal(service1,service2);

        }
    }
}
