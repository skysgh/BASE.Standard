using System.Collections.Generic;

namespace App.Modules.Core.Models.Messages
{
    public class ODataResponse<T>
    {
        public List<T> Value { get; set; }
    }
}