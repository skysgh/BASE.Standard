namespace App.Modules.Core.Shared.Models.Entities
{

    /// <summary>
    /// 
    /// <para>
    /// TODO: Enums are evil (offset issue of Interface Localization)
    /// </para>
    /// </summary>
    public enum RecordPersistenceState
    {
        /// <summary>
        /// The record is active (default value).
        /// </summary>
        Active = 0,

        /// <summary>
        /// Valid, but archived.
        /// <para>
        /// Pretty sure this is invalid for a Record State -- ok for an EntityState, but that's different: Disabled=true,
        /// </para>
        /// </summary>
        Archived = 1,

        /// <summary>
        /// The value is superseded by another record.
        /// <para>
        /// Note that the record should define whom it
        /// was superced by (for navigating to it).
        /// </para>
        /// </summary>
        Superseded = 2,

        /// <summary>
        /// The record was merged into another record.
        /// <para>
        /// The target message should indicate whom it was merged
        /// from, in order to provide Undo facilities.
        /// </para>
        /// </summary>
        Merged = 4,
        /// <summary>
        /// To dispose .
        /// </summary>
        ToDispose = 8 /*Garbage*/,
        
        /// <summary>
        /// Logical deletion (there should be no physical deletion).
        /// </summary>
        Disposed = 16
    }
}