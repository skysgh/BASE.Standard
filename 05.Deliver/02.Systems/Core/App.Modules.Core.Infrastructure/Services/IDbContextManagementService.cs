using App.Modules.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IAppDbContextManagementService
    {
        void Register(AppDbContextBase dbContext);

    }
}
