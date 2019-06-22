// Copyright MachineBrains, Inc. 2019

using System.Collections.Generic;

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    ///     TODO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ODataResponse<T>
    {
        /// <summary>
        ///     TODO
        /// </summary>
        public List<T> Value { get; set; }
    }
}