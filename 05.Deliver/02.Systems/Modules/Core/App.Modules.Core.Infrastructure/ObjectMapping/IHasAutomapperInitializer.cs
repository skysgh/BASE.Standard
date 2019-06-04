using App.Modules.Core.Shared.Contracts;
using AutoMapper;

namespace App.Modules.Core.Infrastructure.ObjectMapping
{
    /// <summary>
    ///     Contract implemented by AutoMapper configuration elements.
    /// </summary>
    public interface IHasAutomapperInitializer : IHasInitialize<IMapperConfigurationExpression>
    {
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        void Initialize(IMapperConfigurationExpression config);
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
                              /*
                               * An example might be:  
                                  public class ObjectMap_Example_ExampleDto : IHasAutomapperInitializer    {
                                      public static void Initialize(IMapperConfigurationExpression config) {
                                          config.CreateMap<Example, ExampleDto>()
                                              .ForMember(t => t.Id, opt => opt.MapFrom(s => s.Id))
                                              ;
                                      }
                                  }
                               */
    }
}