using System;
using App.Modules.Core.Common.Tests.Attributes;
using App.Modules.Core.Infrastructure.DependencyResolution;
using App.Modules.Core.Shared.Models.Entities;
using Xunit;

namespace App.Modules.Core.Infrastructure.Tests.Services
{
    public class ObjectMappingServiceUnitTests : TestClassBase
    {

        [SelfNamingFact]
        public void CanRetrieveObjectMappingService()
        {
            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IObjectMappingService>();

            Assert.NotNull(service);
        }

        [SelfNamingFact]
        public void MapSomethingTrivialLikeADataClassificationObject()
        {
            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IObjectMappingService>();

            var dataClassification = 
                new DataClassification();
            dataClassification.Id = NZDataClassification.Confidential;

            var r = service.Map<DataClassification, DataClassification>(dataClassification);

            Assert.Equal<NZDataClassification>(NZDataClassification.Confidential, r.Id);
        }

        [SelfNamingFact]
        void MapSomethingMoreComplexLikeAPrincipal()
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
