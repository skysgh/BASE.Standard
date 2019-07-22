using System;
using System.Linq;
using App.Modules.Core.Common.Tests.Attributes;
using App.Modules.Core.Infrastructure.DependencyResolution;
using App.Modules.Core.Infrastructure.Tests;
using App.Modules.Core.Shared.Models.DTOs;
using App.Modules.Core.Shared.Models.Entities;
using FluentAssertions;

namespace App.Modules.Core.AppFacade.Tests
{
    public class CorePrincipalMappingTests : TestClassBase
    {

        [SelfNamingFact()]
        public void MapPrincipalCategory()
        {

            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IObjectMappingService
                    >();

            var source = new PrincipalCategory();

            source.Title = "Some Title";
            source.Description = "Some Description";
            source.DisplayOrderHint = 123;
            source.DisplayStyleHint = "foo";
            source.Enabled = true;

            var target =
                service.Map<PrincipalCategory, PrincipalCategoryDto>(source);

            target.Text.Should().Be("Some Title");
            target.Description.Should().Be("Some Description");
            target.DisplayOrderHint.Should().Be(123);
            target.DisplayStyleHint.Should().Be("foo");
            target.Enabled = true;

        }


        [SelfNamingFact()]
        public void MapPrincipalProperty()
        {

            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IObjectMappingService
                    >();

            var source = new PrincipalProperty();

            source.Key = "Some Key";
            source.Value = "Some Value";
            source.PrincipalFK = 123.ToGuid();

            var target =
                service.Map<PrincipalProperty, PrincipalPropertyDto>(source);

            target.Key.Should().Be("Some Key");
            target.Value.Should().Be("Some Value");
            target.PrincipalFK.Should().Be(123.ToGuid());

        }




        [SelfNamingFact()]
        public void MapPrincipalClaim()
        {

            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IObjectMappingService
                    >();

            var source = new PrincipalClaim();

            source.Key = "SomeKey";
            source.Value = "SomeValue";
            source.Authority = "SomeAuthority";
            source.AuthoritySignature = "Blah";
            source.PrincipalFK = 123.ToGuid();

            var target =
                service.Map<PrincipalClaim, PrincipalClaimDto>(source);

            target.Key.Should().Be("SomeKey");
            target.Value.Should().Be("SomeValue");
            target.Authority.Should().Be("SomeAuthority");
            target.AuthoritySignature.Should().Be("Blah");
            target.PrincipalFK.Should().Be(123.ToGuid());


        }



        [SelfNamingFact()]
        public void MapPrincipalTag()
        {

            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IObjectMappingService
                    >();

            var source = new PrincipalTag();

            source.Title = "Some Title";
            source.Description = "Some Description";
            source.DisplayOrderHint = 123;
            source.DisplayStyleHint = "foo";
            source.Enabled = true;

            var target =
                service.Map<PrincipalTag, PrincipalTagDto>(source);

            target.Text.Should().Be("Some Title");
            target.Description.Should().Be("Some Description");
            target.DisplayOrderHint.Should().Be(123);
            target.DisplayStyleHint.Should().Be("foo");
            target.Enabled = true;

        }




        [SelfNamingFact()]
        public void MapPrincipal()
        {

            var service =
                DependencyLocator.Current
                    .GetInstance<Infrastructure.Services.IObjectMappingService
                    >();

            var source = new Principal();

            var now = DateTimeOffset.Now;
            source.DisplayName = "Some Title";
            source.FullName = "Some Description";
            source.EnabledBeginningUtcDateTime = now;
            source.EnabledEndingUtcDateTime = now;
            source.Enabled = true;

            source.Category = new PrincipalCategory()
            {
                Title = "Some Title",
                Description = "Some Description",
                DisplayOrderHint = 123,
                DisplayStyleHint = "foo",
                Enabled = true

            };


        source.DataClassification =
                new DataClassification()
                {
                    Id = NZDataClassification.InConfidence,
                    Title = "Foo",
                    Description = "Bar",
                    DisplayOrderHint = 1,
                    DisplayStyleHint = "X",
                    Enabled = true
                };
            source.Category = new PrincipalCategory()
            {
                Title = "Some Title",
                Description = "Some Description",
                DisplayOrderHint = 123,
                DisplayStyleHint = "foo",
                Enabled = true,
            };

            source.Properties.Add(
                new PrincipalProperty()
                {
                    Id = 123.ToGuid(),
                    Key = "Some Key",
                    Value = "Some Value",
                    PrincipalFK = 123.ToGuid()
                }
                );

            source.Claims.Add(
                new PrincipalClaim()
                {
                    Key = "SomeKey",
                    Value = "SomeValue",
                    Authority = "SomeAuthority",
                    AuthoritySignature = "Blah",
                    PrincipalFK = 123.ToGuid()
                });


            // Not sure if it is mapped across before it is saved:
            // TUrns out it isn't:
            //source.DataClassificationFK.Should()
            //    .Be(NZDataClassification.InConfidence);

            var target =
                service.Map<Principal, PrincipalDto>(source);

            target.DisplayName.Should().Be("Some Title");
            target.FullName.Should().Be("Some Description");
            target.Enabled.Should().Be(true);
            //
            target.Category.Text.Should().Be("Some Title");
            // 
            target.DataClassification.Id.Should()
                .Be(NZDataClassification.InConfidence);
            target.DataClassification.Title.Should().Be("Foo");
            //
            target.Properties.Count.Should().Be(1);
            target.Properties.First().Key.Should().Be("Some Key");
            //
            target.Claims.Count.Should().Be(1);
            target.Claims.First().Key.Should().Be("SomeKey");
            //
        }
    }
}
