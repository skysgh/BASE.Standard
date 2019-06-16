namespace App.Modules.All.Infrastructure.Contracts
{
    public interface IHasInitialized
    {
        /// <summary>
        /// Is the object/service initialized?
        /// <para>
        /// See  <see cref="IHasResetInitialization"/>
        /// </para>
        /// <para>
        /// Implementation Detail: 
        /// for Service Configuration objects 
        /// the Instance property most often is used to 
        /// expose a private *static* filed.
        /// </para>
        /// </summary>
        bool Initialized { get; }
    }
}