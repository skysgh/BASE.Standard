using App.Modules.All.Infrastructure.Initialization;
using App.Modules.All.Shared.Initialization;
using AutoMapper;

namespace App.Modules.All.Infrastructure.ObjectMapping
{
    /// <summary>
    ///     Contract implemented by AutoMapper configuration elements.
    /// </summary>
    public interface IHasAutomapperInitializer : 
        IHasInitialize<IMapperConfigurationExpression>,
        IModuleInitializer
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