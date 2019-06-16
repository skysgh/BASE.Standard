using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.UntenantedRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasKey" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasEnabled" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasSerializedTypeValue" />
    public abstract class SettingBase 
        : UntenantedRecordStatedTimestampedGuidIdEntityBase
            , IHasKey
            , IHasEnabled,
        IHasSerializedTypeValue
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:App.Modules.All.Shared.Models.IHasEnabled" /> is enabled.
        /// <para>
        /// See <see cref="T:App.Modules.All.Shared.Models.IHasEnabledBeginningUtcDateTime" />
        /// and <see cref="T:App.Modules.All.Shared.Models.IHasEnabledEndUtcDateTime" /></para>
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// Gets or sets the unique key of the object,
        /// by which it is indexed when persisted
        /// (in additional to any primary Id).
        /// <para>
        /// Not the same as <see cref="T:App.Modules.All.Shared.Models.IHasName" /></para>.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the fullname (not FQN) of the serialized .NET type.
        /// </summary>
        public string SerializedTypeName { get; set; }
        /// <summary>
        /// Gets or sets the serialized type value.
        /// </summary>
        public string SerializedTypeValue { get; set; }


        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        public void SetValue<T>(T value)
        {
            this.SerializedTypeName = typeof(T).ToString();
            this._value = value;
        }
        private object _value;

        /// <summary>
        /// Gets the typed value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetValue<T>()
        {
            // Has been set, so SerializedTypeName is correct,
            // can get out early:
            if (this._value != null)
            {
                return (T) this._value;
            }
            // otherwise deserialize:
            //_value = <default>T;

            this.SerializedTypeName = typeof(T).ToString();

// Then get out as best as one can:
            return (T) this._value;
        }
    }
}