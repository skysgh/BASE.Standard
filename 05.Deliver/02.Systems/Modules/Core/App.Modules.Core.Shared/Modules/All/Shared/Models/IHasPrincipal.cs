using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for entities that provide navigation to the Principal.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasPrincipalFK" />
    interface IHasPrincipal : IHasPrincipalFK
    {
        /// <summary>
        /// Gets or sets the <see cref="Principal"/>.
        /// </summary>
        Principal Principal { get; set; }

    }


}
