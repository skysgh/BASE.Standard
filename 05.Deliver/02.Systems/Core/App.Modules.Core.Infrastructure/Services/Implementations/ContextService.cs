//namespace App.Modules.Core.Infrastructure.Services.Implementations
//{
//    using System.Web;

//    /// <summary>
//    ///     Implementation of the
//    ///     <see cref="IContextService" />
//    ///     Infrastructure Service Contract
//    /// </summary>
//    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IContextService" />
//    public class ContextService : AppCoreServiceBase, IContextService
//    {
//        private readonly IHttpContextAccessor _httpContextAccessor;

//        public ContextService(IHttpContextAccessor httpContextAccessor)
//        {
//            _httpContextAccessor = httpContextAccessor;
//        }
//        public void Set(string key, object value)
//        {
//            _httpContextAccessor.
//            HttpContext.Current.Items[key] = value;
//        }

//        public object Get(string key)
//        {
//            return HttpContext.Current.Items[key];
//        }
//    }
//}