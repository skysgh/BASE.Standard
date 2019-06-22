using App.Modules.Core.Common.Tests.Attributes;
using App.Modules.Core.Infrastructure.DependencyResolution;
using App.Modules.Core.Infrastructure.Tests;
using App.Modules.Core.Shared.Models.Entities;
using FluentAssertions;

namespace App.Modules.Core.AppFacade.Tests
{
    public class CoreDataClassificationTests : TestClassBase
    {

        [SelfNamingFact()]
        public void MapDataClassification()
        {

            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IObjectMappingService
                    >();

            var source = new DataClassification()
            {
                Id = NZDataClassification.InConfidence,
                Title = "Foo",
                Description = "Bar",
                DisplayOrderHint = 1,
                DisplayStyleHint = "X",
                Enabled = true
            };



            var target =
                service.Map<DataClassification, DataClassification>(source);

            target.Id.Should().Be(NZDataClassification.InConfidence);
            target.Title.Should().Be("Foo");
            target.Description.Should().Be("Bar");
            target.DisplayOrderHint.Should().Be(1);
            target.DisplayStyleHint.Should().Be("X");
            target.Enabled.Should().Be(true);

        }
    }
}
