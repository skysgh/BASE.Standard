using App.Modules.Core.Shared.Models.Implementations;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Services.Implementations;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace App.Modules.Core.Infrastructure.Tests.Services
{
    public class ObjectMappingServiceUnitTests : TestClassBase
    {
   

        [Fact]
        void MapSomethingTrivial()
        {
            IObjectMappingService service = new ObjectMappingService();

            ExampleModel m = new ExampleModel();

            m.Id = Guid.NewGuid();


            var r = service.Map<ExampleModel,ExampleModel>(m);

            Assert.NotEqual<Guid>(Guid.Empty, r.Id);
        }

        [Fact]
        void MapSomething()
        {


            var service =
    DependencyLocator.Current
    .GetInstance<Infrastructure.Services.IObjectMappingService>();



            ExampleModel m = new ExampleModel();

            m.Id = Guid.NewGuid();


            var r = service.Map<ExampleModel, ExampleModel>(m);

            Assert.NotEqual<Guid>(Guid.Empty, r.Id);
        }

    }
}
