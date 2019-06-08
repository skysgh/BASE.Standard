//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using App.Modules.Core.Infrastructure.Data.Db;
//using App.Modules.Core.Shared.Models.Entities;
//using Microsoft.AspNetCore.Mvc;

//namespace App.Modules.Core.AppFacade.Controllers
//{
//    public class CallbackController : Controller
//    {
//        private readonly CoreModuleDbContext _coreModuleDbContext;

//        public InvitationController(CoreModuleDbContext coreModuleDbContext)
//        {
//            _coreModuleDbContext = coreModuleDbContext;
//        }

// ModuleName allows for invoking the correct 
// Key indicates what Command to invoke (Invitation, etc.)
// Id is to find the right record
// But not sure how to invoke the right class/method/logic... (the Db record would not be enough info)
//        public async Task<IActionResult> Index(string moduleName, string operationKey, Guid id)
//        {
//            Guid invitationId = id;

//            Invitation invitation =
//                _coreModuleDbContext.Set<Invitation>().SingleOrDefault(x => x.Id == invitationId);

//            if (invitation == null)
//            {
//                //
//                HttpContext.Response.Redirect("/");
//                return null;
//            }

//            string emailAddress = invitation.PrincipalEmail;
//            Principal principal=null;

//            var tmp = _coreModuleDbContext.Set<Principal>()
//                //.Where(p => p.Logins.Any(c => c.IdPLogin == emailAddress))
//                .Select(p => new
//                {
//                    Parent = p,
//                    Children = p.Logins.Where(c => c.IdPLogin == emailAddress)
//                })
//                .FirstOrDefault();
//            if (tmp != null)
//            {
//                //Did not find Principal.
//                principal = tmp.Parent;
//            }

//            if (principal == null)
//            {
//                principal = new Principal();
//                principal.DisplayName = invitation.DisplayName ?? "Not Set";

//            }


//            HttpContext.Response.Redirect("/");
//        }
//    }
//}
