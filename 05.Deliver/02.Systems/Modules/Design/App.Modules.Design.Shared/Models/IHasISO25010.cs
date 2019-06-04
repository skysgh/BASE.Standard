using App.Modules.Core.Shared.Models.Messages.Enums;

namespace App.Modules.Design.Shared.Models
{
    public interface IHasISO25010
    {
        ISO25010 ISO25010Quality { get; set; }
    }
}