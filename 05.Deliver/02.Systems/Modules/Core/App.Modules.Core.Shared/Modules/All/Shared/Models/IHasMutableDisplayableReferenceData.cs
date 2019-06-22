// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     <para>
    ///         Any mutable model should have a Guid Id as opposed to an integer Id. Hence <see cref="IHasGuidId" />
    ///     </para>
    ///     <para>
    ///         Resource data have <see cref="IHasEnabled" />because
    ///         an item can be disabled (eg a list of countries may have
    ///         current trade sanctions against North Korea or other country).
    ///     </para>
    ///     <para>
    ///         Resource data should offer a *default* order hint (0 being undefined) that
    ///         may differ from the natural alphabetic ordering
    ///         of the Text label. Hence <see cref="IHasDisplayOrderHint" />.
    ///     </para>
    ///     <para>
    ///         It also has <see cref="IHasTenantFK" /> because the data is mutable,
    ///         and therefore is unique to each Tenant.
    ///     </para>
    ///     <para>
    ///         And because anything that is deletable must only be logically deleted,
    ///         the reference data must provide
    ///         <see cref="IHasRecordState" />
    ///     </para>
    ///     <para>
    ///         What's shown is the text of <see cref="IHasText" />.
    ///     </para>
    /// </summary>
    /// <seealso cref="IHasGuidId" />
    /// <seealso cref="IHasEnabled" />
    /// <seealso cref="IHasDisplayOrderHint" />
    /// <seealso cref="IHasKey" />
    public interface IHasMutableDisplayableReferenceData :
        IHasGuidId,
        IHasDisplayableReferenceData
    {
    }
}