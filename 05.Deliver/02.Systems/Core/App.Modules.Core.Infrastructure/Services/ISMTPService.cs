using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface ISmtpService : IAppModuleCoreService
    {
        void SendMessage(string toAddress, string subject, string body);
    }
}
