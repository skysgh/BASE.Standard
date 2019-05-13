using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IPlantUmlDiagramingService
    {
        string DevelopImageUrl(string umlText);
        byte[] DevelopImageByteArray(string umlText);

    }
}
