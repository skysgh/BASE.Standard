namespace App.Modules.Core.Infrastructure
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

    /// <summary>
    /// <para>
    /// See  <see cref="IHasInitialized"/>
    /// and <see cref="IHasInitialize"/>
    /// </para>
    /// <para>
    /// Resets the flag behind <see cref="IHasInitialized.Initialized"/>
    /// (which is often a static field)
    /// </para>
    /// </summary>
    public interface IHasResetInitialization
    {
        void Reset();
    }
}