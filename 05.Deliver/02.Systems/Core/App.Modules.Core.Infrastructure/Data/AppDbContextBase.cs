
using System.Threading;
using System.Threading.Tasks;
using App.Modules.Core.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data
{
    public abstract class AppDbContextBase : DbContext
    {
        bool _okToSave = false;
        public void PrepareToSave()
        {
            _okToSave = true;
        }

        IAppDbContextManagementService _appDbContextManagementService;

        protected AppDbContextBase(IAppDbContextManagementService appDbContextManagementService, DbContextOptions<AppDbContextBase> options) : base(options) 
        {
            _appDbContextManagementService = appDbContextManagementService;

            _appDbContextManagementService.Register(this);


        }

        protected AppDbContextBase(IAppDbContextManagementService appDbContextManagementService) : base()
        {
            _appDbContextManagementService = appDbContextManagementService;
            _appDbContextManagementService.Register(this);
        }
        protected AppDbContextBase()
        {
            //Old:
            //Database.CommandTimeout = System.Math.Max(dbConnection.ConnectionTimeout, 30);
            //this.Database.Log = s => Trace.WriteLine(s);

        }

        public override int SaveChanges()
        {
            if (_okToSave)
            {
                return 0;
            }
            _okToSave = false;
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            if (_okToSave)
            {
                return 0;
            }
            _okToSave = false;
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            if (_okToSave)
            {
                ;
            }
            _okToSave = false;
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if (_okToSave)
            {
                return Task.FromResult(0);
            }
            _okToSave = false;
            return base.SaveChangesAsync(cancellationToken);
        }



        //// Intercept all saves in order to clean up loose ends
        //public override int SaveChanges()
        //{
        //    var dbContextPreCommitService =
        //        AppDependencyLocator.Current.GetInstance<IDbContextPreCommitService>();

        //    dbContextPreCommitService.PreProcess(this);

        //    return base.SaveChanges();
        //}

        //public override Task<int> SaveChangesAsync()
        //{
        //    var dbContextPreCommitService =
        //        AppDependencyLocator.Current.GetInstance<IDbContextPreCommitService>();

        //    dbContextPreCommitService.PreProcess(this);

        //    return base.SaveChangesAsync();
        //}

    }
}

