namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for a model that has an
    /// <see cref="Id"/>
    /// property.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHasId<T>
        //where T  /*No: because string is not a struct : struct */
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// <para>
        /// Decorating this property with [JsonProperty(PropertyName = "id")]        
        /// This is needed for entities that will be persisted using DocumentDB.
        /// I'm so far resisting putting a reference on Newtonsoft's library, because
        /// it would cause all downstream assemblies to Reference this lib. Not good practices
        /// if it can be avoided.
        /// IH
        /// </para>
        /// </summary>
        T Id { get; set; }
    }
}