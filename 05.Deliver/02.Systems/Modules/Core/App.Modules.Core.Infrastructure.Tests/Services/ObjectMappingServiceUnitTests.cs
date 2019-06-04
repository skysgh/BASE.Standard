using System;
using App.Modules.Core.Infrastructure.Services.Implementations;
using App.Modules.Core.Models.Entities;
using Xunit;

namespace App.Modules.Core.Infrastructure.Tests.Services
{
    public class ObjectMappingServiceUnitTests : TestClassBase
    {


        [Fact]
        void MapSomethingTrivial()
        {
            throw new NotImplementedException();

            //ObjectMappingServiceConfiguration config = new ObjectMappingServiceConfiguration();

            //IObjectMappingService service = new ObjectMappingService(config);

            //ExampleModel m = new ExampleModel();

            //m.Id = Guid.NewGuid();


            //var r = service.Map<ExampleModel,ExampleModel>(m);

            //Assert.NotEqual<Guid>(Guid.Empty, r.Id);
        }

        [Fact]
        void MapSomething()
        {


            var service =
    DependencyLocator.Current
    .GetInstance<Infrastructure.Services.IObjectMappingService>();



            Principal m = new Principal();

            m.Id = Guid.NewGuid();


            var r = service.Map<Principal, Principal>(m);

            Assert.NotEqual<Guid>(Guid.Empty, r.Id);
        }

    }
}
